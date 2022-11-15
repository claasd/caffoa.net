using CdIts.Caffoa.Cli.Config;
using CdIts.Caffoa.Cli.Errors;
using CdIts.Caffoa.Cli.Model;
using Microsoft.OpenApi.Models;

namespace CdIts.Caffoa.Cli.Parser;

public class PathParser
{
    private readonly CaffoaConfig _config;
    private readonly Func<string, string> _classNameFunc;
    private readonly Dictionary<string, OpenApiSchema> _knownTypes;

    public PathParser(CaffoaConfig config, Func<string, string> classNameFunc,
        Dictionary<string, OpenApiSchema> knownTypes)
    {
        _config = config;
        _classNameFunc = classNameFunc;
        _knownTypes = knownTypes;
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
            throw new CaffoaParserException($"Operation ID must be set on '{operation} {path}'");
        var name = operationItem.OperationId.ToObjectName();
        var tags = operationItem.Tags.Select(t => t.Name);
        var tag = tags.FirstOrDefault() ?? "default";
        var result = new EndPointModel(operation.ToString(), name, path.Trim('/'), tag);
        try
        {
            result.Parameters.AddRange(baseParams);
            result.Parameters.AddRange(ParseParameter(operationItem.Parameters));
            result.DocumentationLines = operationItem.Description?.Split("\n").ToList() ?? new List<string>();
            if (operationItem.RequestBody != null)
            {
                result.HasRequestBody = true;
                result.RequestBodyType = ParseRequestBody(operationItem.RequestBody);
                if (_config.RequestBodyType != null)
                {
                    var typeOverride = _config.RequestBodyType.FirstOrDefault(requestConfig =>
                        requestConfig.Filter.Contains(operation, operationItem));
                    if (typeOverride != null)
                    {
                        result.RequestBodyType = new SimpleBodyModel(typeOverride.Type);
                        if (typeOverride.Import != null)
                            result.Imports.Add(typeOverride.Import);
                    }
                }
            }

            foreach (var (response, responseItem) in operationItem.Responses)
            {
                if (responseItem is null)
                    throw new CaffoaParserException(
                        $"Missing Response configuration for Response '{response}' (maybe a wrong reference?)");
                result.DocumentationLines.Add($"{response} -> {responseItem.Description}");
                result.Responses.Add(ParseResponse(response, responseItem));
            }

            if (_config.DurableClient != null && _config.DurableClient.Contains(operation, operationItem))
            {
                result.DurableClient = true;
            }
        }
        catch (CaffoaParserException e)
        {
            throw new CaffoaParserException(
                $"Error during parsing of operation {operationItem.OperationId} ({operation} {path}): {e.Message}", e);
        }

        return result;
    }

    private IBodyModel ParseRequestBody(OpenApiRequestBody body)
    {
        if (body.Content.Count > 1)
            throw new CaffoaParserException("Multiple possible bodies");
        var (type, content) = body.Content.First();
        if (type.ToLower() != "application/json")
        {
            Console.Error.WriteLine(
                $"type {type}. Only application/json is currently supported for content, found {type.ToLower()}. Stream is used for body");
            return new NullBodyModel();
        }

        if (content.Schema is null)
            return new NullBodyModel();
        if (content.Schema.OneOf.Count > 0)
        {
            var discriminator = content.Schema.Discriminator;
            if (discriminator is null)
                throw new CaffoaParserException("Need discriminator in oneOf");
            var mapping = discriminator.Mapping.ToDictionary(i => i.Value, i => i.Key);
            var result = new SelectionBodyModel(discriminator.PropertyName);
            if (content.Schema.OneOf.Any(s => s.Reference is null))
                throw new CaffoaParserException("Cannot have oneOf without ref types");

            foreach (var reference in content.Schema.OneOf.Select(s => s.Reference))
            {
                if (!mapping.TryGetValue(reference.ReferenceV3, out var mapName))
                    mapName = reference.Name();
                var typeName = _classNameFunc(reference.Name());
                result.Mapping[mapName] = typeName;
            }

            return result;
        }

        return new SimpleBodyModel(ParseType(content.Schema));
    }

    private string ParseType(OpenApiSchema schema)
    {
        if (schema.IsArray())
            return $"IEnumerable<{schema.GetArrayType(_classNameFunc, _knownTypes)}>";
        if (schema.Reference != null)
            return _classNameFunc(schema.Reference.Name());
        if (schema.IsPrimitiveType())
            return schema.TypeName();
        if (schema.AdditionalProperties != null && !schema.Properties.Any())
        {
            var innerType = ParseType(schema.AdditionalProperties);
            return $"IEnumerable<KeyValuePair<string, {innerType}>>";
        }

        throw new CaffoaParserException("complex type. Only array, ref or basic types are supported.");
    }


    private ResponseModel ParseResponse(string code, OpenApiResponse responseItem)
    {
        var response = new ResponseModel(code);
        if (responseItem.Content.Count > 1)
        {
            Console.Error.WriteLine(
                $"WARNING: Multiple possible responses. Only a single application/json response is currently supported for objects.");
            response.Unknown = true;
            return response;
        }

        if (responseItem.Content.Count == 0)
            return response;
        var (type, content) = responseItem.Content.First();
        if (type.ToLower() != "application/json")
        {
            Console.Error.WriteLine(
                $"WARNING: found content type {type}. Only application/json is currently supported for objects.");
            response.Unknown = true;
            return response;
        }

        var schema = content?.Schema;
        if (schema is null)
        {
            response.Unknown = true;
            return response;
        }

        response.TypeName = ParseType(schema);
        return response;
    }

    public static List<ParameterObject> ParseParameter(IList<OpenApiParameter> parameters)
    {
        return parameters.Where(p => p.In is ParameterLocation.Path or ParameterLocation.Query)
            .Select(p =>
            {
                var defaultValue = p.Schema.DefaultAsString();
                p.Schema.Nullable = !p.Required && defaultValue == null;
                var result = new ParameterObject(p.Name, p.Schema.TypeName(), p.Description,
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