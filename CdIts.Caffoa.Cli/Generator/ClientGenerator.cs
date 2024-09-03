using System.Collections;
using CdIts.Caffoa.Cli.Config;
using CdIts.Caffoa.Cli.Generator.Formatter;
using CdIts.Caffoa.Cli.Model;
using Microsoft.Extensions.Logging;

namespace CdIts.Caffoa.Cli.Generator;

public class ClientGenerator
{
    private readonly ClientConfig _clientConfig;
    private readonly CaffoaConfig _config;
    private readonly string? _modelNamespace;
    private readonly ILogger _logger;

    public ClientGenerator(ClientConfig clientConfig, CaffoaConfig config, string? modelNamespace, ILogger logger)
    {
        _clientConfig = clientConfig;
        _config = config;
        _modelNamespace = modelNamespace;
        _logger = logger;
    }

    public void GenerateClient(List<EndPointModel> endpoints, List<Server> servers)
    {
        if (_clientConfig.SplitByTag ?? _config.SplitByTag is true)
        {
            var tags = endpoints.Select(e => e.Tag).Distinct();
            foreach (var tag in tags)
            {
                if(_clientConfig.IncludeTags is null || _clientConfig.IncludeTags.Length == 0 || _clientConfig.IncludeTags.Contains(tag))
                    GenerateClient(servers, endpoints.Where(e => e.Tag == tag).ToList(), tag.ToObjectName());
            }
        }
        else
        {
            GenerateClient(servers, endpoints, "");
        }
    }
    public void GenerateClient(List<Server> servers, List<EndPointModel> endpoints, string namePrefix)
    {
        var imports = new List<string>();
        endpoints.ForEach(e => imports.AddRange(e.Imports));
        if (_config.Imports != null)
            imports.AddRange(_config.Imports);
        if (_modelNamespace != null)
            imports.Add(_modelNamespace);
        if (endpoints.Find(e => e.RequestBodyType is SelectionBodyModel) != null &&
            (_config.Flavor ?? CaffoaConfig.GenerationFlavor.JsonNet) is CaffoaConfig.GenerationFlavor.JsonNet)
            imports.Add("Newtonsoft.Json.Linq");
        var name = _clientConfig.GetName(namePrefix);
        Directory.CreateDirectory(_clientConfig.TargetFolder);
        var format = new Dictionary<string, object>();
        format["SERVERS"] = string.Join(", ", servers.Select(s=>s.Uri.Escaped()));
        format["NAMESPACE"] = _clientConfig.Namespace;
        format["CLASSNAME"] = name;
        format["CONSTRUCTOR_VISIBILITY"] = _clientConfig.ConstructorVisibility;
        format["FIELD_VISIBILITY"] = _clientConfig.FieldVisibility;
        format["IMPORTS"] = string.Join("", imports.Distinct().Select(i => $"using {i};\n"));
        format["METHODS"] = GenerateMethods(endpoints);
        var file = Templates.GetTemplate("ClientTemplate.tpl");
        var formatted = file.FormatDict(format);
        File.WriteAllText(Path.Combine(_clientConfig.TargetFolder, $"{name}.generated.cs"),
            formatted.ToSystemNewLine());
    }

    private string GenerateMethods(List<EndPointModel> endpoints)
    {
        var methods = new List<string>();
        var file = Templates.GetTemplate("ClientMethod.tpl");
        foreach (var endpoint in endpoints)
        {
            foreach (var parameter in InterfaceGenerator.GetMethodParams(endpoint, _config, false, true, forceCancellation: true))
            {
                var errorHandling = string.Join("",
                    endpoint.Responses.Where(r => r.Code >= 400 && r.TypeName != null).Select(FormatErrorHandling));
                if (!string.IsNullOrEmpty(errorHandling))
                {
                    errorHandling = "\n                try\n                {" + errorHandling +
                                    "\n                }\n                catch (Exception e) when(e is not CaffoaWebClientException)\n                {\n                    throw new CaffoaWebClientException((int)httpResult.StatusCode, errorData);\n                }\n";
                }

                var format = new Dictionary<string, object>();
                format["RESULT"] = GetResponse(endpoint);
                format["NAME"] = endpoint.Name;
                format["PARAMS"] = parameter.Declaration;
                format["DOC"] = string.Join("\n        /// ", endpoint.DocumentationLines);
                format["METHOD"] = endpoint.Operation.ToLower().FirstCharUpper();
                format["ROUTE"] = FormatRoute(endpoint.Route, endpoint.Parameters);
                format["PAYLOAD"] = RequestBody(endpoint);
                format["RESULTCODE"] = Result(endpoint);
                format["QUERYPARAMS"] = FormatQueryParams(endpoint.Parameters);
                format["ERRORHANDLING"] = errorHandling;
                var formatted = file.FormatDict(format);
                methods.Add(formatted);
            }
        }

        return string.Join("\n", methods);
    }

