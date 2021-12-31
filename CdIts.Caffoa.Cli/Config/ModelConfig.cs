namespace CdIts.Caffoa.Cli.Config;

public class ModelConfig
{
    public string Namespace { get; set; }
    public string TargetFolder { get; set; }
    public List<string> Excludes { get; set; } = new();
    public List<string> Includes { get; set; } = new();
    public List<string> Imports { get; set; } = new();
}