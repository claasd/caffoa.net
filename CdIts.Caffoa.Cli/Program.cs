// See https://aka.ms/new-console-template for more information

using CdIts.Caffoa.Cli;
using CdIts.Caffoa.Cli.Config;
using CdIts.Caffoa.Cli.Errors;
using CdIts.Caffoa.Cli.Generator;
using CommandLine;
using Microsoft.OpenApi.Models;
using YamlDotNet.Core;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using Parser = CommandLine.Parser;

CommandLineOptions options = new CommandLineOptions(); 
Parser.Default.ParseArguments<CommandLineOptions>(args)
    .WithParsed(o => options = o);
try
{
    if (options.InitWithFile != null)
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
            ApiPath = options.InitWithFile,
            Function = new FunctionConfig()
            {
                Name = options.InitProjectName,
                Namespace = options.InitProjectName,
                TargetFolder = options.InitProjectName
            },
            Model = new ModelConfig()
            {
            Namespace = options.InitProjectName + ".Model",
            TargetFolder = options.InitProjectName + "/Model"
        }
        });
        using var stream = new StreamWriter(options.ConfigPath);
        serializer.Serialize(stream, defaultConfig);
        return 0;
    }
    var deserializer = new DeserializerBuilder()
        .WithNamingConvention(CamelCaseNamingConvention.Instance)
        .Build();
    using var reader = File.OpenText(options.ConfigPath);
    var settings = deserializer.Deserialize<CaffoaSettings>(reader);

    var builders = new List<ApiBuilder>();
    foreach (var service in settings.Services)
    {
        try
        {
            var localConfig = service.Config?.MergedWith(settings.Config) ?? settings.Config;
            var builder = new ApiBuilder(service, localConfig);
            builder.Parse();
            builders.Add(builder);
        }
        catch (ConfigurationMissingException e)
        {
            throw new ConfigurationMissingException(e.Message + $" for '{service.ApiPath}'");
        }
    }

    if (settings.Config.ClearGeneratedFiles)
    {
        var files = Directory.GetFiles(".", "*.generated.cs", SearchOption.AllDirectories);
        foreach (var file in files)
        {
            File.Delete(file);
        }
    }

    var extensionGenerators = new List<ExtensionGenerator>();
    foreach (var builder in builders)
    {
        builder.Generate(builders.GroupBy(b=>b.ApiName,b=>b.Document).ToDictionary(g=>g.Key, g=>g.First()));
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
catch (YamlException e)
{
    var msg = (e.InnerException ?? e).Message;
    Console.Error.WriteLine($"Error in your configuration file (Line: {e.Start.Line}): {msg}");
    return 1;
}
catch (ConfigurationMissingException e)
{
    Console.Error.WriteLine($"Error in your configuration file: " + e.Message);
    return 1;
}
catch (CaffoaValidationException e)
{
    Console.Error.WriteLine(e.Message);
    foreach (var error in e.Diagnostic?.Errors ?? new List<OpenApiError>())
    {
        Console.Error.WriteLine(error.ToString());
    }
}
catch (Exception e)
{
    Console.Error.WriteLine(e.Message);
#if DEBUG
    throw;
#else
    return 1;
#endif
}

return 0;
