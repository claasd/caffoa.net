using CdIts.Caffoa.Cli.Model;

namespace CdIts.Caffoa.Cli.Generator.Formatter;

public class SchemaItemFormatter
{
    private readonly SchemaItem _item;

    public SchemaItemFormatter(SchemaItem item)
    {
        _item = item;
    }

    public object Description
    {
        get
        {
            var description = "/// AUTOGENERED BY caffoa ///\n\t";
            if (_item.Description is null)
                return description;
            var itemDesc = _item.Description.Trim().Replace("\n", "\n\t/// ");
            description += $"/// <summary>\n\t/// {itemDesc}\n\t/// </summary>\n\t";
            return description;
        }
    }

    public string Parents(List<SchemaItem> allObjects)
    {
        var parents = new List<string>();
        if (_item.Parent != null)
            parents.Add(_item.Parent);
        var interfaces = allObjects.Where(o => o.Interface != null && o.Interface.Children.Contains(_item.ClassName))
            .Select(o => o.ClassName);
        parents.AddRange(interfaces);
        if (parents.Count > 0)
            return " : " + string.Join(", ", parents);
        return "";
    }

    public string Imports(List<string>? modelImports, List<string>? configImports)
    {
        var imports = new List<string>();
        var hasArray = _item.Properties?.FirstOrDefault(p => p.IsArray) != null;
        if (hasArray)
        {
            imports.Add("System.Collections.Generic");
            imports.Add("System.Linq");
        }
        
        var hasEnums = _item.Properties?.FirstOrDefault(p => p.Enums.Count > 0) != null;
        if (hasEnums)
        {
            imports.Add("System.Collections.Immutable");
            imports.Add("System.Linq");
        }

        var hasDates = _item.Properties?.FirstOrDefault(p => p.TypeName.StartsWith("DateOnly")) != null;
        if(hasDates)
            imports.Add("Caffoa.JsonConverter");

        if (modelImports != null)
            imports.AddRange(modelImports);
        if (configImports != null)
            imports.AddRange(configImports);
        return imports.Count > 0 ? string.Join("", imports.Distinct().Select(i => $"using {i};\n")) : "";
    }
}