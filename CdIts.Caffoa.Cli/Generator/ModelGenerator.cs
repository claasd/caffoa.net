using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using CdIts.Caffoa.Cli.Config;
using CdIts.Caffoa.Cli.Errors;
using CdIts.Caffoa.Cli.Generator.Formatter;
using CdIts.Caffoa.Cli.Model;

namespace CdIts.Caffoa.Cli.Generator;

public class ModelGenerator
{
    private readonly ServiceConfig _service;
    private readonly CaffoaGlobalConfig _config;

    public ModelGenerator(ServiceConfig service, CaffoaGlobalConfig mergedConfig)
    {
        _service = service;
        _config = mergedConfig;
    }

    public IEnumerable<string> WriteModel(List<SchemaItem> objects)
    {
        Directory.CreateDirectory(_service.Model!.TargetFolder);
        var interfaces = objects.Where(o => o.Interface != null).ToList();
        var classes = objects.Where(o => o.Interface == null).ToList();
        var enumClasses = objects.Where(o => o.Properties != null && o.Properties.Any(p => p.Enums.Any())).ToList();
        enumClasses.ForEach(WriteEnumClasses);
        interfaces.ForEach(WriteModelInterface);
        classes.ForEach(c => WriteModelClass(c, interfaces, classes));
        if (_config.Extensions is false)
            return Array.Empty<string>();
        return classes.Select(c => CreateModelExtensions(c, classes)).Where(d => !string.IsNullOrEmpty(d));
    }

    private void WriteModelInterface(SchemaItem item)
    {
        var file = Templates.GetTemplate("ModelInterfaceTemplate.tpl");
        var fileName = $"{item.ClassName}.generated.cs";
        var formatter = new SchemaItemFormatter(item, _config);
        var parameters = new Dictionary<string, object>();
        parameters["NAMESPACE"] = _service.Model!.Namespace;
        parameters["NAME"] = item.ClassName;
        parameters["DESCRIPTION"] = formatter.Description;
        parameters["TYPE"] = item.Interface?.Discriminator?.ToObjectName() ?? "";
        var formatted = file.FormatDict(parameters);
        File.WriteAllText(Path.Combine(_service.Model.TargetFolder, fileName), formatted.ToSystemNewLine());
    }

    private void WriteModelClass(SchemaItem item, List<SchemaItem> interfaces, List<SchemaItem> otherClasses)
    {
        var file = Templates.GetTemplate("ModelTemplate.tpl");
        var formatter = new SchemaItemFormatter(item, _config);
        var fileName = $"{item.ClassName}.generated.cs";
        var parameters = new Dictionary<string, object>();
        parameters["NAMESPACE"] = _service.Model!.Namespace;
        parameters["IMPORTS"] = formatter.Imports(_service.Model.Imports, _config.Imports);
        parameters["NAME"] = item.ClassName;
        parameters["PARENTS"] = formatter.Parents(interfaces);
        parameters["INTERFACE_METHODS"] = formatter.InterfaceMethods(interfaces) + formatter.SubItemMethods();
        parameters["RAWNAME"] = item.Name;
        parameters["CONSTRUCTORS"] = CreateConstructors(item, otherClasses);
        parameters["PROPERTIES"] = FormatProperties(item);
        parameters["ADDITIONAL_PROPS"] = formatter.GenericAdditionalProperties();
        parameters["DESCRIPTION"] = formatter.Description;
        var formatted = file.FormatDict(parameters);
        File.WriteAllText(Path.Combine(_service.Model.TargetFolder, fileName), formatted.ToSystemNewLine());
    }

    private string CreateModelExtensions(SchemaItem item, List<SchemaItem> otherSchemas)
    {
        var data = new List<string>();
        data.Add(CreateModelExtension(item, item));
        if (_config.UseInheritance is false)
        {
            foreach (var subItem in item.SubItems)
            {
                var otherItem = otherSchemas.FirstOrDefault(i => i.ClassName == subItem);
                if (otherItem != null)
                    data.Add(CreateModelExtension(item, otherItem));
                else
                {
                    Console.Error.WriteLine(
                        $"Warning: Could not generate update extension for {item.ClassName} with parameter {subItem}");
                }
            }
        }

        return string.Join("\n\n", data);
    }

