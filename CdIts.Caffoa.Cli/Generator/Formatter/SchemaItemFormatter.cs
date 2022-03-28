using CdIts.Caffoa.Cli.Config;
using CdIts.Caffoa.Cli.Model;

namespace CdIts.Caffoa.Cli.Generator.Formatter;

public class SchemaItemFormatter
{
    private readonly SchemaItem _item;
    private readonly CaffoaConfig _config;

    public SchemaItemFormatter(SchemaItem item, CaffoaConfig config)
    {
        _item = item;
        _config = config;
    }

    public object Description
    {
        get
        {
            var description = "/// AUTOGENERED BY caffoa ///\n    ";
            if (_item.Description is null)
                return description;
            var itemDesc = _item.Description.Trim().Replace("\n", "\n    /// ");
            description += $"/// <summary>\n    /// {itemDesc}\n    /// </summary>\n    ";
            return description;
        }
    }

    public string Parents(List<SchemaItem> allObjects)
    {
        var parents = new List<string>();
        if (_item.Parent != null)
            parents.Add(_item.Parent);
        parents.AddRange(MatchingInterfaces(allObjects));
        if (parents.Count > 0)
            return " : " + string.Join(", ", parents);
        return "";
    }

    public string Imports(List<string>? modelImports, List<string>? configImports)
    {
        var imports = new List<string>();
        var hasArray = _item.Properties?.FirstOrDefault(p => p.IsArray || p.IsMap) != null;
        var hasExtension = _item.AdditionalPropertiesAllowed && _config.GenericAdditionalProperties is true;
        if (hasArray || hasExtension)
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

        var hasDates = _item.Properties?.Any(p => p.TypeName.StartsWith("DateOnly")) ?? false;
        var hasTimes = _item.Properties?.Any(p => p.TypeName.StartsWith("TimeOnly")) ?? false;
        if (hasDates || hasTimes)
            imports.Add("Caffoa.JsonConverter");
        if (modelImports != null)
            imports.AddRange(modelImports);
        if (configImports != null)
            imports.AddRange(configImports);
        return imports.Count > 0 ? string.Join("", imports.Distinct().Select(i => $"using {i};\n")) : "";
    }

    public List<string> MatchingInterfaces(List<SchemaItem> schemas)
    {
        return schemas.Where(schema => schema.Interface != null && schema.Interface.Children.Any(
            interfaceChild => interfaceChild == _item.ClassName ||
                              _item.SubItems.Any(subItem => subItem == interfaceChild)
        )).Select(item => item.ClassName).ToList();
    }

    public string InterfaceMethods(List<SchemaItem> interfaces)
    {
        var implementations = MatchingInterfaces(interfaces)
            .Select(i => $"        public virtual {i} To{i}() => To{_item.ClassName}();\n");
        return string.Join("", implementations);
    }
    
    public string SubItemMethods()
    {
        var implementations = _item.SubItems
            .Select(i => $"        public virtual {i} To{i}() => new {i}(this);\n");
        return string.Join("", implementations);
    }

    public string GenericAdditionalProperties()
    {
        if (_item.AdditionalPropertiesAllowed && _config.GenericAdditionalProperties is true)
            return
                $"\n        [JsonExtensionData]\n        public Dictionary<string, {_config.GenericAdditionalPropertiesType}> AdditionalProperties;\n";
        return "";
    }
}
