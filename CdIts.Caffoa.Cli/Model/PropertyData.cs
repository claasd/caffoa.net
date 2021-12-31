namespace CdIts.Caffoa.Cli.Model;

public class PropertyData
{
    public PropertyData(string name, bool required)
    {
        Name = name;
        Required = required;
    }

    public string Name { get; }
    public bool Required { get; }
    public string TypeName { get; set; }
    public bool Nullable { get; set; }
    public string Description { get; set; }
    public bool IsArray { get; set; }
    public string? Default { get; set; }
    public bool IsOtherSchema { get; set; }
}