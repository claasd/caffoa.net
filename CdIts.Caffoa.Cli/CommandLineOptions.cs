// ReSharper disable UnusedAutoPropertyAccessor.Global
using CommandLine;


namespace CdIts.Caffoa.Cli;

public class CommandLineOptions
{
    [Option(HelpText = "Path To Caffoa config file", Default = "./caffoa.yml")]

    public string ConfigPath { get; set; } = "";

    [Option(HelpText = "Output Path", Default = ".")]
    public string OutputPath { get; set; } = ".";
}
// ReSharper enable UnusedAutoPropertyAccessor.Global