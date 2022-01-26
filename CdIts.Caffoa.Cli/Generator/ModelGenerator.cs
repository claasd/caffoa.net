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
    private readonly CaffoaConfig _config;

    public ModelGenerator(ServiceConfig service, CaffoaConfig mergedConfig)
    {
        _service = service;
        _config = mergedConfig;
    }

    public void WriteModel(List<SchemaItem> objects)
    {
        Directory.CreateDirectory(_service.Model!.TargetFolder);
        var interfaces = objects.Where(o => o.Interface != null).ToList();
        var classes = objects.Where(o => o.Interface == null).ToList();
        interfaces.ForEach(WriteModelInterface);
        classes.ForEach(c=>WriteModelClass(c, interfaces));
    }

    private void WriteModelInterface(SchemaItem item)
    {
        var file = Templates.GetTemplate("ModelInterfaceTemplate.tpl");
        var fileName = $"{item.ClassName}.generated.cs";
        var formatter = new SchemaItemFormatter(item);
        var parameters = new Dictionary<string, object>();
        parameters["NAMESPACE"] = _service.Model!.Namespace;
        parameters["NAME"] = item.ClassName;
        parameters["DESCRIPTION"] = formatter.Description;
        parameters["TYPE"] = item.Interface?.Discriminator?.ToObjectName() ?? "";
        var formatted = file.FormatDict(parameters);
        File.WriteAllText(Path.Combine(_service.Model.TargetFolder, fileName), formatted.ToSystemNewLine());
    }

    private void WriteModelClass(SchemaItem item, List<SchemaItem> interfaces)
    {
        var file = Templates.GetTemplate("ModelTemplate.tpl");
        var formatter = new SchemaItemFormatter(item);
        var fileName = $"{item.ClassName}.generated.cs";
        var parameters = new Dictionary<string, object>();
        parameters["NAMESPACE"] = _service.Model!.Namespace;
        parameters["IMPORTS"] = formatter.Imports(_service.Model.Imports, _config.Imports);
        parameters["NAME"] = item.ClassName;
        parameters["PARENTS"] = formatter.Parents(interfaces);
        parameters["RAWNAME"] = item.Name;
        parameters["UPDATEPROPS"] = FormatPropertyUpdates(item);
        parameters["PROPERTIES"] = FormatProperties(item);
        parameters["DESCRIPTION"] = formatter.Description;
        var formatted = file.FormatDict(parameters);
        File.WriteAllText(Path.Combine(_service.Model.TargetFolder, fileName), formatted.ToSystemNewLine());
    }

    private string FormatPropertyUpdates(SchemaItem schemaItem)
    {
        var updateCommands = new List<string>();
        if (schemaItem.Parent != null)
        {
            updateCommands.Add($"UpdateWith{schemaItem.Parent}(other);");
        }

        if (schemaItem.Properties is null)
            throw new CaffoaParserError($"No properties defined for object {schemaItem.Name}");
        foreach (var property in schemaItem.Properties!)
        {
            var name = property.Name.ToObjectName();
            var sb = new StringBuilder();
            sb.Append($"{name} = other.{name}");
            if (property.IsArray)
                sb.Append(".ToList()");
            if (property.IsOtherSchema)
            {
                if (property.Nullable)
                    sb.Append('?');
                sb.Append($".To{property.TypeName.ToObjectName()}()");
            }
            sb.Append(';');
            updateCommands.Add(sb.ToString());
        }

        return string.Join("\n            ", updateCommands);
    }

    private string FormatProperties(SchemaItem item)
    {
        var properties = new List<string>();
        foreach (var property in item.Properties!)
        {
            var formatter = new PropertyFormatter(property, _config.UseDateOnly ?? false);
            var format = new Dictionary<string, object>();
            format["DESCRIPTION"] = formatter.Description();
            format["JSON_EXTRA"] = formatter.JsonTags();
            format["JSON_PROPERTY_EXTRA"] = formatter.JsonProperty();
            format["TYPE"] = formatter.Type();
            format["NAMEUPPER"] = property.Name.ToObjectName();
            format["NAMELOWER"] = property.Name;
            if (property.Enums.Count > 0)
            {
                format["DEFAULT"] = formatter.Default(true);
                properties.Add(FormatEnumProperty(property, format));
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

    private string FormatEnumProperty(PropertyData property, Dictionary<string,object> format)
    { 
        var file = Templates.GetTemplate("ModelEnumPropertyTemplate.tpl");
        var enums = new Dictionary<string, string>();
        var propName = property.Name.ToObjectName();
        foreach (var value in property.Enums)
        {
            if(value == null)
                continue;
            var cleaned = value.Replace("\"", "").FirstCharUpper();
            cleaned = Regex.Replace(cleaned, @"[^A-Za-z0-9]+", "_");
            var name = $"{propName}{cleaned}Value";
            enums[name] = value;
        }

        var type = property.TypeName.Trim('?');
        var enumDefs = enums.Select(item => $"public const {type} {item.Key} = {item.Value};");
        var allowedNames = new List<string>(enums.Keys);
        if(property.Nullable)
            allowedNames.Add("null");
        format["ENUMS"] = string.Join("\n        ", enumDefs);
        format["ENUM_LIST_NAME"] = $"AllowedValuesFor{propName}";
        format["ENUM_NAMES"] = string.Join(", ", allowedNames);
        format["NO_CHECK_MSG"] = _config.CheckEnums!.Value ? "" : "// set checkEnums=true in config file to have a value check here //\n                ";
        format["NO_CHECK"] = _config.CheckEnums!.Value ? "" : "// ";
        format["NULL_HANDLING"] = property.Nullable ? "v == null ? \"null\" : " : "";
        return file.FormatDict(format);
    }
}