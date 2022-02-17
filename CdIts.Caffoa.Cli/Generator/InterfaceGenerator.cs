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
                GenerateInterface(endpoints.Where(e=>e.Tag == tag).ToList(), tag.ToObjectName());
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
        if(endpoints.FirstOrDefault(e=>e.DurableClient) != null)
            imports.Add("Microsoft.Azure.WebJobs.Extensions.DurableTask");
        endpoints.ForEach(e=>imports.AddRange(e.Imports));
        if(_config.Imports != null)
            imports.AddRange(_config.Imports);
        if (_modelNamespace != null)
            imports.Add(_modelNamespace);
        var targetFolder = _functionConfig.InterfaceTargetFolder;
        var name = _functionConfig.GetInterfaceName(namePrefix);
        Directory.CreateDirectory(targetFolder);
        var file = Templates.GetTemplate("InterfaceTemplate.tpl");
        var format = new Dictionary<string, object>();
        format["NAMESPACE"] = _functionConfig.InterfaceNamespace;
        format["CLASSNAME"] = name;
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
        var parameter = endpoint.Parameters.Where(p => !p.IsQueryParameter).Select(p =>
        {
            var typeName = p.GetTypeName(_config);
            return $"{typeName} {p.Name}";
        }).ToList();
        
        if(endpoint.DurableClient)
            parameter.Insert(0, "IDurableOrchestrationClient orchestrationClient");

        var queryParameters = new List<string>();
        if (_config.ParseQueryParameters is true)
        {
            queryParameters.AddRange(endpoint.QueryParameters().Select(p =>
            {
                var typeName = p.GetTypeName(_config);
                var result = $"{typeName} {p.Name}";
                if (p.DefaultValue != null)
                    result += $" = {p.DefaultValue}";
                else if (!p.Required)
                    result += $" = null";
                return result;
            }));
        }
        
        if (endpoint.HasRequestBody)
        {
            if (endpoint.RequestBodyType is SelectionBodyModel selection)
            {
                var methods = new List<string>();
                foreach (var value in selection.Mapping.Values)
                {
                    var localParameter = new List<string>(parameter);
                    localParameter.Add($"{value} payload");
                    localParameter.AddRange(queryParameters);
                    if (_config.WithCancellation is true)
                    {
                        localParameter.Add("CancellationToken cancellationToken = default");
                    }

                    methods.Add(string.Join(", ", localParameter));
                }

                return methods;
            }

            if (endpoint.RequestBodyType is SimpleBodyModel simple)
            {
                parameter.Add($"{simple.TypeName} payload");
            }
            else
            {
                parameter.Add("Stream stream");
            }
        }
        parameter.AddRange(queryParameters);
        if (_config.WithCancellation is true)
        {
            parameter.Add("CancellationToken cancellationToken = default");
        }
        return new List<string>() { string.Join(", ", parameter) };
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
                // TODO: log warning "Returning different objects is not supported"
                return "<IActionResult>";
            }

            typeName = response.TypeName;
            if (response.Unknown)
                typeName = "IActionResult";
        }

        if (codes.Count == 0)
            return "<IActionResult>";
        if (codes.Count == 1)
            return typeName == null ? "" : $"<{typeName}>";
        if (typeName is null)
            return "<int>";
        return $"<({typeName}, int)>";
    }
}