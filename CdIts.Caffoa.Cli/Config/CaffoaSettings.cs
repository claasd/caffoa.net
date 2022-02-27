namespace CdIts.Caffoa.Cli.Config;

public class CaffoaSettings
{
    public CaffoaGlobalConfig Config { get; set; } = new();
    public List<ServiceConfig> Services { get; set; } = new();
}
