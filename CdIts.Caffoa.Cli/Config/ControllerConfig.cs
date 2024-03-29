using System.Text.RegularExpressions;
using CdIts.Caffoa.Cli.Errors;

namespace CdIts.Caffoa.Cli.Config;

public class ControllerConfig:IInterfaceConfig
{
    private string? _name;
    private string? _ns;
    private string? _targetFolder;

    public string Name
    {
        get => _name ?? throw new ConfigurationMissingException("Missing 'name' of configuration 'controller'");
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
               throw new ConfigurationMissingException("Missing 'targetFolder' of configuration 'controller'");
        set => _targetFolder = value;
    }
    public string? ControllerName { get; set; }
    public string? InterfaceName { get; set; }

    public string? InterfaceNamespace { get; set; }

    public string? InterfaceTargetFolder { get; set; }

    public string GetControllerName(string prefix)
    {
        var name = ControllerName;
        if (name == null)
            name = $"{Name}{prefix}Controller";
        else if (name.Contains("{Tag}"))
            name = name.Replace("{Tag}", prefix);
        else
            name = $"{prefix}{name}";
        return name;
    }

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
    public string GetInterfaceTargetFolder() => InterfaceTargetFolder ?? TargetFolder;

    public string GetInterfaceNamespace() => InterfaceNamespace ?? Namespace;
}
