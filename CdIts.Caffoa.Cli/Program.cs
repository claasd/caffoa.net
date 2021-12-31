// See https://aka.ms/new-console-template for more information

using CdIts.Caffoa.Cli;
using CdIts.Caffoa.Cli.Config;
using CdIts.Caffoa.Cli.Generator;
using CommandLine;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

CommandLine.Parser.Default.ParseArguments<CommandLineOptions>(args)
    .WithParsed(o =>
    {
        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .Build();
        using var reader = File.OpenText(o.ConfigPath);
        var settings = deserializer.Deserialize<CaffoaSettings>(reader);
        foreach (var service in settings.Services)
        {
            var parser = new ServiceParser(service);
            var generator = new ServiceGenerator(service);
            if (service.Model != null)
            {
                var objects = parser.GenerateModel();
                var localConfig = service.Config?.MergedWith(settings.Config) ?? settings.Config;
                generator.WriteModel(objects, localConfig);

            }
        }
    });