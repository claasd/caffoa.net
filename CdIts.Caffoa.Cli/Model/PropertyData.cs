namespace CdIts.Caffoa.Cli.Model;

public class PropertyData
{
    public PropertyData(string name, bool required)
    {
        Name = name;
        TypeName = name.ToObjectName();
        Required = required;
    }

    public string Name { get; }
    public bool Required { get; }
    public string TypeName { get; set; }
    public bool Nullable { get; set; }
    public string? Description { get; set; }
    public bool IsArray { get; set; }
    public bool IsMap { get; set; }
    public string? Default { get; set; }
    public string[] ArrayDefaults { get; set; } = Array.Empty<string>();
    public bool IsOtherSchema { get; set; }
    public List<string?> Enums { get; set; } = new();
    public List<string> CustomAttributes { get; set; } = new();
    public bool Deprecated { get; set; }
    public string? Converter { get; set; }
    public bool InnerTypeIsOtherSchema { get; set; }
}
