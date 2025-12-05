using CdIts.Caffoa.Cli.Config;
using CdIts.Caffoa.Cli.Errors;
using CdIts.Caffoa.Cli.Model;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace CdIts.Caffoa.Cli.Parser;

public class PathParser
{
    private readonly CaffoaConfig _config;
    private readonly Func<string, string> _classNameFunc;
    private readonly ILogger _logger;
    private readonly List<string> _contentTypes;

    public PathParser(CaffoaConfig config, Func<string, string> classNameFunc, ILogger logger)
    {
        _config = config;
        _classNameFunc = classNameFunc;
        _logger = logger;
        _contentTypes = new List<string> {"application/json"};
        if(config.JsonContentTypes != null)
            _contentTypes.AddRange(config.JsonContentTypes);
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
        var tags = operationItem.Tags.Select(t => t.Name).ToArray();
        var result = new EndPointModel(operation.ToString(), name, path.Trim('/'), tags);
        result.Deprecated = operationItem.Deprecated;
        result.DeprecatedAsError = operationItem.Extensions.ParseCaffoaOption("x-caffoa-deprecate-as-error") ?? false;
        result.Description = operationItem.Description;
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
                    var typeOverride = _config.RequestBodyType.Find(requestConfig =>
                        requestConfig.Filter.Contains(operation, operationItem));
                    if (typeOverride != null)
                    {
                        result.RequestBodyType = new SimpleBodyModel(typeOverride.Type, typeOverride.ContentType);
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
                var resolvedResponseItem = ResolveExternal(responseItem);
                result.DocumentationLines.Add($"{response} -> {resolvedResponseItem.Description}");
                result.Responses.Add(ParseResponse(response, resolvedResponseItem));
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
        {
            _logger.LogWarning(
                $"Found multiple schemas for requestBody. Only a single application/json body is currently supported. Stream is used for body.");
            return new NullBodyModel();
        }

        var (type, content) = body.Content.First();
        if (!_contentTypes.Contains(type, StringComparer.OrdinalIgnoreCase))
        {
            _logger.LogWarning(
                $"Found requestBody type {type}. Only application/json and additionally configured content types are currently supported for content, found {type.ToLower()}. Stream is used for body");
            return new NullBodyModel();
        }
        
        if (content.Schema is null)
            return new NullBodyModel(type);
        if (content.Schema.OneOf.Count > 0)
        {
            var discriminator = content.Schema.Discriminator;
            if (discriminator is null)
                _logger.LogWarning("No discriminator in oneOf, function generation might fail");
            var mapping = discriminator?.Mapping?.ToDictionary(i => i.Value, i => i.Key);
            var result = new SelectionBodyModel(discriminator?.PropertyName ?? "type", type);
            if (content.Schema.OneOf.Any(s => s.Reference is null))
                throw new CaffoaParserException("Cannot have oneOf without ref types");

            foreach (var reference in content.Schema.OneOf.Select(s => s.Reference))
            {
                if (mapping is null || !mapping.TryGetValue(reference.ReferenceV3, out var mapName))
                    mapName = reference.Name();
                var typeName = _classNameFunc(reference.Name());
                result.Mapping[mapName] = typeName;
            }

            return result;
        }
        var schemaType = ParseType(content.Schema);
        if(schemaType =="byte[]")
            return new NullBodyModel(type);
        return new SimpleBodyModel(schemaType, type);
    }

    private string ParseType(OpenApiSchema schema)
    {
        if (schema.IsArray())
            return $"IEnumerable<{schema.GetArrayType(_classNameFunc, _config.GetEnumCreationMode())}>";
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

    private OpenApiResponse ResolveExternal(OpenApiResponse response)
    {
        if (response.Reference?.IsExternal ?? false)
        {
            var result = response.Reference.HostDocument.Workspace.ResolveReference(response.Reference);
            if (result is OpenApiResponse r)
                return r;
        }

        return response;
    }

    private ResponseModel ParseResponse(string code, OpenApiResponse responseItem)
    {
        var response = new ResponseModel(code);
        if (responseItem.Content.Count > 1)
        {
            _logger.LogWarning(
                $"Multiple possible responses found. Only a single application/json response is currently supported for objects. Using IActionResult as return value");
            response.Unknown = true;
            return response;
        }

        if (responseItem.Content.Count == 0)
            return response;
        var (type, content) = responseItem.Content.First();
        if (!_contentTypes.Contains(type, StringComparer.OrdinalIgnoreCase))
        {
            _logger.LogWarning(
                $"found content type {type} for response. Only application/json and additionally configured content types are currently supported for objects. Using IActionResult as return value");
            response.Unknown = true;
            return response;
        }

        var schema = content?.Schema;
        if (schema is null)
        {
            response.Unknown = true;
            return response;
        }

        try
        {
            response.TypeName = ParseType(schema);
        }
        catch (CaffoaParserException e)
        {
            _logger.LogWarning(e.Message);
            response.Unknown = true;
        }
        if(response.TypeName == "byte[]")
            response.Unknown = true;
        return response;
    }

    public List<ParameterObject> ParseParameter(IList<OpenApiParameter> parameters)
    {
        return parameters.Where(p => p.In is ParameterLocation.Path or ParameterLocation.Query)
            .Select(p =>
            {
                var schema = ObjectParser.ResolveExternal(p.Schema);
                var defaultValue = schema.DefaultAsString();
                schema.Nullable = !p.Required && defaultValue == null;
                var type = schema.TypeName();
                var isEnum = false;
                var arrayType = ParameterArrayType.NoArray;
                string? innerType = null;
                if (schema.Reference != null && schema.CanBeEnum() && _config.GetEnumCreationMode() <= CaffoaConfig.EnumCreationMode.Default)
                {
                    type = _classNameFunc(schema.Reference.Name());
                    if (schema.Nullable)
                        type += "?";
                    isEnum = true;
                }
                else if (schema.IsArray())
                {
                    var items = ObjectParser.ResolveExternal(schema.Items);
                    if (items.Reference != null && items.CanBeEnum() &&
                        _config.GetEnumCreationMode() <= CaffoaConfig.EnumCreationMode.Default)
                    {
                        innerType = _classNameFunc(items.Reference.Name());
                        type = $"ICollection<{innerType}>";
                        arrayType = ParameterArrayType.EnumArray;
                    }
                    else if (items.Reference is null && items.Type == "string")
                    {
                        arrayType = ParameterArrayType.StringArray;
                        innerType = "string";
                        type = $"ICollection<{innerType}>";
                    }
                    else if (items.Reference is null && items.Type == "integer")
                    {
                        arrayType = ParameterArrayType.IntArray;
                        innerType = "integer";
                        type = $"ICollection<{innerType}>";
                    }
                    else
                    {
                        type = "string";
                    }
                }

                var result = new ParameterObject(p.Name, type, p.Description,
                    p.In == ParameterLocation.Query)
                {
                    DefaultValue = defaultValue,
                    Required = p.Required,
                    IsEnum = isEnum,
                    ArrayType = arrayType,
                    InnerType = innerType
                };
                return result;
            })
            .ToList();
    }
}