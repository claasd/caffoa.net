namespace CdIts.Caffoa.Cli.Model;

public class ParameterObject
{
    public string Name { get; }
    public string TypeName { get; set;  }
    public string Description { get; }

    public ParameterObject(string name, string typeName, string description)
    {
        Name = name;
        TypeName = typeName;
        Description = description;
    }
}