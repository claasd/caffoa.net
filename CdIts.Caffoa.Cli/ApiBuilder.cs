using CdIts.Caffoa.Cli.Config;
using CdIts.Caffoa.Cli.Generator;
using CdIts.Caffoa.Cli.Model;
using CdIts.Caffoa.Cli.Parser;
using Microsoft.OpenApi.Models;

namespace CdIts.Caffoa.Cli;

public class ApiBuilder
{
    private readonly ServiceConfig _service;
    private readonly CaffoaGlobalConfig _config;
    private List<SchemaItem>? _model;
    private List<EndPointModel>? _endpoints;
    private readonly ServiceParser _parser;
    public IEnumerable<string>? ExtensionData { get; private set; }
    public string ExtensionNamespace => _service.Model!.Namespace;
    public string ExtensionFolder => _service.Model!.TargetFolder;

    public List<string> ExtensionImports
    {
        get
        {
            var imports = new List<string>();

            if (_config.Imports != null)
                imports.AddRange(_config.Imports);
            if (_service.Model?.Imports != null)
                imports.AddRange(_service.Model.Imports);
            return imports;
        }
    }

    public string ApiName => _parser.ApiName;
    public OpenApiDocument Document => _parser.Document;
    

    public ApiBuilder(ServiceConfig service, CaffoaGlobalConfig config)
    {
        _service = service;
        _config = config;
        _parser = new ServiceParser(_service, _config);
    }

    public void Parse()
    {
        if (_service.Model != null)
            _model = _parser.GenerateModel();
        if (_service.Function != null)
            _endpoints = _parser.GenerateEndpoints();
    }

    public void Generate(Dictionary<string, OpenApiDocument> allDocuments)
    {
        if (_service.Model != null && _model != null)
        {
            var generator = new ModelGenerator(_service, _config);
            ExtensionData = generator.WriteModel(_model);
        }

        if (_service.Function != null && _endpoints != null)
        {
            var interfaceGenerator =
                new InterfaceGenerator(_service.Function, _config, _service.Model?.Namespace);
            interfaceGenerator.GenerateInterface(_endpoints);
            var functionsGenerator =
                new FunctionsGenerator(_service.Function, _config, _service.Model?.Namespace);
            functionsGenerator.GenerateFunctions(_endpoints);
        }

        if (_config.GenerateResolvedApiFile is true)
            _parser.WriteGeneratedApiFile(allDocuments);
    }
}
