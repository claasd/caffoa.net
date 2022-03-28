using CdIts.Caffoa.Cli.Errors;
using CdIts.Caffoa.Cli.Model;
using Microsoft.OpenApi.Models;

namespace CdIts.Caffoa.Cli.Parser;

public class ObjectInheritanceParser : ObjectParser
{
    public ObjectInheritanceParser(SchemaItem item, IDictionary<string, OpenApiSchema> knownTypes, Func<string, string> classNameGenerator) : base(item, knownTypes, classNameGenerator)
    {
    }

    protected override OpenApiSchema UpdateSchemaForAllOff(OpenApiSchema originalSchema)
    {
        string? parent = null;
        OpenApiSchema? newSchema = null;
        foreach (var schema in originalSchema.AllOf)
        {
            if (schema.Reference != null)
            {
                if (parent != null)
                    throw new CaffoaParserError(
                        "allOf is implemented as inheritance; cannot have two children with $ref");
                parent = ClassNameFunc(schema.Reference.Name());
            }
            else
            {
                if (newSchema != null)
                    throw new CaffoaParserError(
                        "allOf is implemented as inheritance; cannot have to children of allOf with direct implementation");
                newSchema = schema;
            }
        }

        if (newSchema is null)
            throw new CaffoaParserError("allOf is implemented as inheritance; Cannot create class without content, no child of allOf is type object");
        Item.Parent = parent;
        return newSchema;
    }
}
