namespace CdIts.Caffoa.Cli.Config;

public class CaffoaConfig
{
    private string? _genericAdditionalPropertiesType;
    public bool? CheckEnums { get; set; }
    public bool? AcceptCaseInvariantEnums { get; set; }
    public string? Prefix { get; set; }
    public string? Suffix { get; set; }
    public string? RoutePrefix { get; set; }
    public bool? SplitByTag { get; set; }
    public bool? UseDateOnly { get; set; }
    public bool? WithCancellation { get; set; }
    public bool? ParsePathParameters { get; set; }
    public bool? ParseQueryParameters { get; set; }
    public bool? GenericAdditionalProperties { get; set; }

    public string GenericAdditionalPropertiesType
    {
        get => _genericAdditionalPropertiesType ?? "JObject";
        set => _genericAdditionalPropertiesType = value;
    }

    public List<string>? Imports { get; set; }
    public List<RequestBodyTypeConfig>? RequestBodyType { get; set; }
    public FilterConfig? DurableClient { get; set; }
    public string? FunctionNamePrefix { get; set; }
    public bool? Disposable { get; set; }
    public bool? GenerateResolvedApiFile { get; set; }
    public bool? Extensions { get; set; }
    public bool? UseInheritance { get; set; }
    
    public string? AuthorizationLevel { get; set; }

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
            ParsePathParameters = ParsePathParameters ?? general.ParsePathParameters,
            ParseQueryParameters = ParseQueryParameters ?? general.ParseQueryParameters,
            GenericAdditionalProperties = GenericAdditionalProperties ?? general.GenericAdditionalProperties,
            GenericAdditionalPropertiesType = _genericAdditionalPropertiesType ?? general.GenericAdditionalPropertiesType,
            DurableClient = DurableClient ?? general.DurableClient,
            SplitByTag = SplitByTag ?? general.SplitByTag,
            WithCancellation = WithCancellation ?? general.WithCancellation,
            FunctionNamePrefix = FunctionNamePrefix ?? general.FunctionNamePrefix,
            Disposable = Disposable ?? general.Disposable,
            GenerateResolvedApiFile = GenerateResolvedApiFile ?? general.GenerateResolvedApiFile,
            Extensions = Extensions ?? general.Extensions,
            RemoveDeprecated = general.RemoveDeprecated,
            UseInheritance = UseInheritance ?? general.UseInheritance,
            AcceptCaseInvariantEnums = AcceptCaseInvariantEnums ?? general.AcceptCaseInvariantEnums,
            AuthorizationLevel = AuthorizationLevel ?? general.AuthorizationLevel
        };
    }
}
