using System.Collections;
using CdIts.Caffoa.Cli.Config;
using CdIts.Caffoa.Cli.Generator.Formatter;
using CdIts.Caffoa.Cli.Model;

namespace CdIts.Caffoa.Cli.Generator;

public class InterfaceGenerator
{
    private readonly FunctionConfig _functionConfig;
    private readonly CaffoaConfig _config;
    private readonly string? _modelNamespace;

    public InterfaceGenerator(FunctionConfig service, CaffoaConfig config, string? modelNamespace)
    {
        _functionConfig = service;
        _config = config;
        _modelNamespace = modelNamespace;
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
        if (endpoints.FirstOrDefault(e => e.DurableClient) != null)
            imports.Add("Microsoft.Azure.WebJobs.Extensions.DurableTask");
        endpoints.ForEach(e => imports.AddRange(e.Imports));
        if (_config.Imports != null)
            imports.AddRange(_config.Imports);
        if (_modelNamespace != null)
            imports.Add(_modelNamespace);
        var targetFolder = _functionConfig.InterfaceTargetFolder ?? _functionConfig.TargetFolder;
        var name = _functionConfig.GetInterfaceName(namePrefix);
        Directory.CreateDirectory(targetFolder);
        var file = Templates.GetTemplate("InterfaceTemplate.tpl");
        var format = new Dictionary<string, object>();
        format["NAMESPACE"] = _functionConfig.InterfaceNamespace ?? _functionConfig.Namespace;
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
                format["RESULT"] = GetResponseType(endpoint);
                format["NAME"] = endpoint.Name;
                format["PARAMS"] = parameter;
                format["DOC"] = string.Join("\n        /// ", endpoint.DocumentationLines);
                var formatted = file.FormatDict(format);
                methods.Add(formatted);
            }
        }

        return string.Join("\n", methods);
    }

    private List<string> GetParams(EndPointModel endpoint)
    {
        var builder = ParameterBuilder.Instance()
            .AddPathParameters(endpoint.Parameters);
        if (endpoint.DurableClient)
            builder.AddDurableClient();
        builder.AddQueryParameters(endpoint.QueryParameters());
        if (!_config.WithCancellation is false)
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

        return builder.Build();
    }

    private string GetResponseType(EndPointModel endpoint)
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
                Console.Error.WriteLine(
                    $"Returning different objects is not supported, defaulting to IActionResult for {endpoint.Name}/{endpoint.Operation}");
                return "Task<IActionResult>";
            }

            typeName = response.TypeName;
            if (response.Unknown)
                typeName = "IActionResult";
        }
        return FormatResponse(codes, typeName);
    }

    private string FormatResponse(ICollection codes, string? typeName)
    {
        if (codes.Count == 0)
            return "Task<IActionResult>";
        if (codes.Count == 1 && typeName is null)
            return "Task";
        if (codes.Count == 1 && _config.AsyncArrays is true && typeName!.StartsWith("IEnumerable<"))
            return $"IAsyncEnumerable{typeName[11..]}";
        if (codes.Count == 1)
            return $"Task<{typeName}>";
        if (typeName is null)
            return "Task<int>";
        if (_config.AsyncArrays is true && typeName!.StartsWith("IEnumerable<"))
            return $"(IAsyncEnumerable{typeName[11..]}, int)";
        return $"Task<({typeName}, int)>";
    }
}