namespace CdIts.Caffoa.Cli.Model;

public class SchemaItem
{
    public SchemaItem(string name, string className)
    {
        Name = name;
        ClassName = className;
    }

    public string Name { get; }
    public string ClassName { get; }
    public InterfaceModel? Interface { get; set; }
    public List<PropertyData>? Properties { get; set; }
    public string? Parent { get; set; }
    public string? Description { get; set; }
    public bool AdditionalPropertiesAllowed{ get; set; }
}