// See https://aka.ms/new-console-template for more information

using CdIts.Caffoa.Cli;
using CdIts.Caffoa.Cli.Config;
using CdIts.Caffoa.Cli.Errors;
using CommandLine;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using YamlDotNet.Core;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using Parser = CommandLine.Parser;

using ILoggerFactory loggerFactory =
    LoggerFactory.Create(builder =>
        builder.AddSimpleConsole(options =>
        {
            options.IncludeScopes = false;
            options.SingleLine = true;
            options.TimestampFormat = "HH:mm:ss ";
        }));

ILogger logger = loggerFactory.CreateLogger<Program>();

try
{
    CommandLineOptions options = new CommandLineOptions();
    Parser.Default.ParseArguments<CommandLineOptions>(args)
        .WithParsed(o => options = o);
    if (options.InitWithFile != null)
    {
        Main.InitProject(options.InitWithFile, options.InitProjectName, options.ConfigPath);
        return 0;
    }
    
    var deserializer = new DeserializerBuilder()
        .WithNamingConvention(CamelCaseNamingConvention.Instance)
        .Build();
    using var reader = File.OpenText(options.ConfigPath);
    var settings = deserializer.Deserialize<CaffoaSettings>(reader);
    var main = new Main(settings, logger);
    var builders = await main.GenerateBuilders();

    if (settings.Config.ClearGeneratedFiles)
    {
        var files = Directory.GetFiles(".", "*.generated.cs", SearchOption.AllDirectories);
        foreach (var file in files)
        {
            File.Delete(file);
        }
    }

    main.GenerateCode(builders);
}
catch (YamlException e)
{
    var msg = (e.InnerException ?? e).Message;
    logger.LogCritical($"Error in your configuration file (Line: {e.Start.Line}): {msg}");
    return 1;
}
catch (ConfigurationMissingException e)
{
    logger.LogCritical($"Error in your configuration file: " + e.Message);
    return 1;
}
catch (CaffoaValidationException e)
{
    logger.LogCritical(e.Message);
    foreach (var error in e.Diagnostic?.Errors ?? new List<OpenApiError>())
    {
        logger.LogCritical(error.ToString());
    }
}
catch (Exception e)
{
    logger.LogCritical(e.Message);
#if DEBUG
    throw;
#else
    return 1;
#endif
}

return 0;