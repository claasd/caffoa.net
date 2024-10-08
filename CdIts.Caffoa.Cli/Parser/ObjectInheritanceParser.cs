using CdIts.Caffoa.Cli.Config;
using CdIts.Caffoa.Cli.Errors;
using CdIts.Caffoa.Cli.Model;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace CdIts.Caffoa.Cli.Parser;

public class ObjectInheritanceParser : ObjectParser
{
    public ObjectInheritanceParser(SchemaItem item, CaffoaConfig.EnumCreationMode enumMode,
        Func<string, string> classNameGenerator, bool nullableIsDefault) : base(item, enumMode, classNameGenerator, nullableIsDefault)
    {
    }

    protected override OpenApiSchema UpdateSchemaForAllOff(OpenApiSchema schema)
    {
        string? parent = null;
        OpenApiSchema? newSchema = null;
        foreach (var localSchema in schema.AllOf)
        {
            if (localSchema.Reference != null)
            {
                if (parent != null)
                    throw new CaffoaParserException(
                        "allOf is implemented as inheritance; cannot have two children with $ref");
                parent = ClassNameFunc(localSchema.Reference.Name());
            }
            else
            {
                if (newSchema != null)
                    throw new CaffoaParserException(
                        "allOf is implemented as inheritance; cannot have to children of allOf with direct implementation");
                newSchema = localSchema;
            }
        }

        if (newSchema is null)
            throw new CaffoaParserException("allOf is implemented as inheritance; Cannot create class without content, no child of allOf is type object");
        Item.Parent = parent;
        return newSchema;
    }

    protected override OpenApiSchema UpdateSchemaForAnyOff(OpenApiSchema schema)
    {
        throw new CaffoaParserException("anyOf is not supported in inheritance mode");
    }
}
