using System.Text.RegularExpressions;
using CdIts.Caffoa.Cli.Errors;

namespace CdIts.Caffoa.Cli.Config;

public class ModelConfig
{
    private string? _ns;
    private string? _targetFolder;

    public string Namespace
    {
        get => _ns ?? Regex.Replace(TargetFolder.Trim('/', '.', ' '), @"\W+", ".");

    set => _ns = value;
    }

    public string TargetFolder
    {
        get => _targetFolder ?? throw new ConfigurationMissingException("Missing 'targetFolder' of configuration 'model'");
        set => _targetFolder = value;
    }

    public List<string>? Excludes { get; set; }
    public List<string>? Includes { get; set; }
    public List<string>? Imports { get; set; }
}
