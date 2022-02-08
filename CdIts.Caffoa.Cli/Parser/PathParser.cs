using CdIts.Caffoa.Cli.Config;
using CdIts.Caffoa.Cli.Errors;
using CdIts.Caffoa.Cli.Model;
using Microsoft.OpenApi.Models;

namespace CdIts.Caffoa.Cli.Parser;

public class PathParser
{
    private readonly CaffoaConfig _config;
    private readonly Func<string, string> _classNameFunc;

    public PathParser(CaffoaConfig config, Func<string, string> classNameFunc)
    {
        _config = config;
        _classNameFunc = classNameFunc;
    }

    public List<EndPointModel> Parse(string path, OpenApiPathItem item)
    {
        var result = new List<EndPointModel>();
        var baseParams = ParseParameter(item.Parameters);
        foreach (var (operation, operationItem) in item.Operations)
        {
            result.Add(ParseOperation(path, operation, operationItem, baseParams));
        }

        return result;
    }

    private EndPointModel ParseOperation(string path, OperationType operation, OpenApiOperation operationItem,
        List<ParameterObject> baseParams)
    {
        if (operationItem.OperationId is null)
            throw new CaffoaParserError($"Operation ID must be set on '{operation} {path}'");
        var name = operationItem.OperationId.ToObjectName();
        var tags = operationItem.Tags.Select(t => t.Name);
        var tag = tags.FirstOrDefault() ?? "default";
        var result = new EndPointModel(operation.ToString(), name, path.Trim('/'), tag);
        try
        {
            result.Parameters.AddRange(baseParams);
            result.Parameters.AddRange(ParseParameter(operationItem.Parameters));
            if(operationItem.Description != null)
                result.DocumentationLines = operationItem.Description.Split("\n").ToList();
            if (operationItem.RequestBody != null)
            {
                result.HasRequestBody = true;
                result.RequestBodyType = ParseRequestBody(operationItem.RequestBody);
                if (_config.RequestBodyType != null)
                {
                    foreach (var requestConfig in _config.RequestBodyType)
                    {
                        if(requestConfig.Filter.Contains(operation, operationItem))
                        {
                            result.RequestBodyType = new SimpleBodyModel(requestConfig.Type);
                            if (requestConfig.Import != null)
                                result.Imports.Add(requestConfig.Import);
                        }
                    }
                }
            }

            foreach (var (response, responseItem) in operationItem.Responses)
            {
                if (responseItem is null)
                    throw new CaffoaParserError($"Missing Response configuration for Response '{response}' (maybe a wrong reference?)");
                result.DocumentationLines.Add($"{response} -> {responseItem.Description}");
                result.Responses.Add(ParseResponse(response, responseItem));
            }
            
            if (_config.DurableClient != null && _config.DurableClient.Contains(operation, operationItem))
            {
                result.DurableClient = true;
            }
        }
        catch (CaffoaParserError e)
        {
            throw new CaffoaParserError(
                $"Error during parsing of operation {operationItem.OperationId} ({operation} {path}): {e.Message}");
        }

        return result;
    }

    private IBodyModel ParseRequestBody(OpenApiRequestBody body)
    {
        if (body.Content.Count > 1)
            throw new CaffoaParserError("Multiple possible bodies");
        var (type, content) = body.Content.First();
        if (type.ToLower() != "application/json")
            throw new CaffoaParserError($"type {type}. Only application/json is currently supported for");
        if (content.Schema is null)
            return new NullBodyModel();
        if (content.Schema.OneOf.Count > 0)
        {
            var discriminator = content.Schema.Discriminator;
            if (discriminator is null)
                throw new CaffoaParserError("Need discriminator in oneOf");
            var mapping = discriminator.Mapping.ToDictionary(i => i.Value, i => i.Key);
            var result = new SelectionBodyModel(discriminator.PropertyName);
            foreach (var subSchema in content.Schema.OneOf)
            {
                if (subSchema.Reference == null)
                    throw new CaffoaParserError("Cannot have oneOf without ref types");
                if (!mapping.TryGetValue(subSchema.Reference.ReferenceV3, out var mapName))
                    mapName = subSchema.Reference.Name();
                var typeName = _classNameFunc(subSchema.Reference.Name());
                result.Mapping[mapName] = typeName;
            }

            return result;
        }

        return new SimpleBodyModel(ParseType(content.Schema));
    }

    private string ParseType(OpenApiSchema schema)
    {
        if (schema.IsArray())
            return $"IEnumerable<{schema.GetArrayType(_classNameFunc)}>";
        if (schema.Reference != null)
            return _classNameFunc(schema.Reference.Name());
        if (schema.IsPrimitiveType())
            return schema.TypeName();
        throw new CaffoaParserError("complex type. Only array, ref or basic types are supported.");
    }


    private ResponseModel ParseResponse(string code, OpenApiResponse responseItem)
    {
        var response = new ResponseModel(code);
        if (responseItem.Content.Count > 1)
            throw new CaffoaParserError("Multiple possible responses");
        if (responseItem.Content.Count == 0)
            return response;
        var (type, content) = responseItem.Content.First();
        if (type.ToLower() != "application/json")
            throw new CaffoaParserError($"type {type}. Only application/json is currently supported for");
        var schema = content?.Schema;
        if (schema is null)
        {
            response.Unknown = true;
            return response;
        }

        response.TypeName = ParseType(schema);
        return response;
    }

    public List<ParameterObject> ParseParameter(IList<OpenApiParameter> parameters)
    {
        return parameters.Where(p => p.In is ParameterLocation.Path or ParameterLocation.Query)
            .Select(p =>
            {
                var defaultValue = p.Schema.DefaultAsString();
                p.Schema.Nullable = !p.Required && defaultValue == null;
                var result =  new ParameterObject(p.Name, p.Schema.TypeName(), p.Description,
                    p.In == ParameterLocation.Query)
                {
                    DefaultValue = defaultValue,
                    Required = p.Required
                };
                return result;
            })
            .ToList();
    }
}