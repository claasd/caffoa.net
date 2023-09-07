namespace CdIts.Caffoa.Cli.Config;

public interface IInterfaceConfig
{
    string GetInterfaceName(string prefix);
    string GetInterfaceTargetFolder();
    string GetInterfaceNamespace();
}