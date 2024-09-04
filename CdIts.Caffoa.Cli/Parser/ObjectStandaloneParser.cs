using CdIts.Caffoa.Cli.Config;
using CdIts.Caffoa.Cli.Model;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace CdIts.Caffoa.Cli.Parser;

public class ObjectStandaloneParser : ObjectParser
{
    public ObjectStandaloneParser(SchemaItem item, CaffoaConfig.EnumCreationMode enumMode,
        Func<string, string> classNameGenerator, bool nullableIsDefault) : base(item, enumMode, classNameGenerator, nullableIsDefault)
    {
    }

    protected override OpenApiSchema UpdateSchemaForAllOff(OpenApiSchema schema)
    {
        AddSubProperties(schema.AllOf, schema.Properties, schema.Required);
        Item.SubItems = SubItems(schema.AllOf);
        return schema;
    }
    
    protected override OpenApiSchema UpdateSchemaForAnyOff(OpenApiSchema schema)
    {
        AddSubProperties(schema.AnyOf, schema.Properties, new HashSet<string>());
        Item.SubItems = SubItems(schema.AnyOf);
        foreach (var property in schema.Properties)
        {
            property.Value.Nullable = true;
        }
        return schema;
    }

    private void AddSubProperties(IList<OpenApiSchema> schemaAllOf, IDictionary<string, OpenApiSchema> properties, ISet<string> required)
    {
        foreach (var subSchema in schemaAllOf.Select(ResolveExternal))
        {
            if (subSchema.AllOf.Any())
            {
                AddSubProperties(subSchema.AllOf, properties,required);
            }
            if (subSchema.AnyOf.Any())
            {
                AddSubProperties(subSchema.AllOf, properties,required);
            }
            else
            {
                foreach (var (key, value) in subSchema.Properties)
                {
                    properties[key] = value;
                }

                foreach (var subRequired in subSchema.Required)
                {
                    required.Add(subRequired);
                }
            }
        }
    }

    private List<string> SubItems(IList<OpenApiSchema> schemas)
    {
        var result = new List<string>();
        foreach (var schema in schemas)
        {
            var resolved = ResolveExternal(schema);
            if (resolved.Reference != null)
                result.Add(ClassNameFunc(resolved.Reference.Name()));
            result.AddRange(SubItems(resolved.AllOf));
            result.AddRange(SubItems(resolved.AnyOf));
            result.AddRange(SubItems(resolved.OneOf));
        }

        return result;
    }
}