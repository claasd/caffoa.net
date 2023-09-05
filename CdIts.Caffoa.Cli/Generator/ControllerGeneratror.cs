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
        if (_config.Imports != null)
            imports.AddRange(_config.Imports);
        if (_modelNamespace != null)
            imports.Add(_modelNamespace);
        if (endpoints.Find(e => e.RequestBodyType is SelectionBodyModel) != null && _config.Flavor is not CaffoaConfig.GenerationFlavor.SystemTextJson)
            imports.Add("Newtonsoft.Json.Linq");

        var name = _controllerConfig.GetControllerName(namePrefix);
        var outputFileName = Path.Combine(_controllerConfig.TargetFolder, $"{name}.cs");
        if (!File.Exists(outputFileName))
        {
            Directory.CreateDirectory(_controllerConfig.TargetFolder);
            var file = Templates.GetTemplate("ControllerTemplate.tpl");
            var format = new Dictionary<string, object>();
            format["IMPORTS"] = string.Join("", imports.Distinct().Select(i => $"using {i};\n"));
            format["NAMESPACE"] = _controllerConfig.Namespace;
            format["CLASSNAME"] = name;
            format["BASEPATH"] = _config.RoutePrefix?.Trim('/') ?? string.Empty;
            var formatted = file.FormatDict(format);
            File.WriteAllText(outputFileName, formatted.ToSystemNewLine());
        }
        GenerateControllerMethods(endpoints, name, outputFileName);
    }

    private void GenerateControllerMethods(List<EndPointModel> endpoints, string className, string outputFileName)
    {
        var methods = new List<string>();
        var methodTemplate = Templates.GetTemplate("ControllerMethod.tpl");
        var content = File.ReadAllText(outputFileName);

        foreach (var endpoint in endpoints)
        {
            foreach (var (parameter,body) in GetMethodParams(endpoint))
            {
                var methodRegex = new Regex($"public .* {endpoint.Name}Async\\(.*{body}.*\\)\\s*{{?\\s*$", RegexOptions.Multiline);
                if (!methodRegex.IsMatch(content))
                {
                    var format = new Dictionary<string, object>();
                    format["RESULT"] = GetResponseType(endpoint, _config.AsyncArrays is true);
                    format["NAME"] = endpoint.Name;
                    format["OPERATION"] = endpoint.Operation.ToObjectName();
                    format["PARAMS"] = parameter;
                    format["PATH"] = endpoint.Route;
                    format["DOC"] = string.Join("\n    /// ", endpoint.DocumentationLines);
                    format["TAGS"] = _config.PassTags ?? false ? $"var tags = new[] {{{string.Join(", ", endpoint.Tags.Select(t => $"\"{t}\""))}}};\n        " : "";
                    var formatted = methodTemplate.FormatDict(format);
                    methods.Add(formatted);
                }
            }
        }

        if (methods.Any())
        {
            var splitAt = FindInsertionPoint(className, content);
            foreach (var method in methods)
            {
                content = content.Insert(splitAt, method);
            }

            File.WriteAllText(outputFileName, content, Encoding.UTF8);
            _logger.LogInformation("Modified Controller {ClassName}. Please check the results.", className);
        }

    }

    private int FindInsertionPoint(string className, string content)
    {
        int splitAt = -1;
        var splitMatch = new Regex(".*Caffoa insertion point\\.").Match(content);
        if (splitMatch.Success) splitAt = splitMatch.Index;
        else
        {
            var classMatch = new Regex($"class {className}.*\\n?\\s*{{\\s*\\n").Match(content);
            if (classMatch.Success) splitAt = classMatch.Index + classMatch.Length;
            _logger.LogWarning("Adding Methods to the top of Contoller {ClassName} without insertion point. Add a line with the content '// *** Caffoa insertion point.' to control where new code gets added.", className);
        }

        if (splitAt < 0) throw new InvalidOperationException("Could not find insertion point in controller file");
        return splitAt;
    }

    public IEnumerable<(string parameters, string body)> GetMethodParams(EndPointModel endpoint, bool nullableDefaults = false)
    {
        var builder = ParameterBuilder.Instance(_config.UseDateOnly is true && _config.ParsePathParameters is not false, _config.UseDateTime is true, true)
            .AddPathParameters(endpoint.Parameters);
        if (_config.ParseQueryParameters is not false)
            builder.AddQueryParameters(endpoint.QueryParameters(), nullableDefaults);
        if (_config.WithCancellation is not false)
            builder.AddCancellationToken();
        if (endpoint.HasRequestBody)
        {
            switch (endpoint.RequestBodyType)
            {
                case SelectionBodyModel selection:
                {
                    foreach (var value in selection.Mapping.Values)
                    {
                        builder.AddBody($"{value} payload");
                    }

                    break;
                }
                case SimpleBodyModel simple:
                    builder.AddBody($"{simple.TypeName} payload");
                    break;
                default:
                    builder.AddBody("Stream stream");
                    break;
            }
        }

        return builder.BuildWithBodies();
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
