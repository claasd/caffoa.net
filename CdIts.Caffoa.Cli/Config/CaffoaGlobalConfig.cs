namespace CdIts.Caffoa.Cli.Config;

public class CaffoaGlobalConfig : CaffoaConfig
{
    public bool ClearGeneratedFiles { get; set; }
    public string Duplicates { get; set; } = "overwrite";
    public CaffoaGlobalConfig()
    {
        CheckEnums = true;
        UseDateOnly = false;
        Imports = new List<string>();
    }
}