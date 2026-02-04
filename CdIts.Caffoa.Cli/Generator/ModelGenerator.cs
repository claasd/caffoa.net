using System.Text;
using System.Text.RegularExpressions;
using CdIts.Caffoa.Cli.Config;
using CdIts.Caffoa.Cli.Generator.Formatter;
using CdIts.Caffoa.Cli.Model;
using Microsoft.Extensions.Logging;

namespace CdIts.Caffoa.Cli.Generator;

public class ModelGenerator
{
    private readonly ServiceConfig _service;
    private readonly CaffoaGlobalConfig _config;
    private readonly ILogger _logger;

    public ModelGenerator(ServiceConfig service, CaffoaGlobalConfig mergedConfig, ILogger logger)
    {
        _service = service;
        _config = mergedConfig;
        _logger = logger;
    }

    public IEnumerable<string> WriteModel(List<SchemaItem> objects, IList<SchemaItem> otherKnownObjects)
    {
        Directory.CreateDirectory(_service.Model!.TargetFolder);
        var interfaces = objects.Where(o => o.Interface != null).ToList();
        var classes = objects.Where(o => o.Interface == null && o.Type == SchemaItem.ObjectType.Regular).ToList();
        var arrayClasses = objects.Where(o=>o.Type == SchemaItem.ObjectType.Array).ToList();
        var enumClasses = objects
            .Where(o => o.Type is SchemaItem.ObjectType.StringEnum).ToList();
        var enumProperties = objects.Where(o => o.Properties != null && o.Properties.Exists(p => p.Enums.Any())).ToList();
        enumProperties.ForEach(WriteEnumClasses);
        enumClasses.ForEach(WriteEnumClass);
        interfaces.ForEach(WriteModelInterface);
        arrayClasses.ForEach(c=>WriteArrayClass(c, interfaces));

        var allKnownClasses = otherKnownObjects.Concat(classes).ToList();
        var allKnownEnumClasses = enumClasses.Concat(otherKnownObjects.Where(o => o.Type == SchemaItem.ObjectType.StringEnum)).ToList();
        classes.ForEach(c => WriteModelClass(c, interfaces, allKnownClasses, allKnownEnumClasses));
        if (_config.Extensions is false)
            return Array.Empty<string>();
        return classes.Select(c => CreateModelExtensions(c, allKnownClasses)).Where(d => !string.IsNullOrEmpty(d)).Distinct();
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
        parameters["ATTRIBUTES"] = _config.Flavor switch
        {
            CaffoaConfig.GenerationFlavor.SystemTextJson => string.Join("\n    ",
                item.Interface!.Mapping.Select(c => $"[JsonDerivedType(typeof({c.Value}), \"{c.Key}\")]")),
            _ => JsonNetSubtypes(item.Interface!),
        }; //Needed to serialize interfaces. supported starting .NET 7. So only use when generating controllers.
        
        parameters["TYPE"] = 
        parameters["IMPORTS"] = PropertyFormatter.Imports(_config.Flavor, true);
        parameters["DISCRIMINATOR"] = item.Interface?.Discriminator != null ? $"[JsonIgnore]\n        string {item.Interface.Discriminator.ToObjectName()}Discriminator {{ get; }}\n        " : "";
        var formatted = file.FormatDict(parameters);
        File.WriteAllText(Path.Combine(_service.Model.TargetFolder, fileName), formatted.ToSystemNewLine());
    }

    private static string JsonNetSubtypes(InterfaceModel item)
    {
        var attributes = new StringBuilder($"\n    [JsonConverter(typeof(JsonSubtypes), \"{item.Discriminator}\")]");
        foreach (var (key, name) in item.Mapping)
        {
            attributes.Append($"\n    [JsonSubtypes.KnownSubType(typeof({name}), \"{key}\")]");
        }

        return attributes.ToString();
    }

