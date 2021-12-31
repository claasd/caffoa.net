namespace CdIts.Caffoa.Cli.Config;

public class CaffoaConfig
{
    public string? Prefix { get; set; }
    public string? Suffix { get; set; }
    public string? ErrorFolder { get; set; }
    public string? ErrorNamespace { get; set; }
    public List<string>? Imports;
    public List<RequestBodyTypeConfig>? RequestBodyType { get; set; }

    public CaffoaConfig MergedWith(CaffoaConfig general)
    {
        return new CaffoaConfig()
        {
            Imports = Imports ?? general.Imports,
            Prefix = Prefix ?? general.Prefix,
            Suffix = Suffix ?? general.Suffix,
            ErrorFolder = ErrorFolder ?? general.ErrorFolder,
            ErrorNamespace = ErrorNamespace ?? general.ErrorNamespace,
            RequestBodyType = RequestBodyType ?? RequestBodyType
        };
    }
}
