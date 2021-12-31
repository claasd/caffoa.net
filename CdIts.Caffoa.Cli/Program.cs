// See https://aka.ms/new-console-template for more information

using CdIts.Caffoa.Cli;
using CdIts.Caffoa.Cli.Config;
using CdIts.Caffoa.Cli.Errors;
using CdIts.Caffoa.Cli.Generator;
using CdIts.Caffoa.Cli.Parser;
using CommandLine;
using YamlDotNet.Core;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using Parser = CommandLine.Parser;

var configPath = "";

Parser.Default.ParseArguments<CommandLineOptions>(args)
    .WithParsed(o =>
    {
        configPath = o.ConfigPath;
    });
try
{
    var deserializer = new DeserializerBuilder()
        .WithNamingConvention(CamelCaseNamingConvention.Instance)
        .Build();
    using var reader = File.OpenText(configPath);
    var settings = deserializer.Deserialize<CaffoaSettings>(reader);
    if (settings.Config.ClearGeneratedFiles)
    {
        var files = Directory.GetFiles(".", "*.generated.cs", SearchOption.AllDirectories);
        foreach (var file in files)
        {
            File.Delete(file);    
        }
        
    }
        
    foreach (var service in settings.Services)
    {
        try
        {
            var localConfig = service.Config?.MergedWith(settings.Config) ?? settings.Config;
            var parser = new ServiceParser(service, localConfig);

            if (service.Model != null)
            {
                var generator = new ModelGenerator(service, localConfig);
                var objects = parser.GenerateModel();
                generator.WriteModel(objects);
            }

            if (service.Function != null)
            {
                var endpoints = parser.GenerateEndpoints();
                var interfaceGenerator =
                    new InterfaceGenerator(service.Function, service.Model?.Namespace);
                interfaceGenerator.GenerateInterface(endpoints);
                var functionsGenerator =
                    new FunctionsGenerator(service.Function, localConfig, service.Model?.Namespace);
                functionsGenerator.GenerateFunctions(endpoints);
            }
        }
        catch (ConfigurationMissingError e)
        {
            throw new ConfigurationMissingError(e.Message + $" for '{service.ApiPath}'");
        }
    }
}
catch (YamlException e)
{
    var msg = (e.InnerException ?? e).Message;
    Console.Error.WriteLine($"Error in your configuration file (Line: {e.Start.Line}): {msg}");
    return 1;
}
catch (ConfigurationMissingError e)
{
    Console.Error.WriteLine($"Error in your configuration file: " + e.Message);
    return 1;
}
catch (CaffoaValidationError e)
{
    Console.Error.WriteLine(e.Message);
    foreach (var error in e.Diagnostic.Errors)
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