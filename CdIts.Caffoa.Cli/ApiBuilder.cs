using CdIts.Caffoa.Cli.Config;
using CdIts.Caffoa.Cli.Generator;
using CdIts.Caffoa.Cli.Model;
using CdIts.Caffoa.Cli.Parser;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace CdIts.Caffoa.Cli;

public class ApiBuilder
{
    private readonly ServiceConfig _service;
    private readonly ILogger _logger;
    public CaffoaGlobalConfig Config { get; }
    private List<EndPointModel>? _endpoints;
    private readonly ServiceParser _parser;
    public IEnumerable<string> ExtensionData { get; private set; } = Array.Empty<string>();
    public string ExtensionNamespace => _service.Model!.Namespace;
    public string ExtensionFolder => _service.Model!.TargetFolder;

    public List<string> ExtensionImports
    {
        get
        {
            var imports = new List<string>();

            if (Config.Imports != null)
                imports.AddRange(Config.Imports);
            if (_service.Model?.Imports != null)
                imports.AddRange(_service.Model.Imports);
            return imports;
        }
    }

    public string ApiName => _parser.ApiName;
    public OpenApiDocument Document => _parser.Document;
    public List<SchemaItem>? Models { get; private set; }


    public ApiBuilder(ServiceConfig service, CaffoaGlobalConfig config, ILogger logger)
    {
        _service = service;
        _logger = logger;
        Config = config;
        _parser = new ServiceParser(_service, Config, _logger);
    }

    public async Task Parse()
    {
        await _parser.ReadAsync();
        if (_service.Model != null)
            Models = _parser.GenerateModel();
        if (_service.Function != null || _service.Client != null)
            _endpoints = _parser.GenerateEndpoints();
    }

    public void Generate(Dictionary<string, OpenApiDocument> allDocuments, List<SchemaItem> otherKnownObjects)
    {
        if (_service.Model != null && Models != null)
        {
            var generator = new ModelGenerator(_service, Config, _logger);
            ExtensionData = generator.WriteModel(Models, otherKnownObjects);
        }

        if (_service.Function != null && _endpoints != null)
        {
            var interfaceGenerator =
                new InterfaceGenerator(_service.Function, Config, _service.Model?.Namespace, _logger);
            interfaceGenerator.GenerateInterface(_endpoints);
            var functionsGenerator =
                new FunctionsGenerator(_service.Function, Config, _service.Model?.Namespace);
            functionsGenerator.GenerateFunctions(_endpoints);
        }
        
        if (_service.Client != null && _endpoints != null)
        {
            var clientGenerator = new ClientGenerator(_service.Client, Config, _service.Model?.Namespace, _logger);
            clientGenerator.GenerateClient(_endpoints);
        }

        if (Config.GenerateResolvedApiFile is true)
            _parser.WriteGeneratedApiFile(allDocuments);
    }
}
