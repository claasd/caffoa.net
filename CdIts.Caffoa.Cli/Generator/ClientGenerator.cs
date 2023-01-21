﻿using System.Collections;
using CdIts.Caffoa.Cli.Config;
using CdIts.Caffoa.Cli.Generator.Formatter;
using CdIts.Caffoa.Cli.Model;

namespace CdIts.Caffoa.Cli.Generator;

public class ClientGenerator
{
    private readonly ClientConfig _clientConfig;
    private readonly CaffoaConfig _config;
    private readonly string? _modelNamespace;

    public ClientGenerator(ClientConfig clientConfig, CaffoaConfig config, string? modelNamespace)
    {
        _clientConfig = clientConfig;
        _config = config;
        _modelNamespace = modelNamespace;
    }

    public void GenerateClient(List<EndPointModel> endpoints)
    {
        var imports = new List<string>();
        endpoints.ForEach(e => imports.AddRange(e.Imports));
        if (_config.Imports != null)
            imports.AddRange(_config.Imports);
        if (_modelNamespace != null)
            imports.Add(_modelNamespace);
        if (endpoints.FirstOrDefault(e => e.RequestBodyType is SelectionBodyModel) != null &&
            _config.Flavor is not CaffoaConfig.GenerationFlavor.SystemTextJson)
            imports.Add("Newtonsoft.Json.Linq");
        Directory.CreateDirectory(_clientConfig.TargetFolder);
        var format = new Dictionary<string, object>();
        format["NAMESPACE"] = _clientConfig.Namespace;
        format["CLASSNAME"] = _clientConfig.Name;
        format["CONSTRUCTOR_VISIBILITY"] = _clientConfig.ConstructorVisibility;
        format["FIELD_VISIBILITY"] = _clientConfig.FieldVisibility;
        format["IMPORTS"] = string.Join("", imports.Distinct().Select(i => $"using {i};\n"));
        format["METHODS"] = GenerateMethods(endpoints);
        var file = Templates.GetTemplate("ClientTemplate.tpl");
        var formatted = file.FormatDict(format);
        File.WriteAllText(Path.Combine(_clientConfig.TargetFolder, $"{_clientConfig.Name}.generated.cs"),
            formatted.ToSystemNewLine());
    }

    private string GenerateMethods(List<EndPointModel> endpoints)
    {
        var methods = new List<string>();
        var file = Templates.GetTemplate("ClientMethod.tpl");
        foreach (var endpoint in endpoints)
        {
            foreach (var parameter in InterfaceGenerator.GetMethodParams(endpoint, _config, false, true))
            {
                var format = new Dictionary<string, object>();
                format["RESULT"] = GetResponse(endpoint);
                format["NAME"] = endpoint.Name;
                format["PARAMS"] = parameter;
                format["DOC"] = string.Join("\n        /// ", endpoint.DocumentationLines);
                format["METHOD"] = endpoint.Operation.ToLower().FirstCharUpper();
                format["ROUTE"] = endpoint.Route;
                format["PAYLOAD"] = RequestBody(endpoint);
                format["RESULTCODE"] = Result(endpoint);
                format["QUERYPARAMS"] = FormatQueryParams(endpoint.Parameters);
                format["ERRORHANDLING"] = string.Join("",
                    endpoint.Responses.Where(r => r.Code >= 400 && r.TypeName != null).Select(FormatErrorHandling));
                var formatted = file.FormatDict(format);
                methods.Add(formatted);
            }
        }

        return string.Join("\n", methods);
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
                Console.Error.WriteLine(
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
            typeName = $"IReadOnlyDictionary<string, {typeName[45..^2]}";
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
            $"\n                if((int)httpResult.StatusCode == {model.Code})\n                    throw new CaffoaWebClientException<{model.TypeName}>({model.Code}, JsonParser.Parse<{model.TypeName}>(errorData));";
    }

    private string FormatQueryParam(ParameterObject arg)
    {
        string queryAdd;
        if (arg.IsEnum)
            queryAdd = $"queryBuilder.Add(\"{arg.Name}\", {arg.Name}.Value());";
        else if (arg.IsEnumArray)
            queryAdd = $"queryBuilder.Add(\"{arg.Name}\", string.Join(\",\", {arg.Name}.Select(v=>v.Value())));";
        else if (arg.GetTypeName(true, false) == "string")
            queryAdd = $"queryBuilder.Add(\"{arg.Name}\", {arg.Name});";
        else
            queryAdd = $"queryBuilder.Add(\"{arg.Name}\", $\"{{{arg.Name}}}\");";
        if (!arg.Required)
            return $"\n            if({arg.Name} != null)\n                {queryAdd}";
        return $"\n            {queryAdd}";
    }

    private string Result(EndPointModel endpoint)
    {
        var responses = endpoint.Responses.Where(e => e.Code < 400).ToList();
        if (!responses.Any())
            return "";
        if (responses[0].Unknown)
        {
            return "\n             return await httpResult.Content.ReadAsStreamAsync();";
        }

        var type = responses[0].TypeName;
        if (type is null)
        {
            return responses.Count > 1 ? "\n             return (int)httpResult.StatusCode;" : "";
        }
        if (type.StartsWith("IEnumerable<KeyValuePair<string,"))
            type = $"Dictionary<string, {type[45..^2]}";
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
        return
            "\n            httpRequest.Content = new StringContent(JsonSerializer.JsonString(payload), Encoding.UTF8, MediaTypeNames.Application.Json);";
    }
}