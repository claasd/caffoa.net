using CdIts.Caffoa.Cli.Model;
using Microsoft.OpenApi.Models;

namespace CdIts.Caffoa.Cli.Parser;

public class ObjectStandaloneParser : ObjectParser
{
    public ObjectStandaloneParser(SchemaItem item, IDictionary<string, OpenApiSchema> knownTypes,
        Func<string, string> classNameGenerator) : base(item, knownTypes, classNameGenerator)
    {
    }

    protected override OpenApiSchema UpdateSchemaForAllOff(OpenApiSchema schema)
    {
        foreach (var subSchema in schema.AllOf)
        {
            foreach (var (key, value) in subSchema.Properties)
            {
                schema.Properties[key] = value;
            }
        }

        Item.SubItems = SubItems(schema.AllOf);
        return schema;
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
