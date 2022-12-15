using CdIts.Caffoa.Cli.Config;
using CdIts.Caffoa.Cli.Model;

namespace CdIts.Caffoa.Cli.Generator.Formatter;

public class SchemaItemFormatter
{
    private readonly SchemaItem _item;
    private readonly CaffoaConfig _config;
    private readonly List<SchemaItem> _otherClasses;

    public SchemaItemFormatter(SchemaItem item, CaffoaConfig config, List<SchemaItem> otherClasses)
    {
        _item = item;
        _config = config;
        _otherClasses = otherClasses;
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
        foreach (var subItem in _item.SubItems)
        {
            var otherItem = _otherClasses.FirstOrDefault(c => c.ClassName == subItem);
            if (otherItem?.Namespace != null)
                imports.Add(otherItem.Namespace);
        }
        return imports.Count > 0 ? string.Join("", imports.Distinct().Select(i => $"using {i};\n")) : "";
    }

    public List<string> MatchingInterfaces(List<SchemaItem> schemas)
    {
        return schemas.Where(schema => schema.Interface != null && schema.Interface.Children.Any(
            interfaceChild => interfaceChild == _item.ClassName ||
                              _item.SubItems.Any(subItem => subItem == interfaceChild)
        )).Select(item => item.ClassName).ToList();
    }
    public List<string> MatchingDiscriminators(List<SchemaItem> schemas)
    {
        return schemas.Where(schema => schema.Interface?.Discriminator != null && schema.Interface.Children.Any(
            interfaceChild => interfaceChild == _item.ClassName ||
                              _item.SubItems.Any(subItem => subItem == interfaceChild)
        )).Select(item => item.Interface!.Discriminator!.ToObjectName()).Distinct().ToList();
    }

    public string InterfaceMethods(List<SchemaItem> interfaces)
    {
        var implementations = MatchingInterfaces(interfaces)
            .Select(i => $"        public virtual {i} To{i}() => To{_item.ClassName}();\n");
        var discriminators = MatchingDiscriminators(interfaces)
            .Select(d=>$"        public virtual string {d}Discriminator => {d}.ToString();\n");
        return string.Join("", implementations.Concat(discriminators));
    }
    
    public string SubItemMethods()
    {
        var implementations = new List<string>();
        foreach (var subItem in _item.SubItems)
        {
            var otherItem = _otherClasses.FirstOrDefault(c => c.ClassName == subItem);
            if (otherItem != null)
                implementations.Add($"        public virtual {subItem} To{subItem}() => new {subItem}(this);\n");
        }
        return string.Join("", implementations);
    }

    public string GenericAdditionalProperties()
    {
        if (_item.AdditionalPropertiesAllowed && _config.GenericAdditionalProperties is true)
            return
                $"\n        [JsonExtensionData]\n        public Dictionary<string, {_config.GetGenericAdditionalPropertiesType()}> AdditionalProperties;\n";
        return "";
    }
}
