// ReSharper disable UnusedAutoPropertyAccessor.Global

using CommandLine;


namespace CdIts.Caffoa.Cli;

public class CommandLineOptions
{
    [Option(HelpText = "Path To Caffoa config file", Default = "./caffoa.yml")]
    public string ConfigPath { get; set; } = "";

    [Option(SetName="run", HelpText = "Output Path", Default = ".")]
    public string OutputPath { get; set; } = ".";
    
    [Option(SetName="init", HelpText = "Create a new config file for this file")]
    public string? InitWithFile { get; set; }

    [Option(SetName = "init", HelpText = "Project Name", Default = "MyFunction")]
    public string InitProjectName { get; set; } = "MyFunction";
}
// ReSharper enable UnusedAutoPropertyAccessor.Global
