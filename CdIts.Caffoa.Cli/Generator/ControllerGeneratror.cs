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
            foreach (var interfaceSignature in InterfaceGenerator.GetMethodParams(endpoint, _config, addAspNetAttributes: true))
            {
                var signature = interfaceSignature.ParametersIncludingBody.ToList();
                signature.RemoveAll(p => p.Name == ParameterBuilder.OpenapiTagsParameterName);
                
                var call = interfaceSignature.ParametersIncludingBody.Select(p=>p.Name).ToList();
                var tagsIndex = call.IndexOf(ParameterBuilder.OpenapiTagsParameterName);
                if (tagsIndex > 0) call[tagsIndex] = $"new string[] {{ {string.Join(", ", endpoint.Tags.Quote())} }}";
                
                var format = new Dictionary<string, object>();
                format["RESULT"] = GetResponseType(endpoint, _config.AsyncArrays is true);
                format["NAME"] = endpoint.Name;
                format["OPERATION"] = endpoint.Operation.ToObjectName();
                format["PARAMS"] = new ParameterBuilder.Overload(signature).Declaration; 
                format["CALLPARAMS"] = string.Join(", ", call);
                format["STATUSCODE"] = endpoint.Responses.First().Code;
                format["PATH"] = endpoint.Route;
                format["DOC"] = string.Join("\n    /// ", endpoint.DocumentationLines);
                format["TAGS"] = _config.PassTags ?? false ? $"var tags = new[] {{{string.Join(", ", endpoint.Tags.Select(t => $"\"{t}\""))}}};\n        " : "";
                var formatted = methodTemplate.FormatDict(format);
                methods.Add(formatted);
            }
        }

        return string.Join("\n", methods);
    }

    public string GetResponseType(EndPointModel endpoint, bool asyncArrays)
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
                return "IActionResult";
            }

            typeName = response.TypeName;
            if (response.Unknown)
                typeName = "IActionResult";
        }
        return FormatResponse(codes, typeName, asyncArrays);
    }
    private static string FormatResponse(ICollection codes, string? typeName, bool asyncArrays)
    {
        if (codes.Count == 0 || typeName == "IActionResult")
            return "Task<IActionResult>";
        if (codes.Count == 1 && typeName is null)
            return "Task<IActionResult>";
        if (codes.Count == 1 && asyncArrays && typeName!.StartsWith("IEnumerable<"))
            return $"IAsyncEnumerable{typeName[11..]}";
        if (codes.Count == 1)
            return $"Task<ActionResult<{typeName}>>";
        if (typeName is null)
            return "Task<IActionResult>";
        //if (asyncArrays && typeName!.StartsWith("IEnumerable<"))
        //    return $"(IAsyncEnumerable{typeName[11..]}, int)";
        return $"Task<ActionResult<{typeName}>>";
    }

}
