using System.Text;
using CdIts.Caffoa.Cli.Config;
using CdIts.Caffoa.Cli.Generator.Formatter;
using CdIts.Caffoa.Cli.Model;

namespace CdIts.Caffoa.Cli.Generator;

public class FunctionsGenerator
{
    private readonly FunctionConfig _functionConfig;
    private readonly CaffoaConfig _config;
    private readonly string? _modelNamespace;

    public FunctionsGenerator(FunctionConfig service, CaffoaConfig mergedConfig, string? modelNamespace)
    {
        _functionConfig = service;
        _config = mergedConfig;
        _modelNamespace = modelNamespace;
    }

    public void GenerateFunctions(List<EndPointModel> endpoints)
    {
        var imports = new List<string>();
        endpoints.ForEach(e => imports.AddRange(e.Imports));
        if(_functionConfig.InterfaceNamespace != _functionConfig.Namespace)
            imports.Add(_functionConfig.InterfaceNamespace);
        if (_modelNamespace != null)
            imports.Add(_modelNamespace);
        var extraVars = new List<AdditionalInterfaceModel>();
        if (_config.ParsePathParameters is true || _config.ParseQueryParameters is true)
        {
            extraVars.Add(new AdditionalInterfaceModel()
            {
                VariableName = "converter",
                ParameterType = "ICaffoaConverter",
                Initializer = "converter ?? new DefaultCaffoaConverter(_errorHandler)"
            });
        }
        var name = _functionConfig.FunctionsName;
        Directory.CreateDirectory(_functionConfig.TargetFolder);
        var file = Templates.GetTemplate("FunctionsTemplate.tpl");
        var format = new Dictionary<string, object>();
        format["NAMESPACE"] = _functionConfig.Namespace;
        format["CLASSNAME"] = name;
        format["INTERFACE"] = _functionConfig.InterfaceName;
        format["IMPORTS"] = string.Join("", imports.Distinct().Select(i => $"using {i};\n"));
        format["METHODS"] = GenerateFunctionMethods(endpoints);
        format["ADDITIONAL_VARIABLES"] = string.Join("\n        ", extraVars.Select(it => $"private readonly {it.ParameterType} _{it.VariableName};"));
        format["ADDITIONAL_INTERFACES"] = string.Join("", extraVars.Select(it => $", {it.ParameterType} {it.VariableName} = null"));
        format["ADDITIONAL_INITS"] = string.Join("", extraVars.Select(it => $"            _{it.VariableName} = {it.Initializer};\n"));
        var formatted = file.FormatDict(format);
        File.WriteAllText(Path.Combine(_functionConfig.TargetFolder, name + ".generated.cs"), formatted);
    }

    private string GenerateFunctionMethods(List<EndPointModel> endpoints)
    {
        var methods = new List<string>();
        foreach (var endpoint in endpoints)
        {
            methods.Add(GenerateFunctionMethod(endpoint));
        }

        return string.Join("\n", methods);
    }

    private string GenerateFunctionMethod(EndPointModel endpoint)
    {
        var file = Templates.GetTemplate("FunctionsMethod.tpl");
        var parameters = new Dictionary<string, object>();
        var (result, variable) = GenerateResult(endpoint);
        string call;
        if (endpoint.HasRequestBody && endpoint.RequestBodyType is SelectionBodyModel)
            call = FormatSelectionCall(endpoint, variable);
        else
        {
            call = FormatCall(endpoint, variable, ParseParameters(endpoint), true);
        }
        IEnumerable<string> pathParams;
        var filteredParams = endpoint.Parameters.Where(p => !p.IsQueryParameter);
        if(_config.ParsePathParameters is true)
            pathParams = filteredParams.Select(p => $", string {p.Name}");
        else
            pathParams = filteredParams.Select(p =>
            {
                var type = p.GetTypeName(_config); // Invalid cast from 'System.String' to 'System.DateOnly' by Azure functions
                return $", {type} {p.Name}";
            });

        parameters["NAME"] = endpoint.Name;
        parameters["OPERATION"] = endpoint.Operation;
        parameters["PATH"] = _config.RoutePrefix + endpoint.Route;
        parameters["RESULT"] = result;
        parameters["QUERY_VARIABLES"] = GenerateQueryVariables(endpoint);
        parameters["CALL"] = call;
        parameters["PARAM_NAMES"] = string.Join("", pathParams);
        parameters["ADDITIONAL_ERROR_INFOS"] = string.Join("",endpoint.Parameters.Where(p=>!p.IsQueryParameter).Select(p=>$", (\"{p.Name}\", {p.Name})"));
        return file.FormatDict(parameters);
    }

