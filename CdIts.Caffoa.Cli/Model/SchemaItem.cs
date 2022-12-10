namespace CdIts.Caffoa.Cli.Model;

public class SchemaItem
{
    public enum ObjectType
    {
        Regular,
        StringEnum,
        IntEnum
    };
    public SchemaItem(string name, string className)
    {
        Name = name;
        ClassName = className;
    }

    public  ObjectType Type { get; set; } = ObjectType.Regular;
    public string Name { get; }
    public string ClassName { get; }
    public InterfaceModel? Interface { get; set; }
    public List<PropertyData>? Properties { get; set; }
    public string? Parent { get; set; }
    public string? Description { get; set; }
    public bool AdditionalPropertiesAllowed { get; set; }
    public List<string> SubItems { get; set; } = new();
    public List<string?> Enums { get; set; } = new();
}
