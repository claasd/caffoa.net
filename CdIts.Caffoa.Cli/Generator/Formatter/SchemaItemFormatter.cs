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

    public string Imports(List<string>? configImports)
    {
        var imports = new List<string>();
        if (configImports != null)
            imports.AddRange(configImports);
        return imports.Count > 0 ? string.Join("", imports.Select(i => $"using {i};\n")) : "";
    }
}