namespace CdIts.Caffoa.Cli.Config;

public class CaffoaConfig
{
    public bool? CheckEnums { get; set; }
    public string? Prefix { get; set; }
    public string? Suffix { get; set; }
    public string? RoutePrefix { get; set; }
    public bool? UseDateOnly { get; set; }
    public bool? ParseParameters { get; set; }
    public bool? ParseQueryParameters { get; set; }
    
    public List<string>? Imports;
    public List<RequestBodyTypeConfig>? RequestBodyType { get; set; }

    public CaffoaGlobalConfig MergedWith(CaffoaGlobalConfig general)
    {
        return new CaffoaGlobalConfig()
        {
            Imports = Imports ?? general.Imports,
            Prefix = Prefix ?? general.Prefix,
            Suffix = Suffix ?? general.Suffix,
            RequestBodyType = RequestBodyType ?? general.RequestBodyType,
            CheckEnums = CheckEnums ?? general.CheckEnums,
            RoutePrefix = RoutePrefix ?? general.RoutePrefix,
            UseDateOnly = UseDateOnly ?? general.UseDateOnly,
            Duplicates = general.Duplicates,
            ClearGeneratedFiles = general.ClearGeneratedFiles,
            ParseParameters = ParseParameters ?? general.ParseParameters,
            ParseQueryParameters = ParseQueryParameters ?? general.ParseQueryParameters
        };
    }
}