    private void WriteModelClass(SchemaItem item, List<SchemaItem> interfaces,
        List<SchemaItem> otherClasses, List<SchemaItem> enumClasses)
    {
        var file = Templates.GetTemplate("ModelTemplate.tpl");
        var formatter = new SchemaItemFormatter(item, _config, otherClasses);
        var fileName = $"{item.ClassName}.generated.cs";
        var parameters = new Dictionary<string, object>();
        var seal = item.SealClass ?? _config.SealClasses(item.GenerateEqualsOverload);
        parameters["NAMESPACE"] = _service.Model!.Namespace;
        parameters["IMPORTS"] = formatter.Imports(_service.Model.Imports, _config.Imports);
        parameters["NAME"] = item.ClassName;
        parameters["PARENTS"] = formatter.Parents(interfaces);
        parameters["SEALED"] = seal ? " sealed " : "";
        parameters["INTERFACE_METHODS"] = formatter.InterfaceMethods(interfaces, seal);
        parameters["RAWNAME"] = item.Name;
        parameters["CONSTRUCTORS"] = CreateConstructors(item, otherClasses);
        parameters["EQUALS_METHODS"] = item.GenerateEqualsOverload ?? _config.GenerateEqualsMethods ?? true ? CreateEquals(item, enumClasses) : "";
        parameters["INHERIT_CONSTRUCTORS"] = _config.UseInheritance is true ? formatter.CreateConstructors(otherClasses) : "ARG";
        parameters["PROPERTIES"] = FormatProperties(item, enumClasses, interfaces);
        parameters["ADDITIONAL_PROPS"] = formatter.GenericAdditionalProperties();
        parameters["DESCRIPTION"] = formatter.Description;
        var formatted = file.FormatDict(parameters);
        File.WriteAllText(Path.Combine(_service.Model.TargetFolder, fileName), formatted.ToSystemNewLine());
    }
    
