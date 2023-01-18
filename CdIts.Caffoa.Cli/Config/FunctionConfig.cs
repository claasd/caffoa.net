using System.Text.RegularExpressions;
using CdIts.Caffoa.Cli.Errors;

namespace CdIts.Caffoa.Cli.Config;

public class FunctionConfig
{
    private string? _name;
    private string? _ns;
    private string? _targetFolder;

    public string Name
    {
        get => _name ?? throw new ConfigurationMissingException("Missing 'name' of configuration 'function'");
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

    public string? FunctionsName { get; set; }
    public string? InterfaceName { get; set; }

    public string? InterfaceNamespace { get; set; }

    public string? InterfaceTargetFolder { get; set; }

    public string GetInterfaceName(string prefix)
    {
        var name = InterfaceName;
        if (name == null)
            name = $"I{Name}{prefix}Service";
        else if (name.Contains("{Tag}"))
            name = name.Replace("{Tag}", prefix);
        else
            name = $"{prefix}{name}";
        return name;
    }

    public string GetFunctionName(string prefix)
    {
        var name = FunctionsName;
        if (name == null)
            name = $"{Name}{prefix}Functions";
        else if (name.Contains("{Tag}"))
            name = name.Replace("{Tag}", prefix);
        else
            name = $"{prefix}{name}";
        return name;
    }
}
