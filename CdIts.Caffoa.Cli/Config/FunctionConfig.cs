using CdIts.Caffoa.Cli.Errors;

namespace CdIts.Caffoa.Cli.Config;

public class FunctionConfig
{
    private string? _interfaceName;
    private string? _functionsName;
    private string? _name;
    private string? _ns;
    private string? _targetFolder;
    private string? _interfaceNamespace;
    private string? _interfaceTargetFolder;

    public string Name
    {
        get => _name ?? throw new ConfigurationMissingException("Missing 'name' of configuration 'function'");
        set => _name = value;
    }

    public string Namespace
    {
        get => _ns ?? throw new ConfigurationMissingException("Missing 'namespace' of configuration 'function'");
        set => _ns = value;
    }

    public string TargetFolder
    {
        get => _targetFolder ??
               throw new ConfigurationMissingException("Missing 'targetFolder' of configuration 'function'");
        set => _targetFolder = value;
    }

    public string FunctionsName
    {
        get => _functionsName ?? $"{Name}Functions";
        set => _functionsName = value;
    }

    public string InterfaceName
    {
        get => _interfaceName ?? $"I{Name}Service";
        set => _interfaceName = value;
    }

    public string InterfaceNamespace
    {
        get => _interfaceNamespace ?? Namespace;
        set => _interfaceNamespace = value;
    }

    public string InterfaceTargetFolder
    {
        get => _interfaceTargetFolder ?? TargetFolder;
        set => _interfaceTargetFolder = value;
    }

    public string GetInterfaceName(string prefix)
    {
        var name = _interfaceName;
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
        var name = _functionsName;
        if (name == null)
            name = $"{Name}{prefix}Functions";
        else if (name.Contains("{Tag}"))
            name = name.Replace("{Tag}", prefix);
        else
            name = $"{prefix}{name}";
        return name;
    }
}