    private string FormatRoute(string route, List<ParameterObject> parameters)
    {
        foreach (var param in parameters.Where(p => !p.IsQueryParameter))
        {
            if (param.IsEnum)
                route = route.Replace($"{{{param.Name}}}", $"{{{param.Name}.Value()}}");
            if (param.ArrayType == ParameterArrayType.EnumArray)
                route = route.Replace($"{{{param.Name}}}", $"{{{param.Name}.AsStringList()}}");
            if (param.GetTypeName(true, false) == "DateOnly")
                route = route.Replace($"{{{param.Name}}}", $"{{{param.Name}:yyyy-MM-dd}}");
            if (param.GetTypeName(true, false) == "DateTimeOffset")
                route = route.Replace($"{{{param.Name}}}", $"{{{param.Name}:O}}");
        }

        return route;
    }


    private string GetResponse(EndPointModel endpoint)
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
                    $"Returning different objects is not supported, defaulting to Stream for {endpoint.Name}/{endpoint.Operation}");
                return "Task<Stream>";
            }

            typeName = response.TypeName;
            if (response.Unknown)
                typeName = "Stream";
        }

        return FormatResponse(codes, typeName);
    }

    private static string FormatResponse(ICollection codes, string? typeName)
    {
        if (codes.Count == 0)
            return "Task<Stream>";
        if (typeName is null)
            return codes.Count == 1 ? "Task" : "Task<int>";
        if (typeName.StartsWith("IEnumerable<KeyValuePair<string,"))
            typeName = $"IReadOnlyDictionary<string, {typeName[32..^2]}>";
        if (typeName.StartsWith("IEnumerable<"))
            typeName = $"IReadOnlyList{typeName[11..]}";
        return codes.Count == 1 ? $"Task<{typeName}>" : $"Task<({typeName}, int)>";
    }

    private string FormatQueryParams(IEnumerable<ParameterObject> parameter)
    {
        var queryAdds = string.Join("", parameter.Where(p => p.IsQueryParameter).Select(FormatQueryParam));
        return queryAdds == ""
            ? ""
            : $"\n            var queryBuilder = new QueryBuilder();{queryAdds}\n            uriBuilder.Query = queryBuilder.ToString() ?? string.Empty;";
    }

    private string FormatErrorHandling(ResponseModel model)
    {
        return
            $"\n                    if((int)httpResult.StatusCode == {model.Code})\n                        throw new CaffoaWebClientException<{model.TypeName}>({model.Code}, JsonParser.Parse<{model.TypeName}>(errorData), errorData);";
    }

    private string FormatQueryParam(ParameterObject arg)
    {
        string queryAdd;
        string baseTypeName = arg.GetTypeName(true, false);
        if (arg.IsEnum)
            queryAdd = $"queryBuilder.Add(\"{arg.Name}\", {arg.VarName}.Value());";
        else if (arg.ArrayType == ParameterArrayType.EnumArray)
            queryAdd = $"queryBuilder.Add(\"{arg.Name}\", {arg.VarName}.AsStringList());";
        else if (baseTypeName == "string")
            queryAdd = $"queryBuilder.Add(\"{arg.Name}\", {arg.VarName});";
        else if (baseTypeName == "DateTimeOffset")
            queryAdd = $"queryBuilder.Add(\"{arg.Name}\", {arg.VarName}.ToString(\"O\"));";
        else if (baseTypeName == "DateOnly")
            queryAdd = $"queryBuilder.Add(\"{arg.Name}\", {arg.VarName}.ToString(\"yyyy-MM-dd\"));";
        else
            queryAdd = $"queryBuilder.Add(\"{arg.Name}\", Invariant($\"{{{arg.VarName}}}\"));";
        if (!arg.Required)
            return $"\n            if({arg.VarName} != null)\n                {queryAdd}";
        return $"\n            {queryAdd}";
    }

    private string Result(EndPointModel endpoint)
    {
        var responses = endpoint.Responses.Where(e => e.Code < 400).ToList();
        if (!responses.Any())
            return "";
        if (responses[0].Unknown)
        {
            return "\n             var memoryStream = new MemoryStream();\n             await httpResult.Content.CopyToAsync(memoryStream);\n             memoryStream.Position = 0;\n             return memoryStream;";
        }

        var type = responses[0].TypeName;
        if (type is null)
        {
            return responses.Count > 1 ? "\n             return (int)httpResult.StatusCode;" : "";
        }

        if (type.StartsWith("IEnumerable<KeyValuePair<string,"))
            type = $"Dictionary<string, {type[32..^2]}>";
        if (type.StartsWith("IEnumerable<"))
            type = $"List{type[11..]}";

        var result = "\n            await using var resultStream = await httpResult.Content.ReadAsStreamAsync(cancellationToken);";
        result += $"\n            var resultObject = await JsonParser.Parse<{type}>(resultStream);";
        if (responses.Count > 1)
            result += "\n            return (resultObject, (int)httpResult.StatusCode);";
        else
            result += "\n            return resultObject;";
        return result;
    }

    private string RequestBody(EndPointModel endpoint)
    {
        if (!endpoint.HasRequestBody)
            return "";
        if (endpoint.RequestBodyType is NullBodyModel)
            return "\n            httpRequest.Content = new StreamContent(stream);";
        var contentType = endpoint.RequestBodyType.ContentType ?? "application/json";
        return
            $"\n            httpRequest.Content = new StringContent(JsonSerializer.JsonString(payload), Encoding.UTF8, \"{contentType}\");";
    }
}