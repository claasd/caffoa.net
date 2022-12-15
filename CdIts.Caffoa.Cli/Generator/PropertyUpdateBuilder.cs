using System.CodeDom.Compiler;
using System.Reflection;
using CdIts.Caffoa.Cli.Config;
using CdIts.Caffoa.Cli.Errors;
using CdIts.Caffoa.Cli.Model;

namespace CdIts.Caffoa.Cli.Generator;

public class PropertyUpdateBuilder
{
    private readonly SchemaItem _schemaItem;
    private readonly CaffoaConfig _config;
    public string Prefix { get; set; } = "";
    public bool UseOther { get; set; } = true;
    public string ClassName { get; set; }
    public bool AllowAdditionalProperties { get; set; } = true; 
    private PropertyUpdateBuilder(SchemaItem schemaItem,  CaffoaConfig config)
    {
        _schemaItem = schemaItem;
        _config = config;
        if (schemaItem.Properties is null)
        {
            throw new CaffoaParserException($"No properties defined for object {schemaItem.Name}");
        }
    }

    private string Build(string seperator, string extra = "")
    {
        return string.Join(seperator, Generate()) + extra;
    }

    private IEnumerable<string> Generate()
    {
        var result = new List<string>();
        foreach (var property in _schemaItem.Properties)
        {
            var data = new SinglePropertyUpdateBuilder(Prefix, ClassName, property,
                    _config.GetEnumCreationMode() == CaffoaConfig.EnumCreationMode.Default, UseOther)
                .AppendOtherSchemaCopy()
                .AppendJTokenDeepClone()
                .AppendArrayCopy()
                .AppendMapCopy()
                .Build();
            result.Add(data);
        }
        var other = UseOther ? "other." : "";
        if (AllowAdditionalProperties && _schemaItem.AdditionalPropertiesAllowed && _config.GenericAdditionalProperties is true)
            result.Add(
                $"{Prefix}AdditionalProperties = {other}AdditionalProperties != null ? new Dictionary<string, {_config.GetGenericAdditionalPropertiesType()}>({other}AdditionalProperties) : null");
        return result;
    }

    public static string BuildConstructor(SchemaItem schemaItem, CaffoaConfig config, SchemaItem targetSchema)
    {
        var builder = new PropertyUpdateBuilder(schemaItem, config)
        {
            ClassName = targetSchema.ClassName,
            AllowAdditionalProperties = targetSchema.AdditionalPropertiesAllowed
        };
        return builder.Build(";\n            ", ";");
    }

    public static string BuildInitializer(SchemaItem schemaItem, CaffoaConfig config, SchemaItem target)
    {
        var builder = new PropertyUpdateBuilder(schemaItem, config)
        {
            UseOther = false,
            ClassName = schemaItem.ClassName,
            AllowAdditionalProperties = target.AdditionalPropertiesAllowed
        };
        return builder.Build(",\n            ");
    }

    public static object BuildExternalUpdates(SchemaItem schemaItem, CaffoaGlobalConfig config, string className, bool otherAllowAdditionalProps)
    {
        var builder = new PropertyUpdateBuilder(schemaItem, config)
        {
            ClassName = className,
            AllowAdditionalProperties = otherAllowAdditionalProps,
            Prefix = "item."
        };
        return builder.Build(";\n            ", ";");
    }
}