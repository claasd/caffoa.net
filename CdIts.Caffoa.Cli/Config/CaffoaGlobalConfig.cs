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
            UseDateOnly = false;
            Imports = new List<string>();
            UseInheritance = true;
            AuthorizationLevel = "function";
            Duplicates = "overwrite";
        }
    }
}
