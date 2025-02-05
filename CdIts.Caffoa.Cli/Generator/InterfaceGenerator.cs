using System.Collections;
using CdIts.Caffoa.Cli.Config;
using CdIts.Caffoa.Cli.Generator.Formatter;
using CdIts.Caffoa.Cli.Model;
using Microsoft.Extensions.Logging;

namespace CdIts.Caffoa.Cli.Generator;

public class InterfaceGenerator
{
    private readonly IInterfaceConfig _interfaceConfig;
    private readonly CaffoaConfig _config;
    private readonly string? _modelNamespace;
    private readonly ILogger _logger;

    public InterfaceGenerator(IInterfaceConfig service, CaffoaConfig config, string? modelNamespace, ILogger logger)
    {
        _interfaceConfig = service;
        _config = config;
        _modelNamespace = modelNamespace;
        _logger = logger;
    }

    public void GenerateInterface(List<EndPointModel> endpoints)
    {
        if (_config.SplitByTag is true)
        {
            var tags = endpoints.Select(e => e.Tag).Distinct();
            foreach (var tag in tags)
            {
                GenerateInterface(endpoints.Where(e => e.Tag == tag).ToList(), tag.ToObjectName());
            }
        }
        else
        {
            GenerateInterface(endpoints, "");
        }
    }

    public void GenerateInterface(List<EndPointModel> endpoints, string namePrefix)
    {
        var imports = new List<string>();
        if (endpoints.Find(e => e.DurableClient) != null)
        {
            if (_config.UseIsolatedWorkerModel is true)
                imports.Add("Microsoft.DurableTask.Client");
            else
                imports.Add("Microsoft.Azure.WebJobs.Extensions.DurableTask");
        }
            
        endpoints.ForEach(e => imports.AddRange(e.Imports));
        if (_config.Imports != null)
            imports.AddRange(_config.Imports);
        if (_modelNamespace != null)
            imports.Add(_modelNamespace);
        var targetFolder = _interfaceConfig.GetInterfaceTargetFolder();
        var name = _interfaceConfig.GetInterfaceName(namePrefix);
        var ns = _interfaceConfig.GetInterfaceNamespace();
        Directory.CreateDirectory(targetFolder);
        var file = Templates.GetTemplate("InterfaceTemplate.tpl");
        var format = new Dictionary<string, object>();
        format["NAMESPACE"] = ns;
        format["CLASSNAME"] = name;
        format["PARENTS"] = _config.Disposable is true ? " : IAsyncDisposable" : "";
        format["IMPORTS"] = string.Join("", imports.Distinct().Select(i => $"using {i};\n"));
        format["METHODS"] = GenerateInterfaceMethods(endpoints);
        var formatted = file.FormatDict(format);
        File.WriteAllText(Path.Combine(targetFolder, $"{name}.generated.cs"), formatted.ToSystemNewLine());
    }

    private string GenerateInterfaceMethods(List<EndPointModel> endpoints)
    {
        var methods = new List<string>();
        var file = Templates.GetTemplate("InterfaceMethod.tpl");
        foreach (var endpoint in endpoints)
        {
            foreach (var parameter in GetParams(endpoint))
            {
                var format = new Dictionary<string, object>();
                format["RESULT"] = GetResponseType(endpoint, _config.AsyncArrays is true);
                format["NAME"] = endpoint.Name;
                format["PARAMS"] = parameter.Declaration;
                format["DOC"] = string.Join("\n        /// ", endpoint.DocumentationLines);
                var formatted = file.FormatDict(format);
                methods.Add(formatted);
            }
        }

        return string.Join("\n", methods);
    }

    public List<ParameterBuilder.Overload> GetParams(EndPointModel endpoint) => GetMethodParams(endpoint, _config);
    
    public static List<ParameterBuilder.Overload> GetMethodParams(EndPointModel endpoint, CaffoaConfig config, bool withDurable = true, bool nullableDefaults = false, bool addAspNetAttributes = false, bool forceCancellation = false, bool addHttpContent = false)
    {
        var builder = ParameterBuilder.Instance(config.UseDateOnly is true && config.ParsePathParameters is not false, config.UseDateTime is true, addAspNetAttributes)
            .AddPathParameters(endpoint.Parameters);
        if (config.PassTags is true)
            builder.AddTags();
        if (endpoint.DurableClient && withDurable)
            builder.AddDurableClient(config.UseIsolatedWorkerModel is true);
        if (config.ParseQueryParameters is not false)
            builder.AddQueryParameters(endpoint.QueryParameters(), nullableDefaults);
        if (config.WithCancellation is not false || forceCancellation)
            builder.AddCancellationToken();
        if (endpoint.HasRequestBody)
        {
            switch (endpoint.RequestBodyType)
            {
                case SelectionBodyModel selection:
                {
                    foreach (var value in selection.Mapping.Values)
                    {
                        builder.AddBody(value, "payload");
                    }

                    break;
                }
                case SimpleBodyModel simple:
                    builder.AddBody(simple.TypeName, "payload");
                    break;
                default:
                    builder.AddBody("Stream", "stream");
                    if(addHttpContent)
                        builder.AddBody("HttpContent", "payload");
                    break;
            }
        }

        return builder.BuildOverloads();
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
                return "Task<IActionResult>";
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
            return "Task";
        if (codes.Count == 1 && asyncArrays && typeName!.StartsWith("IEnumerable<"))
            return $"IAsyncEnumerable{typeName[11..]}";
        if (codes.Count == 1)
            return $"Task<{typeName}>";
        if (typeName is null)
            return "Task<int>";
        if (asyncArrays && typeName!.StartsWith("IEnumerable<"))
            return $"(IAsyncEnumerable{typeName[11..]}, int)";
        return $"Task<({typeName}, int)>";
    }
}