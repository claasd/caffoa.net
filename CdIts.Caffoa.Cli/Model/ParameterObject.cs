using CdIts.Caffoa.Cli.Config;

namespace CdIts.Caffoa.Cli.Model;

public class ParameterObject
{
    public string Name { get; }
    public string TypeName { get; set; }
    public string Description { get; }
    public bool IsQueryParameter { get; set; }

    public string? DefaultValue { get; set; }
    public bool Required { get; set; }

    public ParameterObject(string name, string typeName, string description, bool inQuery)
    {
        Name = name;
        TypeName = typeName;
        Description = description;
        IsQueryParameter = inQuery;
    }
}
