using System.Runtime.Serialization;

namespace CdIts.Caffoa.Cli.Config;

public class CaffoaConfig
{
    public string? Prefix { get; set; }
    public string? Suffix { get; set; }
    public string? RoutePrefix { get; set; }
    public bool? SplitByTag { get; set; }
    public bool? UseDateOnly { get; set; }
    public bool? UseDateTime { get; set; }
    public bool? WithCancellation { get; set; }
    public bool? ParsePathParameters { get; set; }
    public bool? ParseQueryParameters { get; set; }
    public bool? GenericAdditionalProperties { get; set; }

    public string? GenericAdditionalPropertiesType { get; set; }

    public string GetGenericAdditionalPropertiesType() => GenericAdditionalPropertiesType ?? GetGenericType();

    public string GetGenericType() => Flavor is GenerationFlavor.SystemTextJson ? "JsonElement?" : "JToken";

    public List<string>? Imports { get; set; }
    public List<RequestBodyTypeConfig>? RequestBodyType { get; set; }
    public FilterConfig? DurableClient { get; set; }
    public string? FunctionNamePrefix { get; set; }
    public bool? Disposable { get; set; }
    public bool? GenerateResolvedApiFile { get; set; }
    public bool? Extensions { get; set; }
    public bool? UseInheritance { get; set; }
    public string? AuthorizationLevel { get; set; }
    public bool? AsyncArrays { get; set; }
    
    public bool? UseConstants { get; set; }
    public bool? PassTags { get; set; }

    public enum EnumCreationMode
    {
        Default,
        StaticValues,
        StaticValuesWithoutCheck
    }

    public EnumCreationMode? EnumMode { get; set; }
    public EnumCreationMode GetEnumCreationMode() => EnumMode ?? EnumCreationMode.Default;

    public enum GenerationFlavor
    {
        [EnumMember(Value = "System.Text.Json")]
        SystemTextJson,
        [EnumMember(Value = "Json.NET")] JsonNet,
    }
    public bool? ConstructorOnRequiredObjects { get; set; }
    public GenerationFlavor? Flavor { get; set; }

    public CaffoaGlobalConfig MergedWith(CaffoaGlobalConfig general)
    {
        return new CaffoaGlobalConfig()
        {
            Imports = Imports ?? general.Imports,
            Prefix = Prefix ?? general.Prefix,
            Suffix = Suffix ?? general.Suffix,
            RequestBodyType = RequestBodyType ?? general.RequestBodyType,
            RoutePrefix = RoutePrefix ?? general.RoutePrefix,
            UseDateOnly = UseDateOnly ?? general.UseDateOnly,
            UseDateTime = UseDateTime ?? general.UseDateTime,
            Duplicates = general.Duplicates,
            ClearGeneratedFiles = general.ClearGeneratedFiles,
            ParsePathParameters = ParsePathParameters ?? general.ParsePathParameters,
            ParseQueryParameters = ParseQueryParameters ?? general.ParseQueryParameters,
            GenericAdditionalProperties = GenericAdditionalProperties ?? general.GenericAdditionalProperties,
            GenericAdditionalPropertiesType =
                GenericAdditionalPropertiesType ?? general.GenericAdditionalPropertiesType,
            DurableClient = DurableClient ?? general.DurableClient,
            SplitByTag = SplitByTag ?? general.SplitByTag,
            WithCancellation = WithCancellation ?? general.WithCancellation,
            FunctionNamePrefix = FunctionNamePrefix ?? general.FunctionNamePrefix,
            Disposable = Disposable ?? general.Disposable,
            GenerateResolvedApiFile = GenerateResolvedApiFile ?? general.GenerateResolvedApiFile,
            Extensions = Extensions ?? general.Extensions,
            UseInheritance = UseInheritance ?? general.UseInheritance,
            AuthorizationLevel = AuthorizationLevel ?? general.AuthorizationLevel,
            AsyncArrays = AsyncArrays ?? general.AsyncArrays,
            EnumMode = EnumMode ?? general.EnumMode,
            Flavor = Flavor ?? general.Flavor,
            ConstructorOnRequiredObjects = ConstructorOnRequiredObjects ?? general.ConstructorOnRequiredObjects,
            UseConstants = UseConstants ?? general.UseConstants,
            PassTags = PassTags ?? general.PassTags
        };
    }
}