    private void WriteArrayClass(SchemaItem item, List<SchemaItem> interfaces)
    {
        var file = Templates.GetTemplate("ModelTemplate.tpl");
        var formatter = new SchemaItemFormatter(item, _config);
        var fileName = $"{item.ClassName}.generated.cs";
        var parameters = new Dictionary<string, object>();
        var seal = item.SealClass ?? _config.SealClasses(item.GenerateEqualsOverload);
        parameters["NAMESPACE"] = _service.Model!.Namespace;
        parameters["IMPORTS"] = formatter.Imports(_service.Model.Imports, _config.Imports);
        parameters["NAME"] = item.ClassName;
        parameters["PARENTS"] = formatter.Parents(interfaces);
        parameters["SEALED"] = seal ? " sealed " : "";
        parameters["INTERFACE_METHODS"] = formatter.InterfaceMethods(interfaces, seal);
        parameters["RAWNAME"] = item.Name;
        parameters["CONSTRUCTORS"] = CreateConstructors(item, null);
        parameters["EQUALS_METHODS"] = item.GenerateEqualsOverload ?? _config.GenerateEqualsMethods ?? true ? CreateEquals(item, null) : "";
        parameters["INHERIT_CONSTRUCTORS"] = "";
        parameters["PROPERTIES"] = "";
        parameters["ADDITIONAL_PROPS"] = "";
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
                var otherItem = otherSchemas.Find(i => i.ClassName == subItem);
                if (otherItem != null)
                {
                    data.Add(CreateModelExtension(otherItem, otherItem.ClassName, item.ClassName, item));
                    data.Add(CreateModelExtension(otherItem, item.ClassName, otherItem.ClassName, item));
                }
                else
                {
                    _logger.LogWarning(
                        $"Could not generate update extension for {item.ClassName} with parameter {subItem}");
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
        parameters["INITPROPS"] = PropertyUpdateBuilder.BuildInitializer(subItem, _config, sourceClassName, parentItem.AdditionalPropertiesAllowed);
        parameters["DEEPCLONEDEFAULT"] = _config.DeepCopyDefaultValue is false ? "false" : "true";
        parameters["SELECTPROPS"] =
            PropertyUpdateBuilder.BuildSelectInitializer(subItem, _config, sourceClassName, parentItem.AdditionalPropertiesAllowed);
        var formatted = file.FormatDict(parameters);
        return formatted.ToSystemNewLine();
    }

    private string CreateEquals(SchemaItem item, List<SchemaItem>? enumClasses)
    {
        enumClasses ??= new List<SchemaItem>();
        var builder = new StringBuilder();
        builder.Append($"        public bool Equals({item.ClassName} other) {{\n");
        builder.Append(
            "            if (ReferenceEquals(null, other)) return false;\n            if (ReferenceEquals(this, other)) return true;\n            ");
        bool first = true;
        var hashBuilder = new StringBuilder();
        
        foreach (var itemProperty in item.Properties!)
        {
            if(_config.UseConstants is true && itemProperty.CanBeConstant())
               continue;
            var isEnum = itemProperty.CanBeEnum() || enumClasses.Exists(ec=>ec.ClassName == itemProperty.TypeName);
            var isEnumWrapper = isEnum && _config.GetEnumCreationMode() == CaffoaConfig.EnumCreationMode.Class; 
            isEnum = isEnum && _config.GetEnumCreationMode() <= CaffoaConfig.EnumCreationMode.Default;
            builder.Append(first ? "var result = " : "\n                && ");
            var name = itemProperty.FieldName;
            if (item.Type == SchemaItem.ObjectType.Array)
            {
                builder.Append($"this.SequenceEqual(other)");
                hashBuilder.Append($"            hashCode.Add(base.GetHashCode());\n");
                continue;
            }
            else if (itemProperty.IsArray || itemProperty.IsMap)
            {
                builder.Append($"(other.{name} is null ? {name} is null : {name}?.SequenceEqual(other.{name}) ?? other.{name} is null)");
            }
            else if(itemProperty.TypeName.TrimEnd('?') is "string" or "int" or "double" or "decimal" or "boolean" or "real" or "long" or "bool" || isEnum)
                builder.Append($"{name} == other.{name}");
            else if(itemProperty.TypeName is "DateOnly" or "TimeOnly" or "DateTimeOffset" or "Guid" or "TimeSpan")
                builder.Append($"{name} == other.{name}");
            else
                builder.Append($"({name}?.Equals(other.{name}) ?? other.{name} is null)");

            var cast = isEnum && !itemProperty.IsMap && !itemProperty.IsArray ? "(int) " : "";
            var suffix = "";
            if (isEnumWrapper && !itemProperty.IsMap && !itemProperty.IsArray)
                suffix = ".Value";
            hashBuilder.Append($"            hashCode.Add({cast}{name}{suffix});\n");
            first = false;
        }

        builder.Append(";\n            if(result) _PartialEquals(other, ref result);\n");
        builder.Append("            return result;\n        }\n");
        builder.Append($"        partial void _PartialEquals({item.ClassName} other, ref bool result);\n");
        builder.Append($"        public override bool Equals(object obj) => Equals(obj as {item.ClassName});\n");
        builder.Append("        public override int GetHashCode() {\n            var hashCode = new HashCode();\n");
        builder.Append(hashBuilder);
        builder.Append("            _PartialHashCode(ref hashCode);\n");
        builder.Append("            return hashCode.ToHashCode();\n        }\n");
        builder.Append($"        partial void _PartialHashCode(ref HashCode hashCode);\n");
        if ((item.GenerateComparerOverload ?? _config.GenerateCompareOverloads) is true)
        {
            builder.Append($"        public static bool operator==({item.ClassName} a, {item.ClassName} b) => Equals(a, b);\n");
            builder.Append($"        public static bool operator!=({item.ClassName} a, {item.ClassName} b) => !Equals(a, b);\n");
        }
    return builder.ToString();
    }

    private string CreateConstructors(SchemaItem item, List<SchemaItem>? otherClasses)
    {
        var builder = new StringBuilder();
        var deepCloneDefault = _config.DeepCopyDefaultValue is false ? "false" : "true";
        builder.Append($"public {item.ClassName}({item.ClassName} other)");
        if (item.Parent != null)
            builder.Append($" : base(other)");
        if(item.Type == SchemaItem.ObjectType.Regular)
            builder.Append(" {\n            ").Append(PropertyUpdateBuilder.BuildConstructor(item, _config, item)).Append("\n        }");
        else
            builder.Append("{}");

        if (item.Parent != null)
        {
            builder.Append($"\n        public {item.ClassName}({item.Parent} other) : base(other) {{}}");
        }

        foreach (var subItem in item.SubItems)
        {
            var otherItem = otherClasses?.Find(c => c.ClassName == subItem);
            if (otherItem != null)
            {
                builder.Append($"\n        public {item.ClassName}({subItem} other, bool deepClone = {deepCloneDefault}) {{\n            ");
                builder.Append(PropertyUpdateBuilder.BuildSubConstructor(otherItem, _config, item));
                builder.Append("\n        }");
            }
            else
            {
                _logger.LogWarning(
                    $"Could not create constructor for class {item.ClassName} with parameter {subItem}");
            }
        }

        return builder.ToString();
    }

    private string FormatProperties(SchemaItem item, List<SchemaItem> enumClasses, List<SchemaItem> interfaces)
    {
        var properties = new List<string>();
        if (item.Properties is null)
            return "";
        foreach (var property in item.Properties)
        {
            if (!property.Generate)
                continue;
            var formatter = new PropertyFormatter(property, _config);
            var format = new Dictionary<string, object>();
            var type = formatter.Type();
            format["DESCRIPTION"] = formatter.Description();
            format["JSON_TAG_NAME"] = formatter.JsonTagName();
            format["JSON_EXTRA"] = formatter.JsonTags();
            format["JSON_PROPERTY_EXTRA"] = formatter.JsonProperty();
            format["JSON_EXTRA_PROPERTIES"] = formatter.JsonExtraProperties();
            format["TYPE"] = type;
            format["VIRTUAL"] = item.SealClass ?? _config.SealClasses(item.GenerateEqualsOverload) ? "" : " virtual";
            format["NAMEUPPER"] = property.FieldName;
            format["NAMELOWER"] = property.Name;

            if (property.Alias != null || property.AliasGet != null)
            {
                if (enumClasses.Find(c => c.ClassName == type)?.NullableEnum ?? false)
                    format["TYPE"] = type + "?";
                format["GETALIAS"] = property.AliasGet ?? property.Alias ?? "";
                if (property.AliasSet != null && property.AliasSet.Trim().StartsWith("{"))
                    format["SETALIAS"] = property.AliasSet;
                else if (property.AliasSet != null || property.Alias != null)
                    format["SETALIAS"] = "=> " + (property.AliasSet ?? $"{property.Alias} = value") + ";";
                else
                    format["SETALIAS"] ="{}";
                var file = Templates.GetTemplate("ModelPropertyAliasTemplate.tpl");
                var formatted = file.FormatDict(format);
                properties.Add(formatted);
            }
            else if (property.Delegate)
            {
                if (enumClasses.Find(c => c.ClassName == type)?.NullableEnum ?? false)
                    format["TYPE"] = type + "?";
                var file = Templates.GetTemplate("ModelPropertyDelegateTemplate.tpl");
                var formatted = file.FormatDict(format);
                properties.Add(formatted);
            }
            else if (_config.UseConstants is true && property.CanBeConstant())
            {
                format["DEFAULT"] = formatter.Default(true);
                var file = Templates.GetTemplate("ModelConstTemplate.tpl");
                var formatted = file.FormatDict(format);
                properties.Add(formatted);
            }

            else if (_config.GetEnumCreationMode() <= CaffoaConfig.EnumCreationMode.Default && property.CanBeEnum())
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
                format["DEFAULT"] = formatter.Default(false, enumClasses, interfaces, _config.ConstructorOnRequiredObjects is not false);
                var enumType = enumClasses.Find(c => c.ClassName == type);
                if (enumType != null)
                {
                    if(_config.EnumMode == CaffoaConfig.EnumCreationMode.Class)
                        format["TYPE"] = type = $"{type}Wrapper";
                    if(enumType.NullableEnum)
                        format["TYPE"] = type + "?";
                }
                else if(property is { Nullable: true, IsOtherSchema: false, IsArray: false, IsMap: false } && property.TypeName != "string")
                    format["TYPE"] = type.TrimEnd('?') + "?";
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
            if (_config.UseConstants is true && property.CanBeConstant())
                continue;
            if (_config.GetEnumCreationMode() <= CaffoaConfig.EnumCreationMode.Default && property.CanBeEnum())
                WriteEnumPropertyClass(property, item.ClassName);
            else if (property.CanBeEnum())
                WriteEnumAsStringClass(property, item.ClassName);
        }
    }

    private string FormatEnumStringProperty(PropertyData property, Dictionary<string, object> format)
    {
        var file = Templates.GetTemplate("ModelEnumPropertyTemplate.tpl");
        if (property.TypeName == "string")
            format["TRANSFORM"] =
                $"{property.FieldName}Values.AllowedValues.FirstOrDefault(v=>String.Compare(v, value, StringComparison.OrdinalIgnoreCase) == 0, value)";
        else
            format["TRANSFORM"] = "value";
        format["NO_CHECK_MSG"] = _config.GetEnumCreationMode() == CaffoaConfig.EnumCreationMode.StaticValues
            ? ""
            : "// set checkEnums=true in config file to have a value check here //\n                ";
        format["NO_CHECK"] = _config.GetEnumCreationMode() == CaffoaConfig.EnumCreationMode.StaticValues ? "" : "// ";
        format["NULL_HANDLING"] = property.Nullable ? "v == null ? \"null\" : " : "";
        return file.FormatDict(format);
    }

    private string FormatEnumProperty(PropertyData property, Dictionary<string, object> format)
    {
        var file = Templates.GetTemplate("ModelPropertyTemplate.tpl");
        var enumType = property.Name.ToObjectName() + "Value";
        var typeName = enumType;
        if(_config.EnumMode == CaffoaConfig.EnumCreationMode.Class)
            typeName = $"{enumType}Wrapper";
        if (property.Nullable)
            typeName += "?";
        format["TYPE"] = typeName;
        var defaultValue = "";
        if (property is { Default: not null, IsArray: false, IsMap: false })
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
            ["NAMEUPPER"] = property.FieldName,
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
        var file = Templates.GetTemplate(_config.EnumMode == CaffoaConfig.EnumCreationMode.Class ?"ModelEnumWrapperPropertyClassTemplate.tpl" : "ModelEnumPropertyClassTemplate.tpl");
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
        var enumDefs = new List<string>();
        string enumbase = "";
        string jsonproperty = "";
        if (type == "string")
        {
            jsonproperty = _config.Flavor switch
            {
                CaffoaConfig.GenerationFlavor.SystemTextJson => "JsonStringEnumConverter",
                _ => "StringEnumConverter",
            };
            foreach (var @enum in enums)
            {
                var init = "";
                if (property.EnumsAliases.TryGetValue(@enum.Value, out var alias))
                    init = $" = " + EnumNameForValue(alias);
                enumDefs.Add($"[EnumMember(Value = {@enum.Value})] {@enum.Key}{init}");
            }
        }
        else
        {
            enumbase = $" : {type}";
            jsonproperty = $"CaffoaNumericEnumConverter<{propName}>";
            enumDefs = enums.Select(item => $"{item.Key} = {item.Value}").ToList();
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
        var file = Templates.GetTemplate(_config.EnumMode == CaffoaConfig.EnumCreationMode.Class ? "ModelEnumClassWrapperTemplate.tpl" : "ModelEnumClassTemplate.tpl");
        var enums = new Dictionary<string, string>();
        foreach (var value in item.Enums)
        {
            if (value == null)
                continue;
            var cleaned = EnumNameForValue(value);
            enums[cleaned] = value;
        }

        List<string> enumDefs = new();
        string enumbase = "";
        string jsonproperty = "";
        if (item.Type == SchemaItem.ObjectType.StringEnum)
        {
            jsonproperty = "StringEnumConverter";
            foreach (var @enum in enums)
            {
                var init = "";
                if (item.EnumsAliases.TryGetValue(@enum.Value, out var alias))
                    init = $" = " + EnumNameForValue(alias);
                enumDefs.Add($"[EnumMember(Value = {@enum.Value})] {@enum.Key}{init}");
            }
        }
        else
        {
            enumbase = $" : {item.Type}";
            jsonproperty = $"CaffoaNumericEnumConverter<{item.ClassName}>";
            enumDefs = enums.Select(item => $"{item.Key} = {item.Value}").ToList();
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