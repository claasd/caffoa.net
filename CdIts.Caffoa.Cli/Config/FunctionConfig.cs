namespace CdIts.Caffoa.Cli.Config;

public class FunctionConfig
{
    public string Name { get; set; }
    public string Namespace { get; set; }
    public string TargetFolder { get; set; }
    public string FunctionsName { get; set; }
    public string InterfaceName { get; set; }
    public string InterfaceNamespace { get; set; }
    public string InterfaceTargetFolder { get; set; }
    public string Boilerplate { get; set; } = "";
    public List<string> Imports { get; set; } = new();
}