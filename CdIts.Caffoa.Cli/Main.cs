﻿using CdIts.Caffoa.Cli.Config;
using CdIts.Caffoa.Cli.Errors;
using CdIts.Caffoa.Cli.Generator;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace CdIts.Caffoa.Cli;

public class Main
{
    private readonly CaffoaSettings _settings;
    public Main(CaffoaSettings settings)
    {
        _settings = settings;
    }

    public static void InitProject(string apiPath, string projectName, string configPath)
    {
        var serializer = new SerializerBuilder().WithNamingConvention(CamelCaseNamingConvention.Instance).ConfigureDefaultValuesHandling(DefaultValuesHandling.OmitDefaults).Build();
        var defaultConfig = new CaffoaSettings()
        {
            Config = new CaffoaGlobalConfig(false)
            {
                SplitByTag = null,
            }
        };
        defaultConfig.Services.Add(new ServiceConfig()
        {
            ApiPath = apiPath,
            Function = new FunctionConfig()
            {
                Name = projectName,
                Namespace = projectName,
                TargetFolder = projectName
            },
            Model = new ModelConfig()
            {
                Namespace = projectName + ".Model",
                TargetFolder = projectName + "/Model"
            }
        });
        using var stream = new StreamWriter(configPath);
        serializer.Serialize(stream, defaultConfig);
    }

    
    public async Task<List<ApiBuilder>> GenerateBuilders()
    {

        var builders = new List<ApiBuilder>();
        foreach (var service in _settings.Services)
        {
            try
            {
                var localConfig = service.Config?.MergedWith(_settings.Config) ?? _settings.Config;
                var builder = new ApiBuilder(service, localConfig);
                await builder.Parse();
                builders.Add(builder);
            }
            catch (ConfigurationMissingException e)
            {
                throw new ConfigurationMissingException(e.Message + $" for '{service.ApiPath}'");
            }
        }

        return builders;
    }

    public void GenerateCode(List<ApiBuilder> builders)
    {
        var extensionGenerators = new List<ExtensionGenerator>();
        var allDocuments = builders.GroupBy(b => b.ApiName, b => b.Document).ToDictionary(g => g.Key, g => g.First());
        foreach (var builder in builders)
        {
            var otherModels = builders.Where(b => b != builder && b.Models != null).SelectMany(b => b.Models!);
            builder.Generate(allDocuments, otherModels);
            if (builder.ExtensionData.Any())
            {
                var generator = extensionGenerators.FirstOrDefault(g =>
                    g.Folder == builder.ExtensionFolder && g.Namespace == builder.ExtensionNamespace);
                if (generator is null)
                {
                    generator = new ExtensionGenerator(builder.ExtensionFolder, builder.ExtensionNamespace);
                    extensionGenerators.Add(generator);
                }

                generator.Add(builder.ExtensionData, builder.ExtensionImports);
            }
        }
        extensionGenerators.ForEach(g => g.Create());
    }
}