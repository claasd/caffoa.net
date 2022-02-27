using CdIts.Caffoa.Cli.Errors;

namespace CdIts.Caffoa.Cli.Config;

public class ModelConfig
{
    private string? _ns;
    private string? _targetFolder;

    public string Namespace
    {
        get => _ns ?? throw new ConfigurationMissingError("Missing 'namespace' of configuration 'model'");
        set => _ns = value;
    }

    public string TargetFolder
    {
        get => _targetFolder ?? throw new ConfigurationMissingError("Missing 'targetFolder' of configuration 'model'");
        set => _targetFolder = value;
    }

    public List<string> Excludes { get; set; } = new();
    public List<string> Includes { get; set; } = new();
    public List<string> Imports { get; set; } = new();
}
