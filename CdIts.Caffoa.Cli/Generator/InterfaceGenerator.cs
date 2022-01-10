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
        var imports = new List<string>();
        endpoints.ForEach(e => imports.AddRange(e.Imports));
        if (_config.Imports != null)
            imports.AddRange(_config.Imports);
        if (_modelNamespace != null)
            imports.Add(_modelNamespace);
        var targetFolder = _functionConfig.InterfaceTargetFolder;
        var name = _functionConfig.InterfaceName;
        Directory.CreateDirectory(targetFolder);
        var file = Templates.GetTemplate("InterfaceTemplate.tpl");
        var format = new Dictionary<string, object>();
        format["NAMESPACE"] = _functionConfig.InterfaceNamespace;
        format["CLASSNAME"] = name;
        format["IMPORTS"] = string.Join("", imports.Distinct().Select(i => $"using {i};\n"));
        format["METHODS"] = GenerateInterfaceMethods(endpoints);
        var formatted = file.FormatDict(format);
        File.WriteAllText(Path.Combine(targetFolder, name + ".generated.cs"), formatted);
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
            var typeName = p.TypeName.Replace("DateOnly", "DateTime");
            return $"{typeName} {p.Name}";
        }).ToList();
        if (_config.ParseQueryParameters is true)
        {
            parameter.AddRange(endpoint.QueryParameters().Select(p =>
            {
                var typeName = p.TypeName.Replace("DateOnly", "DateTime");
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