    private string GenerateQueryVariables(EndPointModel endpoint)
    {
        if (_config.ParseQueryParameters is not true) 
            return "";
        var parameters = new List<string>();
        foreach (var parameter in endpoint.Parameters.Where(p => p.IsQueryParameter))
        {
            var sb = new StringBuilder();
            var typeName = parameter.GetTypeName(_config);
            sb.Append($"{typeName} {parameter.Name}");
            if (parameter.DefaultValue != null)
                sb.Append($" = {parameter.DefaultValue}");
            else if (!parameter.Required)
                sb.Append($" = null");
            sb.Append(";\n                ");
            sb.Append($"if(request.Query.TryGetValue(\"{parameter.Name}\", out var {parameter.Name}QueryValue))");
            sb.Append("\n                    ");
            sb.Append($"{parameter.Name} = ");
            sb.Append(FormatConversion(parameter.GetTypeName(_config).Trim('?'), $"{parameter.Name}QueryValue", parameter.Name));
            sb.Append(";\n                ");
            if (parameter.Required && parameter.DefaultValue is null)
            {
                sb.Append("else\n                    ");
                sb.Append($"throw _errorHandler.RequiredQueryParamMissing(\"{parameter.Name}\");");
                sb.Append("\n                ");
            }
            
            parameters.Add(sb.ToString());
        }
        return string.Join("", parameters);

    }

    private string FormatCall(EndPointModel endpoint, string variable, IEnumerable<string> parameters, bool addAwait)
    {
        var callParams = string.Join(", ", parameters);
        var awaitStr = addAwait ? "await " : "";
        return $"{variable}{awaitStr}_factory.Instance(request).{endpoint.Name}Async({callParams})";
    }

    private string FormatSelectionCall(EndPointModel endpoint, string variable)
    {
        var model = endpoint.RequestBodyType as SelectionBodyModel;
        var file = Templates.GetTemplate("FunctionsSwitchMethod.tpl");
        var parameter = new Dictionary<string, object>();
        var cases = new List<string>();
        var callParams = BuildCallParameterList(endpoint);
        foreach (var (key, type) in model!.Mapping)
        {
            var caseParams = new List<string>(callParams);
            caseParams.Add($"_jsonParser.ToObject<{type}>(jObject)");
            var call = FormatCall(endpoint, "", caseParams, false);
            cases.Add($"\"{key}\" => {call}");
        }
        parameter["VALUE"] = variable;
        parameter["DISC"] = model.Disriminator;
        parameter["CASES_ALLOWED_VALUES"] = string.Join(", ", model.Mapping.Keys.Select(k => $"\"{k}\""));
        parameter["CASES"] = string.Join("\n                    ", cases.Select(c=>$"{c},"));
        return file.FormatDict(parameter);
    }

    private IEnumerable<string> ParseParameters(EndPointModel endpoint)
    {
        var callParams = BuildCallParameterList(endpoint);
        if (endpoint.HasRequestBody && endpoint.RequestBodyType is SimpleBodyModel simple)
            callParams.Add($"await _jsonParser.Parse<{simple.TypeName}>(request.Body)");
        else if (endpoint.HasRequestBody)
            callParams.Add($"request.Body");
        return callParams;
    }

    private IList<string> BuildCallParameterList(EndPointModel endpoint)
    {
        var filtered = endpoint.Parameters.Where(p => !p.IsQueryParameter).ToList();
        List<string> result;
        if (_config.ParsePathParameters is true)
            result = filtered.Select(p => FormatConversion(p.GetTypeName(_config), p.Name, p.Name)).ToList();
        else
            result = filtered.Select(p => p.Name).ToList();
        if (_config.ParseQueryParameters is true)
        {
            result.AddRange(endpoint.QueryParameters().Select(p=>p.Name));
        }

        return result;
    }

    private string FormatConversion(string typeName, string variableName, string objectName)
    {
        if (typeName == "string")
            return $"{variableName}";
        if(typeName == "DateOnly" && _config.UseDateOnly is true)
            return $"_converter.ParseDateOnly({variableName}, nameof({objectName}))";
        if(typeName == "DateOnly")
            return $"_converter.ParseDate({variableName}, nameof({objectName}))";
        if(typeName == "DateTime")
            return $"_converter.ParseDateTime({variableName}, nameof({objectName}))";
        return $"_converter.Parse<{typeName}>({variableName}, nameof({objectName}))";
    }


    private (string, string) GenerateResult(EndPointModel endpoint)
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
                return ("_resultHandler.Handle(result)", "var result = ");
            }
            typeName = response.TypeName;
            if (response.Unknown)
                return ("_resultHandler.Handle(result)", "var result = ");
        }

        if (codes.Count == 0)
            return ("_resultHandler.Handle(result)", "var result = ");
        if (codes.Count == 1 && typeName is null)
            return ($"_resultHandler.StatusCode({codes[0]})", "");
        if (codes.Count == 1)
            return ($"_resultHandler.Json(result, {codes[0]})", "var result = ");
        if (typeName is null)
            return ($"_resultHandler.StatusCode(result)", "var result = ");
        return ("_resultHandler.Json(result, code)", "var (result, code) = ");
    }
}
