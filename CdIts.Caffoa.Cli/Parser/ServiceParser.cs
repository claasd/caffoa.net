using System.Globalization;
using CdIts.Caffoa.Cli.Config;
using CdIts.Caffoa.Cli.Model;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Readers;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace CdIts.Caffoa.Cli;

public class ServiceParser
{
    private readonly ServiceConfig _service;
    private readonly OpenApiDocument _document;
    private readonly Dictionary<string, OpenApiSchema> _knownTypes = new();

    public ServiceParser(ServiceConfig service)
    {
        _service = service;
        using var reader = File.OpenRead(service.ApiPath);
        _document = new OpenApiStreamReader(new OpenApiReaderSettings() { }).Read(reader, out var diagnostic);
    }

    public List<SchemaItem> GenerateModel()
    {
        var schemas = _document.Components.Schemas;
        // TODO: Handle includes / excludes
        ParseSimpleTypes(schemas);
        return ParseObjects(schemas);
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
            if(_knownTypes.ContainsKey(className))
                continue;
            var parser = new ObjectParser(new SchemaItem(name, className), _knownTypes, ClassName);
            objects.Add(parser.Parse(apiSchema));
        }

        return objects;
    }

    private string ClassName(string name)
    {
        return _service.Config?.Prefix + name.ToCamelCase() + _service.Config?.Suffix;
    }

    
}