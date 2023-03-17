using CdIts.Caffoa.Cli.Config;
using CdIts.Caffoa.Cli.Model;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace CdIts.Caffoa.Cli.Parser;

public class ObjectStandaloneParser : ObjectParser
{
    public ObjectStandaloneParser(SchemaItem item, CaffoaConfig.EnumCreationMode enumMode,
        Func<string, string> classNameGenerator, ILogger logger) : base(item, enumMode, classNameGenerator, logger)
    {
    }

    protected override OpenApiSchema UpdateSchemaForAllOff(OpenApiSchema schema)
    {
        AddSubProperties(schema.AllOf, schema.Properties);
        Item.SubItems = SubItems(schema.AllOf);
        return schema;
    }

    private void AddSubProperties(IList<OpenApiSchema> schemaAllOf, IDictionary<string, OpenApiSchema> properties)
    {
        foreach (var subSchema in schemaAllOf.Select(ResolveExternal))
        {
            if (subSchema.AllOf.Any())
            {
                AddSubProperties(subSchema.AllOf, properties);
            }
            else
            {
                foreach (var (key, value) in subSchema.Properties)
                {
                    properties[key] = value;
                }
            }
        }
    }

    private List<string> SubItems(IList<OpenApiSchema> schemas)
    {
        var result = new List<string>();
        foreach (var schema in schemas)
        {
            if (schema.Reference != null)
                result.Add(ClassNameFunc(schema.Reference.Name()));
            result.AddRange(SubItems(schema.AllOf));
            result.AddRange(SubItems(schema.OneOf));
        }

        return result;
    }
}