    private string CreateModelExtension(SchemaItem item, SchemaItem otherItem)
    {
        string file;
        file = Templates.GetTemplate(_config.RemoveDeprecated
            ? "ModelExtensionContentTemplate.tpl"
            : "ModelExtensionContentTemplate.deprecated.tpl");
        var parameters = new Dictionary<string, object>();
        parameters["NAME"] = item.ClassName;
        parameters["OTHER"] = otherItem.ClassName;
        parameters["UPDATEPROPS"] = FormatExternalPropertiesUpdate(otherItem, item.ClassName);
        var formatted = file.FormatDict(parameters);
        return formatted.ToSystemNewLine();
    }

    private string CreateConstructors(SchemaItem item, List<SchemaItem> otherClasses)
    {
        var builder = new StringBuilder();
        builder.Append($"public {item.ClassName}({item.ClassName} other)");
        var props = FormatPropertyUpdates(item);
        if (item.Parent != null)
            builder.Append($" : base(other)");
        builder.Append(" {\n            ");
        builder.Append(props);
        builder.Append("\n        }");
        if (item.Parent != null)
        {
            builder.Append($"\n        public {item.ClassName}({item.Parent} other) : base(other) {{}}");
        }

        foreach (var subItem in item.SubItems)
        {
            var otherItem = otherClasses.FirstOrDefault(c => c.ClassName == subItem);
            if (otherItem != null)
            {
                builder.Append($"\n        public {item.ClassName}({subItem} other){{\n            ");
                builder.Append(FormatPropertyUpdates(otherItem));
                builder.Append("\n        }");
            }
            else
            {
                Console.Error.WriteLine(
                    $"WARNING: Cloud not create contructor for class {item.ClassName} with parameter {subItem}");
            }
        }

        foreach (var inheritingItem in otherClasses.Where(o => o.SubItems.Contains(item.ClassName)))
        {
            builder.Append($"\n        public {item.ClassName}({inheritingItem.ClassName} other){{\n            ");
            builder.Append(props);
            builder.Append("\n        }");
        }

        return builder.ToString();
    }

    private string FormatExternalPropertiesUpdate(SchemaItem schemaItem, string targetClassName)
    {
        var updateCommands = new List<string>();
        if (schemaItem.Parent != null)
        {
            updateCommands.Add($"item.UpdateWith{schemaItem.Parent}(other);");
        }

        updateCommands.AddRange(FormatPropertyUpdates(schemaItem, "item.", targetClassName));
        return string.Join("\n            ", updateCommands);
    }

    private string FormatPropertyUpdates(SchemaItem schemaItem)
    {
        return string.Join("\n            ", FormatPropertyUpdates(schemaItem, "", ""));
    }

    private List<string> FormatPropertyUpdates(SchemaItem schemaItem, string prefix, string targetClassName)
    {
        if (schemaItem.Properties is null)
        {
            throw new CaffoaParserException($"No properties defined for object {schemaItem.Name}");
        }

        var updateCommands = schemaItem.Properties!.Select(property => FormatPropertyUpdate(property, prefix, targetClassName)).ToList();

        if (schemaItem.AdditionalPropertiesAllowed && _config.GenericAdditionalProperties is true)
            updateCommands.Add(
                $"{prefix}AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, {_config.GetGenericAdditionalPropertiesType()}>(other.AdditionalProperties) : null;");
        return updateCommands;
    }

    private static string FormatPropertyUpdate(PropertyData property, string prefix, string targetClassName)
    {
        var name = property.Name.ToObjectName();
        var sb = new StringBuilder();
        sb.Append(prefix);
        if (!string.IsNullOrEmpty(targetClassName))
            targetClassName += ".";
        if(property.CanBeEnum() && property.Nullable)
            sb.Append($"{name} = other.{name} is null ? null : ({targetClassName}{name}Value)other.{name}");
        else if(property.CanBeEnum())
            sb.Append($"{name} = ({targetClassName}{name}Value)other.{name}");
        else
            sb.Append($"{name} = other.{name}");

        if (property.IsOtherSchema)
        {
            if (property.Nullable)
                sb.Append('?');
            sb.Append($".To{property.TypeName.ToObjectName()}()");
        }

        if (property.IsArray)
        {
            if (property.InnerTypeIsOtherSchema)
                sb.Append($".Select(value=>value.To{property.TypeName.ToObjectName()}())");
            sb.Append(".ToList()");
        }
        else if (property.IsMap)
        {
            sb.Append(".ToDictionary(entry => entry.Key, entry => entry.Value");
            if (property.InnerTypeIsOtherSchema)
                sb.Append($".To{property.TypeName.ToObjectName()}()");
            sb.Append(')');
        }

        sb.Append(';');
        return sb.ToString();
    }

