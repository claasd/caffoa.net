using CdIts.Caffoa.Cli.Model;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace CdIts.Caffoa.Cli.Parser;

public class ObjectStandaloneParser : ObjectParser
{
    public ObjectStandaloneParser(SchemaItem item, IDictionary<string, OpenApiSchema> knownTypes,
        Func<string, string> classNameGenerator, ILogger logger) : base(item, knownTypes, classNameGenerator, logger)
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

    public static OpenApiSchema ResolveExternal(OpenApiSchema subSchema)
    {
        if (subSchema.Reference?.IsExternal ?? false)
        {
            var result = subSchema.Reference.HostDocument.Workspace.ResolveReference(subSchema.Reference);
            var schema = result as OpenApiSchema;
            if (schema != null)
                return schema;
        }

        return subSchema;
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