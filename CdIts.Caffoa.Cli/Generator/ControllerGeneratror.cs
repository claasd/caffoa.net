using System.Collections;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using CdIts.Caffoa.Cli.Config;
using CdIts.Caffoa.Cli.Generator.Formatter;
using CdIts.Caffoa.Cli.Model;
using Microsoft.Extensions.Logging;

namespace CdIts.Caffoa.Cli.Generator;

public class ControllerGenerator
{
    private readonly ControllerConfig _controllerConfig;
    private readonly CaffoaConfig _config;
    private readonly string? _modelNamespace;
    private readonly ILogger _logger;

    public ControllerGenerator(ControllerConfig service, CaffoaConfig mergedConfig, string? modelNamespace, ILogger logger)
    {
        _controllerConfig = service;
        _config = mergedConfig;
        _modelNamespace = modelNamespace;
        _logger = logger;
    }

    public void GenerateController(List<EndPointModel> endpoints)
    {
        if (_config.SplitByTag is true)
        {
            var tags = endpoints.Select(e => e.Tag).Distinct();
            foreach (var tag in tags)
            {
                GenerateController(endpoints.Where(e => e.Tag == tag).ToList(), tag.ToObjectName());
            }
        }
        else
        {
            GenerateController(endpoints, "");
        }
    }

    public void GenerateController(List<EndPointModel> endpoints, string namePrefix)
    {
        var imports = new List<string>();
        endpoints.ForEach(e => imports.AddRange(e.Imports));
        if (_controllerConfig.InterfaceNamespace != null) imports.Add(_controllerConfig.InterfaceNamespace);
        if (_config.Imports != null)
            imports.AddRange(_config.Imports);
        if (_modelNamespace != null)
            imports.Add(_modelNamespace);
        if (endpoints.Find(e => e.RequestBodyType is SelectionBodyModel) != null && _config.Flavor is not CaffoaConfig.GenerationFlavor.SystemTextJson)
            imports.Add("Newtonsoft.Json.Linq");

        var name = _controllerConfig.GetControllerName(namePrefix);
        Directory.CreateDirectory(_controllerConfig.TargetFolder);
        var file = Templates.GetTemplate("ControllerTemplate.tpl");
        var format = new Dictionary<string, object>();
        format["IMPORTS"] = string.Join("", imports.Distinct().Select(i => $"using {i};\n"));
        format["NAMESPACE"] = _controllerConfig.Namespace;
        format["CLASSNAME"] = name;
        format["METHODS"] = GenerateControllerMethods(endpoints);
        format["BASEPATH"] = _config.RoutePrefix?.Trim('/') ?? string.Empty;
        format["INTERFACE"] = _controllerConfig.GetInterfaceName(namePrefix);
        var formatted = file.FormatDict(format);
        var outputFileName = Path.Combine(_controllerConfig.TargetFolder, $"{name}.generated.cs");
        File.WriteAllText(outputFileName, formatted.ToSystemNewLine());
    }

    private string GenerateControllerMethods(List<EndPointModel> endpoints)
    {
        var methods = new List<string>();
        var methodTemplate = Templates.GetTemplate("ControllerMethod.tpl");
        foreach (var endpoint in endpoints)
        {
            var noAwait = _config.AsyncArrays is true && endpoint.HasArrayResult();
            var interfaceSignatures = InterfaceGenerator.GetMethodParams(endpoint, _config, addAspNetAttributes: true);
            var (responseType, bodyFormatString) = GetResponseType(endpoint, _config.AsyncArrays is true);
            var body = endpoint.RequestBodyType switch
            {
                SimpleBodyModel or NullBodyModel => GenerateSimpleBody(interfaceSignatures.First(), endpoint, bodyFormatString),
                SelectionBodyModel selectionBodyModel => GenerateSelectionBody(selectionBodyModel, interfaceSignatures, endpoint, bodyFormatString),
                _ => throw new InvalidOperationException("Unknown body type")
            };
            var signature = interfaceSignatures.First().ParametersIncludingBody.ToList();
            signature.RemoveAll(p => p.Name == ParameterBuilder.OpenapiTagsParameterName);
            if (endpoint.RequestBodyType is SelectionBodyModel)
            {
                var bodyIndex = signature.FindIndex(p => p.IsBody);
                signature[bodyIndex] = new ParameterBuilder.Parameter(_config.Flavor == CaffoaConfig.GenerationFlavor.SystemTextJson ? "JsonDocument": "JToken", "payload");
            }

            var format = new Dictionary<string, object>();
            format["RESULT"] = responseType;
            format["NAME"] = endpoint.Name;
            format["OPERATION"] = endpoint.Operation.ToObjectName();
            format["PARAMS"] = new ParameterBuilder.Overload(signature).Declaration;
            format["BODY"] = body;
            format["PATH"] = endpoint.Route;
            format["DOC"] = string.Join("\n    /// ", endpoint.DocumentationLines);
            var formatted = methodTemplate.FormatDict(format);
            methods.Add(formatted);
        }

        return string.Join("\n", methods);
    }

