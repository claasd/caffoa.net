namespace CdIts.Caffoa.Cli.Model;

public class SchemaItem
{
    public enum ObjectType
    {
        Regular,
        StringEnum
    };
    public SchemaItem(string name, string className)
    {
        Name = name;
        ClassName = className;
    }
    
    public string? Namespace { get; set; }

    public  ObjectType Type { get; set; } = ObjectType.Regular;
    public string Name { get; }
    public string ClassName { get; set; }
    public InterfaceModel? Interface { get; set; }
    public List<PropertyData>? Properties { get; set; }
    public string? Parent { get; set; }
    public string? Description { get; set; }
    public bool AdditionalPropertiesAllowed { get; set; }
    public List<string> SubItems { get; set; } = new();
    public List<string?> Enums { get; set; } = new();
    public Dictionary<string,string> EnumsAliases { get; set; } = new();
    public string? Default { get; set; }
    public bool NullableEnum { get; set; }
    public bool? GenerateEqualsOverload { get; set; }
    public bool? GenerateComparerOverload { get; set; }
}
