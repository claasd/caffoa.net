using System.Text.RegularExpressions;
using CdIts.Caffoa.Cli.Config;

namespace CdIts.Caffoa.Cli.Model;

public enum ParameterArrayType
{
    NoArray,
    StringArray,
    EnumArray
}

public class ParameterObject
{
    public string VarName => Regex.Replace(Name, @"\W", "");
    public string Name { get; }
    private string TypeName { get; set; }
    public string Description { get; }
    public bool IsQueryParameter { get; set; }

    public string? DefaultValue { get; set; }
    public bool Required { get; set; }
    public bool IsEnum { get; set; }

    public ParameterArrayType ArrayType { get; set; } = ParameterArrayType.NoArray;

    public string? InnerType { get; set; }

    public ParameterObject(string name, string typeName, string description, bool inQuery)
    {
        Name = name;
        TypeName = typeName;
        Description = description;
        IsQueryParameter = inQuery;
    }

    public string GetTypeName(CaffoaConfig config)
    {
        // only generate DateOnly parameters if type converting is not done by functions
        return GetTypeName(config.UseDateOnly is true && config.ParsePathParameters is not false, config.UseDateTime is true);
    }

    public string GetTypeName(bool useDateOnly, bool useDateTime)
    {
        var name = useDateOnly ? TypeName : TypeName.Replace("DateOnly", "DateTimeOffset");
        return useDateTime ? name.Replace("DateTimeOffset", "DateTime") : name;
    }
}