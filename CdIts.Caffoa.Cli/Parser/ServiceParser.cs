using CdIts.Caffoa.Cli.Config;
using CdIts.Caffoa.Cli.Errors;
using CdIts.Caffoa.Cli.Model;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Extensions;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Readers;
using Microsoft.OpenApi.Services;
using Microsoft.OpenApi.Writers;

namespace CdIts.Caffoa.Cli.Parser;

public class ServiceParser
{
    private readonly ServiceConfig _service;
    private readonly CaffoaGlobalConfig _config;
    private readonly Dictionary<string, OpenApiSchema> _knownTypes = new();
    private static readonly List<string> Duplicates = new();
    public OpenApiDocument Document { get; private set; } = new();
    public string ApiName { get; private set; } = "";

    public ServiceParser(ServiceConfig service, CaffoaGlobalConfig config)
    {
        _service = service;
        _config = config;
    }
    
    public async Task ReadAsync() {

        Uri baseUri;
        Stream? input = null;
        try
        {
            if (_service.ApiPath.StartsWith("http"))
            {
                input = new HttpClient().GetStreamAsync(_service.ApiPath).Result;
                ApiName = _service.ApiPath;
                baseUri = new Uri(_service.ApiPath.Substring(0, _service.ApiPath.LastIndexOf('/')));
            }
            else
            {
                input = File.OpenRead(_service.ApiPath);
                ApiName = Path.GetFileName(_service.ApiPath);
                baseUri = new Uri(Path.GetDirectoryName(Path.GetFullPath(_service.ApiPath))!);
            }

            if (!baseUri.AbsoluteUri.EndsWith('/'))
                baseUri = new Uri($"{baseUri.AbsoluteUri}/");

            var reader = new OpenApiStreamReader(new OpenApiReaderSettings()
            {
                CustomExternalLoader = null,
                LoadExternalRefs = true,
                BaseUrl = baseUri
            });
            var readResult = await reader.ReadAsync(input);
            
            if (readResult.OpenApiDiagnostic.Errors.Count > 0)
            {
                throw new CaffoaValidationException($"Error parsing {_service.ApiPath}", readResult.OpenApiDiagnostic);
            }
            Document = readResult.OpenApiDocument;
        }
        finally
        {
            input?.Close();
        }
    }

    public void WriteGeneratedApiFile(Dictionary<string, OpenApiDocument> allDocuments)
    {
        var path = Path.ChangeExtension(_service.ApiPath, "generated.yml");
        using var fileStream = File.OpenWrite(path);
        var workspace = new OpenApiWorkspace();
        foreach (var (name, doc) in allDocuments)
        {
            workspace.AddDocument(name, doc);
        }
        workspace.AddDocument("root", Document);
        Document.Serialize(fileStream, OpenApiSpecVersion.OpenApi3_0, OpenApiFormat.Yaml, new OpenApiWriterSettings()
        {
            InlineExternalReferences = true,
            InlineLocalReferences = true
        });
    }

    public List<SchemaItem> GenerateModel()
    {
        var schemas = Document!.Components.Schemas;
        ParseSimpleTypes(schemas);
        if (_service.Model!.Includes != null && _service.Model.Includes.Any())
            schemas = schemas.Where(p => _service.Model.Includes.Contains(p.Key))
                .ToDictionary(p => p.Key, p => p.Value);
        if (_service.Model.Excludes != null)
            schemas = schemas.Where(p => !_service.Model.Excludes.Contains(p.Key))
                .ToDictionary(p => p.Key, p => p.Value);
        var objects = ParseObjects(schemas);
        objects.ForEach(o=>o.Namespace = _service.Model.Namespace);
        return objects;
    }

    public List<EndPointModel> GenerateEndpoints()
    {
        var endpoints = new List<EndPointModel>();
        var parser = new PathParser(_config, ClassName, _knownTypes);
        foreach (var (path, pathItem) in Document!.Paths)
        {
            endpoints.AddRange(parser.Parse(path, pathItem));
        }
        return endpoints;
    }

    private void ParseSimpleTypes(IDictionary<string, OpenApiSchema> schemas)
    {
        foreach (var (name, apiSchema) in schemas)
        {
            if (!apiSchema.IsPrimitiveType() && !apiSchema.HasOnlyAdditionalProperties())
                continue;
            if(apiSchema.CanBeEnum() && _config.GetEnumCreationMode() == CaffoaConfig.EnumCreationMode.Default)
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
            ObjectParser parser = _config.UseInheritance is true
                ? new ObjectInheritanceParser(new SchemaItem(name, className), _knownTypes, ClassName)
                : new ObjectStandaloneParser(new SchemaItem(name, className), _knownTypes, ClassName);
            objects.Add(parser.Parse(apiSchema));
            Duplicates.Add(className);
        }

        return objects;
    }

    private string ClassName(string name)
    {
        return _service.Config?.Prefix + name.ToObjectName() + _service.Config?.Suffix;
    }
}