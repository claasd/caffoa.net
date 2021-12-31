using CdIts.Caffoa.Cli.Config;
using CdIts.Caffoa.Cli.Errors;
using CdIts.Caffoa.Cli.Model;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Readers;

namespace CdIts.Caffoa.Cli.Parser;

public class ServiceParser
{
    private readonly ServiceConfig _service;
    private readonly CaffoaGlobalConfig _config;
    private OpenApiDocument _document;
    private readonly Dictionary<string, OpenApiSchema> _knownTypes = new();
    public static List<string> Duplicates = new();
    public ServiceParser(ServiceConfig service, CaffoaGlobalConfig config)
    {
        _service = service;
        _config = config;
        using var fileStream = File.OpenRead(_service.ApiPath);
        _document = new OpenApiStreamReader().Read(fileStream, out var diagnostic);
        if (diagnostic.Errors.Count > 0)
        {
            throw new CaffoaValidationError($"Error parsing {service.ApiPath}", diagnostic);
        }
    }

    public List<SchemaItem> GenerateModel()
    {
        var schemas = _document.Components.Schemas;
        if (_service.Model!.Includes.Count > 0)
            schemas = schemas.Where(p => _service.Model.Includes.Contains(p.Key)).ToDictionary(p => p.Key, p => p.Value);
        schemas = schemas.Where(p => !_service.Model.Excludes.Contains(p.Key)).ToDictionary(p => p.Key, p => p.Value);
        ParseSimpleTypes(schemas);
        return ParseObjects(schemas);
    }

    public List<EndPointModel> GenerateEndpoints()
    {
        var endpoints = new List<EndPointModel>();
        var parser = new PathParser(_config, ClassName);
        foreach(var (path, pathItem) in _document.Paths)
        {
            endpoints.AddRange(parser.Parse(path, pathItem));
        }
        return endpoints;
    }
    
    private void ParseSimpleTypes(IDictionary<string, OpenApiSchema> schemas)
    {
        foreach (var (name, apiSchema) in schemas)
        {
            if (!apiSchema.IsPrimitiveType())
                continue;
            var className = ClassName(name);
            _knownTypes[className] = apiSchema;
        }
    }

    private List<SchemaItem> ParseObjects(IDictionary<string, OpenApiSchema> schemas)
    {
        var objects = new List<SchemaItem>();
        foreach (var (name, apiSchema) in schemas)
        {
            var className = ClassName(name);
            if (_config.Duplicates == "once" && Duplicates.Contains(className))
                continue;
            if (_knownTypes.ContainsKey(className))
                continue;
            var parser = new ObjectParser(new SchemaItem(name, className), _knownTypes, ClassName);
            objects.Add(parser.Parse(apiSchema));
            Duplicates.Add(className);
        }

        return objects;
    }

    private string ClassName(string name)
    {
        return _service.Config?.Prefix + name.ToCamelCase() + _service.Config?.Suffix;
    }
}