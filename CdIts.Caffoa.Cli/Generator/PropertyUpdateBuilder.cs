using System.CodeDom.Compiler;
using System.Reflection;
using System.Text;
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
    public string ClassName { get; }
    public bool AllowAdditionalProperties { get; set; } = true;
    public bool ShallowCopy { get; set; }
    public bool AddDeepClone { get; set; }

    private PropertyUpdateBuilder(SchemaItem schemaItem, CaffoaConfig config, string className)
    {
        ClassName = className;
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
        foreach (var property in _schemaItem.Properties!)
        {
            if(!property.Generate)
                continue;
            if(_config.UseConstants is true && property.CanBeConstant())
                continue;
            var builder = new SinglePropertyUpdateBuilder(Prefix, ClassName, property,
                _config.GetEnumCreationMode() == CaffoaConfig.EnumCreationMode.Default, UseOther);
            if(!ShallowCopy)
                builder = builder.AppendOtherSchemaCopy()
                    .AppendJTokenDeepClone(_config.Flavor)
                    .AppendArrayCopy()
                    .AppendMapCopy();

            result.Add(builder.Build(AddDeepClone));
        }

        var other = UseOther ? "other." : "";
        if (AllowAdditionalProperties && _schemaItem.AdditionalPropertiesAllowed &&
            _config.GenericAdditionalProperties is true)
        {
            var builder = new StringBuilder($"{Prefix}AdditionalProperties = ");
            
            var deepClone =
                $"{other}AdditionalProperties != null ? new Dictionary<string, {_config.GetGenericAdditionalPropertiesType()}>({other}AdditionalProperties) : null";
            if(AddDeepClone)
                builder.Append($"deepClone ? ({deepClone}) : {other}AdditionalProperties");
            else if (ShallowCopy)
                builder.Append($"{other}AdditionalProperties");
            else
                builder.Append(deepClone);
            result.Add(builder.ToString());
        }

        return result;
    }

    

    public static string BuildConstructor(SchemaItem schemaItem, CaffoaConfig config, SchemaItem targetSchema)
    {
        var builder = new PropertyUpdateBuilder(schemaItem, config, targetSchema.ClassName)
        {
            AllowAdditionalProperties = targetSchema.AdditionalPropertiesAllowed
        };
        return builder.Build(";\n            ", ";");
    }
    public static string BuildSubConstructor(SchemaItem schemaItem, CaffoaConfig config, SchemaItem targetSchema)
    {
        var builder = new PropertyUpdateBuilder(schemaItem, config, targetSchema.ClassName)
        {
            AllowAdditionalProperties = targetSchema.AdditionalPropertiesAllowed,
            AddDeepClone = true
        };
        return builder.Build(";\n            ", ";");
    }

    public static string BuildInitializer(SchemaItem schemaItem, CaffoaConfig config, string className,
        bool otherAllowAdditionalProps)
    {
        var builder = new PropertyUpdateBuilder(schemaItem, config, className)
        {
            UseOther = true,
            AllowAdditionalProperties = otherAllowAdditionalProps,
            AddDeepClone = true
        };
        return builder.Build(",\n            ");
    }
    
    public static string BuildSelectInitializer(SchemaItem schemaItem, CaffoaConfig config, string className,
        bool otherAllowAdditionalProps)
    {
        var builder = new PropertyUpdateBuilder(schemaItem, config, className)
        {
            UseOther = true,
            AllowAdditionalProperties = otherAllowAdditionalProps,
            AddDeepClone = false,
            ShallowCopy = true
        };
        return builder.Build(",\n            ");
    }

    public static object BuildExternalUpdates(SchemaItem schemaItem, CaffoaGlobalConfig config, string className,
        bool otherAllowAdditionalProps)
    {
        var builder = new PropertyUpdateBuilder(schemaItem, config, className)
        {
            AllowAdditionalProperties = otherAllowAdditionalProps,
            Prefix = "item.",
            AddDeepClone = true
        };
        return builder.Build(";\n            ", ";");
    }
}