    private string FormatProperties(SchemaItem item)
    {
        var properties = new List<string>();
        if (item.Properties is null)
            return "";
        foreach (var property in item.Properties)
        {
            var formatter = new PropertyFormatter(property, _config.UseDateOnly ?? false);
            var format = new Dictionary<string, object>();
            format["DESCRIPTION"] = formatter.Description();
            format["JSON_EXTRA"] = formatter.JsonTags();
            format["JSON_PROPERTY_EXTRA"] = formatter.JsonProperty();
            format["TYPE"] = formatter.Type();
            format["NAMEUPPER"] = property.Name.ToObjectName();
            format["NAMELOWER"] = property.Name;
            if (_config.EnumsAsStaticValues is false && property.CanBeEnum())
            {
                properties.Add(FormatEnumProperty(property, format));
            }

            else if (property.CanBeStringEnum())
            {
                format["DEFAULT"] = formatter.Default(true);
                properties.Add(FormatEnumStringProperty(property, format));
            }

            else
            {
                format["DEFAULT"] = formatter.Default(false);
                var file = Templates.GetTemplate("ModelPropertyTemplate.tpl");
                var formatted = file.FormatDict(format);
                properties.Add(formatted);
            }
        }

        return string.Join("\n\n", properties);
    }

    private void WriteEnumClasses(SchemaItem item)
    {
        foreach (var property in item.Properties!.Where(p => p.Enums.Any()))
        {
            if (_config.EnumsAsStaticValues is false && property.CanBeEnum())
                WriteEnumClass(property, item.ClassName);
            else
                WriteEnumAsStringClass(property, item.ClassName);
        }
    }

    private string FormatEnumStringProperty(PropertyData property, Dictionary<string, object> format)
    {
        var file = Templates.GetTemplate("ModelEnumPropertyTemplate.tpl");
        if (_config.AcceptCaseInvariantEnums is true && property.TypeName == "string")
            format["TRANSFORM"] =
                $"{property.Name.ToObjectName()}Values.AllowedValues.FirstOrDefault(v=>String.Compare(v, value, StringComparison.OrdinalIgnoreCase) == 0, value)";
        else
            format["TRANSFORM"] = "value";
        format["NO_CHECK_MSG"] = _config.CheckEnums is true
            ? ""
            : "// set checkEnums=true in config file to have a value check here //\n                ";
        format["NO_CHECK"] = _config.CheckEnums!.Value ? "" : "// ";
        format["NULL_HANDLING"] = property.Nullable ? "v == null ? \"null\" : " : "";
        return file.FormatDict(format);
    }
    
    private static string FormatEnumProperty(PropertyData property, Dictionary<string, object> format)
    {
        var file = Templates.GetTemplate("ModelPropertyTemplate.tpl");
        var enumType = property.Name.ToObjectName() +"Value";
        var typeName = enumType;
        if (property.Nullable)
            typeName += "?";
        format["TYPE"] = typeName;
        var defaultValue = "";
        if (property.Default != null)
            defaultValue = $" = {enumType}.{EnumNameForValue(property.Default)};";
        format["DEFAULT"] = defaultValue;
        return file.FormatDict(format);
    }

