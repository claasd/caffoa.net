namespace CdIts.Caffoa.Cli.Config;

public class CaffoaGlobalConfig : CaffoaConfig
{
    public bool ClearGeneratedFiles { get; set; }
    public string? Duplicates { get; set; }
    public bool RemoveDeprecated { get; set; }

    public CaffoaGlobalConfig() : this(true)
    {
    }

    public CaffoaGlobalConfig(bool setDefaults)
    {
        if (setDefaults)
        {
            CheckEnums = true;
            AcceptCaseInvariantEnums = false;
            UseDateOnly = false;
            Imports = new List<string>();
            UseInheritance = true;
            AuthorizationLevel = "function";
            Duplicates = "overwrite";
        }
    }
}
