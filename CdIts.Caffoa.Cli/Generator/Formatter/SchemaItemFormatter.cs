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
        if(_item.Parent != null)
            parents.Add(_item.Parent);
        parents.AddRange(MatchingInterfaces(allObjects));
        if(_config.GenerateEqualsMethods is true)
            parents.Add("IEquatable<" + _item.ClassName + ">");
        if (parents.Count > 0)
            return " : " + string.Join(", ", parents);
        return "";
    }

    public string Parent()=>_item.Parent is null ? "" : $": {_item.Parent}";
    

    public string Imports(List<string>? modelImports, List<string>? configImports)
    {
        var imports = new List<string>();
        if (_config.Flavor is CaffoaConfig.GenerationFlavor.SystemTextJsonPre7 || _config.Flavor is CaffoaConfig.GenerationFlavor.SystemTextJson)
        {
            imports.Add("System.Text.Json");
            imports.Add("System.Text.Json.Serialization");
        }
        else
        {
            imports.Add("Newtonsoft.Json");
            imports.Add("Newtonsoft.Json.Linq");
        }
        var hasArray = _item.Properties?.Find(p => p.IsArray || p.IsMap) != null;
        var hasExtension = _item.AdditionalPropertiesAllowed && _config.GenericAdditionalProperties is true;
        if (hasArray || hasExtension)
        {
            imports.Add("System.Collections.Generic");
            imports.Add("System.Linq");
        }

        var hasEnums = _item.Properties?.Find(p => p.Enums.Count > 0) != null;
        if (hasEnums)
        {
            imports.Add("System.Collections.Immutable");
            imports.Add("System.Linq");
        }

        var hasDates = _item.Properties?.Exists(p => p.TypeName.StartsWith("DateOnly")) ?? false;
        var hasTimes = _item.Properties?.Exists(p => p.TypeName.StartsWith("TimeOnly")) ?? false;
        if (hasDates || hasTimes)
            imports.Add("Caffoa.JsonConverter");
        if (modelImports != null)
            imports.AddRange(modelImports);
        if (configImports != null)
            imports.AddRange(configImports);
        foreach (var subItem in _item.SubItems)
        {
            var otherItem = _otherClasses.Find(c => c.ClassName == subItem);
            if (otherItem?.Namespace != null)
                imports.Add(otherItem.Namespace);
        }
        return string.Join("", imports.Distinct().Select(i => $"using {i};\n"));
    }

    public List<string> MatchingInterfaces(List<SchemaItem> schemas)
    {
        return schemas.Where(schema => schema.Interface != null && schema.Interface.Children.Exists(
            interfaceChild => interfaceChild == _item.ClassName ||
                              _item.SubItems.Contains(interfaceChild)
        )).Select(item => item.ClassName).ToList();
    }
    public List<string> MatchingDiscriminators(List<SchemaItem> schemas)
    {
        return schemas.Where(schema => schema.Interface?.Discriminator != null && schema.Interface.Children.Exists(
            interfaceChild => interfaceChild == _item.ClassName ||
                              _item.SubItems.Contains(interfaceChild)
        )).Select(item => item.Interface!.Discriminator!.ToObjectName()).Distinct().ToList();
    }

    public string InterfaceMethods(List<SchemaItem> interfaces)
    {
        var virtualStr = _config.SealClasses() ? "" : " virtual";
        var implementations = MatchingInterfaces(interfaces)
            .Select(i => $"        public{virtualStr} {i} To{i}() => To{_item.ClassName}();\n");
        var discriminators = MatchingDiscriminators(interfaces)
            .Select(d=>
            {
                var prop = _item.Properties?.Find(p => p.Name.ToObjectName() == d);
                if (prop is null)
                    return ""; // this is inheritance
                var result = $"        public{virtualStr} string {d}Discriminator => {d}";
                if ((_config.UseConstants is not true || !prop.CanBeConstant()) && _config.GetEnumCreationMode() == CaffoaConfig.EnumCreationMode.Default && (prop.CanBeEnum()))
                    result += ".Value();\n";
                else if(prop!.TypeName.StartsWith("string"))
                {
                    result += ";\n";
                }
                else
                    result += ".ToString();\n";

                return result;
            });
        return string.Join("", implementations.Concat(discriminators));
    }
    
    
    public string GenericAdditionalProperties()
    {
        if (_item.AdditionalPropertiesAllowed && _config.GenericAdditionalProperties is true && _item.Parent is null)
            return
                $"\n        [JsonExtensionData]\n        public Dictionary<string, {_config.GetGenericAdditionalPropertiesType()}> AdditionalProperties;\n";
        return "";
    }

    public string CreateConstructors(List<SchemaItem> otherClasses)
    {
        var implementations = new List<string>();
        implementations.Add($"        public {_item.ClassName}() {{}}\n");
        implementations.Add($"        public {_item.ClassName}({_item.ClassName} other) : base(other){{}}\n");
        if(_item.Parent != null)
            implementations.Add($"        public {_item.ClassName}({_item.Parent} other) : base(other){{}}\n");

        return "\n" + string.Join("", implementations);
    }
}