    private static string EnumNameForValue(string value)
    {
        var cleaned = value.Replace("\"", "").FirstCharUpper();
        cleaned = Regex.Replace(cleaned, @"[^A-Za-z0-9]+", "_");
        if (char.IsDigit(cleaned[0]))
            cleaned = $"_{cleaned}";
        return cleaned;
    }
    private void WriteEnumAsStringClass(PropertyData property, string className)
    {
        var file = _config.RemoveDeprecated
            ? Templates.GetTemplate("ModelEnumPropertyClassTemplate.string.tpl")
            : Templates.GetTemplate("ModelEnumPropertyClassTemplate.deprecated.tpl");
        var enums = new Dictionary<string, string>();
        var obsoleteEnums = new Dictionary<string, string>();
        var propName = property.Name.ToObjectName();
        foreach (var value in property.Enums)
        {
            if (value == null)
                continue;
            var cleaned = EnumNameForValue(value);
            enums[cleaned] = value;
            var cleanName = value.Replace("\"", "").FirstCharUpper();
            cleanName = Regex.Replace(cleanName, @"[^A-Za-z0-9]+", "_");
            var obsoleteName = $"{propName}{cleanName}Value";
            obsoleteEnums[obsoleteName] = $"{propName}Values.{cleaned}";
        }

        var type = property.TypeName.Trim('?');
        var enumDefs = enums.Select(item => $"public const {type} {item.Key} = {item.Value};");

        var obsoleteEnumDefs = obsoleteEnums.Select(item =>
            $"[Obsolete(\"Will be removed in a future version of caffoa. Use {className}.{item.Value} instead.\")]\n        public const {type} {item.Key} = {item.Value};");
        var allowedNames = new List<string>(enums.Keys);
        if (property.Nullable)
            allowedNames.Add("null");
        var formatter = new PropertyFormatter(property, false);
        var format = new Dictionary<string, object>
        {
            ["NAMESPACE"] = _service.Model!.Namespace,
            ["CLASS"] = className,
            ["OBSOLETE_LIST_NAME"] = $"AllowedValuesFor{propName}",
            ["OBSOLETE_ENUMS"] = string.Join("\n        ", obsoleteEnumDefs),
            ["NAMEUPPER"] = propName,
            ["NAMELOWER"] = property.Name,
            ["TYPE"] = formatter.Type(),
            ["ENUMS"] = string.Join("\n            ", enumDefs),
            ["ENUM_NAMES"] = string.Join(", ", allowedNames)
        };
        string fileName = $"{className}.{propName}Values.generated.cs";
        var formatted = file.FormatDict(format);
        File.WriteAllText(Path.Combine(_service.Model!.TargetFolder, fileName), formatted.ToSystemNewLine());
    }

    private void WriteEnumClass(PropertyData property, string className)
    {
        var file = Templates.GetTemplate("ModelEnumPropertyClassTemplate.tpl");
        var enums = new Dictionary<string, string>();
        var propName = property.Name.ToObjectName() + "Value";
        foreach (var value in property.Enums)
        {
            if (value == null)
                continue;
            var cleaned = EnumNameForValue(value);
            enums[cleaned] = value;
        }

        var type = property.TypeName.Trim('?');
        IEnumerable<string> enumDefs;
        string enumbase = "";
        string jsonproperty = "";
        if (type == "string")
        {
            jsonproperty = "StringEnumConverter";
            enumDefs = enums.Select(item => $"[EnumMember(Value = {item.Value})] {item.Key}");
        }
        else
        {
            enumbase = $" : {type}";
            jsonproperty = $"CaffoaNumericEnumConverter<{propName}>";
            enumDefs = enums.Select(item => $"{item.Key} = {item.Value}");
        }

        var formatter = new PropertyFormatter(property, false);
        var format = new Dictionary<string, object>
        {
            ["NAMESPACE"] = _service.Model!.Namespace,
            ["CLASS"] = className,
            ["ENUMNAME"] = propName,
            ["NAMELOWER"] = property.Name,
            ["TYPE"] = formatter.Type(),
            ["ENUMS"] = string.Join(",\n            ", enumDefs),
            ["ENUMBASE"] = enumbase,
            ["JSONPROPERTY"] = jsonproperty
        };
        string fileName = $"{className}.{propName}.generated.cs";
        var formatted = file.FormatDict(format);
        File.WriteAllText(Path.Combine(_service.Model!.TargetFolder, fileName), formatted.ToSystemNewLine());
    }
}