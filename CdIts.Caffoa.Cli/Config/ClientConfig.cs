using System.Text.RegularExpressions;
using CdIts.Caffoa.Cli.Errors;

namespace CdIts.Caffoa.Cli.Config;

public class ClientConfig
{
    private string? _ns;
    private string? _targetFolder;
    private string? _name;

    public string Name
    {
        get => _name ?? throw new ConfigurationMissingException("Missing 'name' of configuration 'client'");
        set => _name = value;
    }

    public string Namespace
    {
        get => _ns ?? Regex.Replace(TargetFolder.Trim('/', '.', ' '), @"\W+", ".");
        set => _ns = value;
    }

    public string TargetFolder
    {
        get => _targetFolder ??
               throw new ConfigurationMissingException("Missing 'targetFolder' of configuration 'function'");
        set => _targetFolder = value;
    }
    public string[]? IncludeTags { get; set; }
    public bool? SplitByTag { get; set; }
    public string ConstructorVisibility { get; set; } = "public";
    public string FieldVisibility { get; set; } = "public";

    public string GetName(string prefix)
    {
        var name = Name;
        if (name.Contains("{Tag}"))
            name = name.Replace("{Tag}", prefix);
        else
            name = $"{prefix}{name}";
        return name;
    }
}