namespace CdIts.Caffoa.Cli.Model;

public class PropertyData
{
    public PropertyData(string name, bool required, bool readOnly)
    {
        Name = name;
        FieldName = name.ToObjectName();
        TypeName = name.ToObjectName();
        Required = required;
        ReadOnly = readOnly;
    }

    public string FieldName { get; set; }

    public string Name { get; }
    public bool Required { get; }
    public bool ReadOnly { get; }
    public string TypeName { get; set; }
    public bool Nullable { get; set; }
    public string? Description { get; set; }
    public bool IsArray { get; set; }
    public bool IsMap { get; set; }
    public string? Default { get; set; }
    public string[] ArrayDefaults { get; set; } = Array.Empty<string>();
    public bool IsOtherSchema { get; set; }
    public List<string?> Enums { get; set; } = new();
    public Dictionary<string, string> EnumsAliases { get; set; } = new();
    public IList<string> CustomAttributes { get; set; } = new List<string>();
    public bool Deprecated { get; set; }
    public string? Converter { get; set; }
    public bool InnerTypeIsOtherSchema { get; set; }
    public bool Generate { get; set; } = true;
    public bool Delegate { get; set; }
    public string? Alias { get; set; }
    public string? AliasGet { get; set; }
    public string? AliasSet { get; set; }
}
