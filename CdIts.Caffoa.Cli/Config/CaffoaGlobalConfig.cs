namespace CdIts.Caffoa.Cli.Config;

public class CaffoaGlobalConfig : CaffoaConfig
{
    public bool ClearGeneratedFiles { get; set; } = true;
    public string? Duplicates { get; set; }

    public CaffoaGlobalConfig() : this(true)
    {
    }

    public CaffoaGlobalConfig(bool setDefaults)
    {
        if (setDefaults)
        {
            Imports = new List<string>();
            AuthorizationLevel = "function";
            Duplicates = "overwrite";
        }
    }
}
