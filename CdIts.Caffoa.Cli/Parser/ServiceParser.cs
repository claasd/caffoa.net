using CdIts.Caffoa.Cli.Config;
using CdIts.Caffoa.Cli.Errors;
using CdIts.Caffoa.Cli.Model;
using Microsoft.Extensions.Logging;
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
    private readonly ILogger _logger;
    private static readonly List<string> Duplicates = new();
    public OpenApiDocument Document { get; private set; } = new();
    public string ApiName { get; private set; } = "";

    public ServiceParser(ServiceConfig service, CaffoaGlobalConfig config, ILogger logger)
    {
        _service = service;
        _config = config;
        _logger = logger;
    }

    public async Task ReadAsync()
    {
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


    public List<Server> GenerateServers()
    {
        var servers = new List<Server>();
        if (Document!.Servers is null)
            return servers;
        servers.AddRange(Document!.Servers.Select(openapi => new Server(openapi.Url)));
        return servers;
    }

    public List<SchemaItem> GenerateModel()
    {
        var schemas = Document!.Components.Schemas;
        if (_service.Model!.Includes != null && _service.Model.Includes.Any())
            schemas = schemas.Where(p => _service.Model.Includes.Contains(p.Key))
                .ToDictionary(p => p.Key, p => p.Value);
        if (_service.Model.Excludes != null)
            schemas = schemas.Where(p => !_service.Model.Excludes.Contains(p.Key))
                .ToDictionary(p => p.Key, p => p.Value);
        var objects = ParseObjects(schemas);
        objects.ForEach(o => o.Namespace = _service.Model.Namespace);
        return objects;
    }

    public List<EndPointModel> GenerateEndpoints()
    {
        var endpoints = new List<EndPointModel>();
        var parser = new PathParser(_config, ClassName, _logger);
        foreach (var (path, pathItem) in Document!.Paths)
        {
            endpoints.AddRange(parser.Parse(path, pathItem));
        }

        return endpoints;
    }


    private List<SchemaItem> ParseObjects(IDictionary<string, OpenApiSchema> schemas)
    {
        var objects = new List<SchemaItem>();
        bool nullableIsDefault = _config.NullableIsDefault ?? true;
        foreach (var (name, apiSchema) in schemas)
        {
            var className = ClassName(name);
            if (_config.Duplicates == "once" && Duplicates.Contains(className))
                continue;
            if(apiSchema.IsArray() && _config.ParseArrayTypes is not true)
                continue;
            if (!apiSchema.IsArray() && !apiSchema.IsRealObject(_config.GetEnumCreationMode()))
                continue;
            
            ObjectParser parser = _config.UseInheritance is true
                ? new ObjectInheritanceParser(new SchemaItem(name, className), _config.GetEnumCreationMode(), ClassName, nullableIsDefault)
                : new ObjectStandaloneParser(new SchemaItem(name, className), _config.GetEnumCreationMode(), ClassName, nullableIsDefault);
            var item = parser.Parse(apiSchema, _logger);
            foreach (var property in item.Properties ?? new List<PropertyData>())
            {
                if (property.FieldName == item.ClassName)
                    property.FieldName += "_";
            }
            objects.Add(item);
            
            Duplicates.Add(item.ClassName);
        }

        return objects;
    }

    private string ClassName(string name)
    {
        return _service.Config?.Prefix + name.ToObjectName() + _service.Config?.Suffix;
    }
}