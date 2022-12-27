using System.Text;
using System.Text.RegularExpressions;
using CdIts.Caffoa.Cli.Config;
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

    public IEnumerable<string> WriteModel(List<SchemaItem> objects, IEnumerable<SchemaItem> otherKnownObjects)
    {
        Directory.CreateDirectory(_service.Model!.TargetFolder);
        var interfaces = objects.Where(o => o.Interface != null).ToList();
        var classes = objects.Where(o => o.Interface == null && o.Type == SchemaItem.ObjectType.Regular).ToList();
        var enumClasses = objects
            .Where(o => o.Type == SchemaItem.ObjectType.StringEnum).ToList();
        var enumProperties = objects.Where(o => o.Properties != null && o.Properties.Any(p => p.Enums.Any())).ToList();
        enumProperties.ForEach(WriteEnumClasses);
        enumClasses.ForEach(WriteEnumClass);
        interfaces.ForEach(WriteModelInterface);
        var allKnownClasses = otherKnownObjects.Concat(classes).ToList();
        classes.ForEach(c => WriteModelClass(c, interfaces, allKnownClasses));
        if (_config.Extensions is false)
            return Array.Empty<string>();
        return classes.Select(c => CreateModelExtensions(c, allKnownClasses)).Where(d => !string.IsNullOrEmpty(d));
    }

    private void WriteModelInterface(SchemaItem item)
    {
        var file = Templates.GetTemplate("ModelInterfaceTemplate.tpl");
        var fileName = $"{item.ClassName}.generated.cs";
        var formatter = new SchemaItemFormatter(item, _config, new List<SchemaItem>());
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
        var formatter = new SchemaItemFormatter(item, _config, otherClasses);
        var fileName = $"{item.ClassName}.generated.cs";
        var parameters = new Dictionary<string, object>();
        parameters["NAMESPACE"] = _service.Model!.Namespace;
        parameters["IMPORTS"] = formatter.Imports(_service.Model.Imports, _config.Imports);
        parameters["NAME"] = item.ClassName;
        parameters["PARENTS"] = formatter.Parents(interfaces);
        parameters["INTERFACE_METHODS"] = formatter.InterfaceMethods(interfaces);
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
        data.Add(CreateModelExtension(item, item.ClassName, item.ClassName, item));
        if (_config.UseInheritance is false)
        {
            foreach (var subItem in item.SubItems)
            {
                var otherItem = otherSchemas.FirstOrDefault(i => i.ClassName == subItem);
                if (otherItem != null)
                {
                    data.Add(CreateModelExtension(otherItem, otherItem.ClassName, item.ClassName, item));
                    data.Add(CreateModelExtension(otherItem, item.ClassName, otherItem.ClassName, item));
                }
                else
                {
                    Console.Error.WriteLine(
                        $"Warning: Could not generate update extension for {item.ClassName} with parameter {subItem}");
                }
            }
        }

        return string.Join("\n\n", data);
    }

    private string CreateModelExtension(SchemaItem subItem, string targetClassName, string sourceClassName,
        SchemaItem parentItem)
    {
        string file;
        file = Templates.GetTemplate("ModelExtensionContentTemplate.tpl");
        var parameters = new Dictionary<string, object>();
        parameters["NAME"] = targetClassName;
        parameters["OTHER"] = sourceClassName;
        parameters["UPDATEPROPS"] = PropertyUpdateBuilder.BuildExternalUpdates(subItem, _config, targetClassName,
            parentItem.AdditionalPropertiesAllowed);
        var formatted = file.FormatDict(parameters);
        return formatted.ToSystemNewLine();
    }

    private string CreateConstructors(SchemaItem item, List<SchemaItem> otherClasses)
    {
        var builder = new StringBuilder();
        builder.Append($"public {item.ClassName}({item.ClassName} other)");
        if (item.Parent != null)
            builder.Append($" : base(other)");
        builder.Append(" {\n            ");
        builder.Append(PropertyUpdateBuilder.BuildConstructor(item, _config, item));
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
                builder.Append(PropertyUpdateBuilder.BuildConstructor(otherItem, _config, item));
                builder.Append("\n        }");

                builder.Append($"\n        public {subItem} To{subItem}() => new {subItem}() {{\n            ");
                builder.Append(PropertyUpdateBuilder.BuildInitializer(otherItem, _config, item));
                builder.Append("\n        };");
            }
            else
            {
                Console.Error.WriteLine(
                    $"WARNING: Cloud not create constructor for class {item.ClassName} with parameter {subItem}");
            }
        }

        return builder.ToString();
    }

    private string FormatProperties(SchemaItem item)
    {
        var properties = new List<string>();
        if (item.Properties is null)
            return "";
        foreach (var property in item.Properties)
        {
            var formatter = new PropertyFormatter(property, _config);
            var format = new Dictionary<string, object>();
            format["DESCRIPTION"] = formatter.Description();
            format["JSON_TAG_NAME"] = formatter.JsonTagName();
            format["JSON_EXTRA"] = formatter.JsonTags();
            format["JSON_PROPERTY_EXTRA"] = formatter.JsonProperty();
            format["JSON_EXTRA_PROPERTIES"] = formatter.JsonExtraProperties();
            format["TYPE"] = formatter.Type();
            format["NAMEUPPER"] = property.Name.ToObjectName();
            format["NAMELOWER"] = property.Name;

            if (_config.GetEnumCreationMode() == CaffoaConfig.EnumCreationMode.Default && property.CanBeEnum())
            {
                properties.Add(FormatEnumProperty(property, format));
            }

            else if (property.CanBeEnum())
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
            if (_config.GetEnumCreationMode() == CaffoaConfig.EnumCreationMode.Default && property.CanBeEnum())
                WriteEnumPropertyClass(property, item.ClassName);
            else if(property.CanBeEnum())
                WriteEnumAsStringClass(property, item.ClassName);
        }
    }

    private string FormatEnumStringProperty(PropertyData property, Dictionary<string, object> format)
    {
        var file = Templates.GetTemplate("ModelEnumPropertyTemplate.tpl");
        if (property.TypeName == "string")
            format["TRANSFORM"] =
                $"{property.Name.ToObjectName()}Values.AllowedValues.FirstOrDefault(v=>String.Compare(v, value, StringComparison.OrdinalIgnoreCase) == 0, value)";
        else
            format["TRANSFORM"] = "value";
        format["NO_CHECK_MSG"] = _config.GetEnumCreationMode() == CaffoaConfig.EnumCreationMode.StaticValues
            ? ""
            : "// set checkEnums=true in config file to have a value check here //\n                ";
        format["NO_CHECK"] = _config.GetEnumCreationMode() == CaffoaConfig.EnumCreationMode.StaticValues ? "" : "// ";
        format["NULL_HANDLING"] = property.Nullable ? "v == null ? \"null\" : " : "";
        return file.FormatDict(format);
    }

    private static string FormatEnumProperty(PropertyData property, Dictionary<string, object> format)
    {
        var file = Templates.GetTemplate("ModelPropertyTemplate.tpl");
        var enumType = property.Name.ToObjectName() + "Value";
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

    public static string EnumNameForValue(string value)
    {
        var cleaned = value.Replace("\"", "").FirstCharUpper();
        cleaned = Regex.Replace(cleaned, @"[^A-Za-z0-9]+", "_");
        if (char.IsDigit(cleaned[0]))
            cleaned = $"_{cleaned}";
        return cleaned;
    }

    private void WriteEnumAsStringClass(PropertyData property, string className)
    {
        var file = Templates.GetTemplate("ModelEnumPropertyClassTemplate.string.tpl");
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
        var formatter = new PropertyFormatter(property, _config);
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

    private void WriteEnumPropertyClass(PropertyData property, string className)
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

        var formatter = new PropertyFormatter(property, _config);
        var format = new Dictionary<string, object>
        {
            ["NAMESPACE"] = _service.Model!.Namespace,
            ["CLASS"] = className,
            ["ENUMNAME"] = propName,
            ["NAMELOWER"] = property.Name,
            ["TYPE"] = formatter.Type(),
            ["ENUMS"] = string.Join(",\n            ", enumDefs),
            ["ENUMBASE"] = enumbase,
            ["JSONPROPERTY"] = jsonproperty,
            ["IMPORTS"] = formatter.Imports()
        };
        string fileName = $"{className}.{propName}.generated.cs";
        var formatted = file.FormatDict(format);
        File.WriteAllText(Path.Combine(_service.Model!.TargetFolder, fileName), formatted.ToSystemNewLine());
    }

    private void WriteEnumClass(SchemaItem item)
    {
        var file = Templates.GetTemplate("ModelEnumClassTemplate.tpl");
        var enums = new Dictionary<string, string>();
        foreach (var value in item.Enums)
        {
            if (value == null)
                continue;
            var cleaned = EnumNameForValue(value);
            enums[cleaned] = value;
        }

        IEnumerable<string> enumDefs;
        string enumbase = "";
        string jsonproperty = "";
        if (item.Type == SchemaItem.ObjectType.StringEnum)
        {
            jsonproperty = "StringEnumConverter";
            enumDefs = enums.Select(item => $"[EnumMember(Value = {item.Value})] {item.Key}");
        }
        else
        {
            enumbase = $" : {item.Type}";
            jsonproperty = $"CaffoaNumericEnumConverter<{item.ClassName}>";
            enumDefs = enums.Select(item => $"{item.Key} = {item.Value}");
        }

        var format = new Dictionary<string, object>
        {
            ["NAMESPACE"] = _service.Model!.Namespace,
            ["ENUMNAME"] = item.ClassName,
            ["ENUMS"] = string.Join(",\n        ", enumDefs),
            ["ENUMBASE"] = enumbase,
            ["JSONPROPERTY"] = jsonproperty,
            ["IMPORTS"] = PropertyFormatter.Imports(_config.Flavor)
        };
        string fileName = $"{item.ClassName}.generated.cs";
        var formatted = file.FormatDict(format);
        File.WriteAllText(Path.Combine(_service.Model!.TargetFolder, fileName), formatted.ToSystemNewLine());
    }
}