    private string GenerateSelectionBody(SelectionBodyModel selectionBodyModel, List<ParameterBuilder.Overload> interfaceSignatures, EndPointModel endpoint, string bodyFormatString)
    {
        string body;
        var selectionBodyTemplate = Templates.GetTemplate("ControllerSelectionBody.tpl");
        var cases = selectionBodyModel.Mapping.Keys.Zip(interfaceSignatures).Select(x =>
        {
            var callParams = x.Second.ParametersIncludingBody.Select(p => p.Name).ToList();
            var tagsIndex = callParams.IndexOf(ParameterBuilder.OpenapiTagsParameterName);
            if (tagsIndex > 0) callParams[tagsIndex] = $"new string[] {{ {string.Join(", ", endpoint.Tags.Quote())} }}";
            var bodyParameter = x.Second.BodyParameter!;
            var bodyIndex = callParams.IndexOf(bodyParameter.Name);
            callParams[bodyIndex] = _config.Flavor == CaffoaConfig.GenerationFlavor.SystemTextJson ? $"{bodyParameter.Name}.RootElement.Deserialize<{bodyParameter.Type}>()" : $"{bodyParameter.Name}.ToObject<{bodyParameter.Type}>()";
            var call = string.Format(bodyFormatString, $"GetService().{endpoint.Name}Async({string.Join(", ", callParams)})");
            return $"case {x.First.Quote()}: {{ {call} }}";
        });
        body = selectionBodyTemplate.FormatDict(new Dictionary<string, object>
        {
            ["SWITCHON"] = _config.Flavor == CaffoaConfig.GenerationFlavor.SystemTextJson? $"payload.RootElement.GetProperty({selectionBodyModel.Disriminator.Quote()}).GetString()": $"payload.Value<string>({selectionBodyModel.Disriminator.Quote()})",
            ["CASES"] = string.Join("\n        ", cases),
        });
        return body;
    }

    private static string GenerateSimpleBody(ParameterBuilder.Overload interfaceSignature, EndPointModel endpoint, string bodyFormatString)
    {
        var callParams = interfaceSignature.ParametersIncludingBody.Select(p => p.Name).ToList();
        var tagsIndex = callParams.IndexOf(ParameterBuilder.OpenapiTagsParameterName);
        if (tagsIndex > 0) callParams[tagsIndex] = $"new string[] {{ {string.Join(", ", endpoint.Tags.Quote())} }}";
        var body = string.Format(bodyFormatString, $"GetService().{endpoint.Name}Async({string.Join(", ", callParams)})");
        return body;
    }
    public (string response, string body) GetResponseType(EndPointModel endpoint, bool asyncArrays)
    {
        var codes = new List<int>();
        string? typeName = null;
        foreach (var response in endpoint.Responses)
        {
            if (response.Code is < 200 or >= 300)
                continue;
            codes.Add(response.Code);
            if (typeName != null && typeName != response.TypeName)
            {
                _logger.LogWarning(
                    $"Returning different objects is not supported, defaulting to IActionResult for {endpoint.Name}/{endpoint.Operation}");
                return ("IActionResult", "=> {0};");
            }

            typeName = response.TypeName;
            if (response.Unknown)
                typeName = "IActionResult";
        }
        return (FormatResponse(codes, typeName, asyncArrays), FormatBody(codes, typeName, asyncArrays));
    }

    private static string FormatBody(List<int> codes, string? typeName, bool asyncArrays)
    {
        // Fill {0} with the call 
        if (codes.Count == 0 || typeName == "IActionResult")
            return "return await {0};";
        if (codes.Count == 1 && typeName is null)
            return $"await {{0}}; return StatusCode({codes.First()});";
        if (codes.Count == 1 && asyncArrays && typeName!.StartsWith("IEnumerable<"))
            return $"return StatusCode({codes.First()}, {{0}})";
        if (codes.Count == 1)
            return $"return StatusCode({codes.First()}, await {{0}});";
        if (typeName is null)
            return "return StatusCode(await {0});";
        if (asyncArrays && typeName!.StartsWith("IEnumerable<"))
            return "var (res, code) = {0}; return StatusCode(code, res);";
        return "var (res, code) = await {0}; return StatusCode(code, res);"; 
    }

    private static string FormatResponse(ICollection codes, string? typeName, bool asyncArrays)
    {
        if (codes.Count == 0 || typeName == "IActionResult")
            return "Task<IActionResult>";
        if (codes.Count == 1 && typeName is null)
            return "Task<IActionResult>";
        if (codes.Count == 1 && asyncArrays && typeName!.StartsWith("IEnumerable<"))
            return $"IActionResult<IAsyncEnumerable{typeName[11..]}>";
        if (codes.Count == 1)
            return $"Task<ActionResult<{typeName}>>";
        if (typeName is null)
            return "Task<IActionResult>";
        //if (asyncArrays && typeName!.StartsWith("IEnumerable<"))
        //    return $"(IAsyncEnumerable{typeName[11..]}, int)";
        return $"Task<ActionResult<{typeName}>>";
    }

}
