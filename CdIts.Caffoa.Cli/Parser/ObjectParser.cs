using CdIts.Caffoa.Cli.Errors;
using CdIts.Caffoa.Cli.Model;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Interfaces;
using Microsoft.OpenApi.Models;

namespace CdIts.Caffoa.Cli.Parser;

public class ObjectParser
{
    private readonly Func<string, string> _classNameFunc;
    private readonly SchemaItem _item;
    private readonly IDictionary<string, OpenApiSchema> _knownTypes;

    public ObjectParser(SchemaItem item, IDictionary<string, OpenApiSchema> knownTypes,
        Func<string, string> classNameGenerator)
    {
        _item = item;
        _knownTypes = knownTypes;
        _classNameFunc = classNameGenerator;
    }


    public SchemaItem Parse(OpenApiSchema schema)
    {
        if (schema.AllOf.Count > 0)
            (schema, _item.Parent) = UpdateSchemaForAllOff(schema.AllOf);
        if (schema.OneOf.Count > 0)
            _item.Interface = ExtractInterface(schema.OneOf, schema.Discriminator);

        else if (schema.Properties.Count > 0)
        {
            _item.Properties = schema.Properties
                .Select(item => ParseProperty(item.Key, item.Value, schema.Required.Contains(item.Key))).ToList();
            _item.AdditionalPropertiesAllowed = schema.AdditionalPropertiesAllowed;
        }

        _item.Description = schema.Description;
        return _item;
    }

    private PropertyData ParseProperty(string name, OpenApiSchema schema, bool required)
    {
        var property = new PropertyData(name, required);
        property.Deprecated = schema.Deprecated;
        try
        {
            property.CustomAttributes = ParseCustomAttributes(schema.Extensions);
        }
        catch (CaffoaParserError e)
        {
            Console.Error.WriteLine($"Could not parse custom attributes of {name}: {e.Message}");
        }
        
        if (schema.Extensions.TryGetValue("x-caffoa-converter", out var converter))
        {
            if (converter is OpenApiString converterStr)
                property.Converter = converterStr.Value;
            else
                Console.Error.WriteLine($"Could not parse custom converter of {name}: value is not a string");
        }

        if (schema.Reference != null &&
            _knownTypes.TryGetValue(_classNameFunc(schema.Reference.Name()), out var knownSchema))
        {
            schema = knownSchema;
            schema.Reference = null;
        }

        property.Description = schema.Description;
        property.Nullable = schema.Nullable;
        if (schema.Reference != null)
        {
            property.TypeName = _classNameFunc(schema.Reference.Name());
            property.Nullable = !required;
            property.IsOtherSchema = true;
        }
        else if (schema.IsArray())
        {
            property.IsArray = true;
            property.TypeName = schema.GetArrayType(_classNameFunc);
        }
        else if (schema.AdditionalProperties != null)
        {
            if (schema.Properties.Count > 0)
                throw new CaffoaParserError(
                    "object with properties and additional properties are currently not supported.");
            if (schema.AdditionalProperties.Reference != null)
            {
                property.TypeName = _classNameFunc(schema.AdditionalProperties.Reference.Name());
            }
            else
            {
                property.TypeName = schema.AdditionalProperties.TypeName();
            }

            property.IsMap = true;
        }
        else if (schema.Properties == null)
        {
            throw new CaffoaParserError(
                "object without any properties are currently not supported.");
        }
        else
        {
            property.TypeName = schema.TypeName();
            property.Default = schema.DefaultAsString();
            property.Enums = schema.EnumsAsStrings();
        }

        return property;
    }

    private List<string> ParseCustomAttributes(IDictionary<string, IOpenApiExtension> extensions)
    {
        if (!extensions.TryGetValue("x-caffoa-attributes", out var annotations))
            return new List<string>();
        var annotationsArray = annotations as OpenApiArray;
        if (annotationsArray is null)
            throw new CaffoaParserError("Not an array");
        return annotationsArray.Select(item =>
        {
            var strItem = item as OpenApiString ?? throw new CaffoaParserError("one item is not a string");
            return strItem.Value;
        }).ToList();
    }

    private InterfaceModel ExtractInterface(IList<OpenApiSchema> schemaOneOf, OpenApiDiscriminator openApiDiscriminator)
    {
        if (openApiDiscriminator.PropertyName is null)
            throw new CaffoaParserError("cannot create oneOf interface without discriminator property");
        var model = new InterfaceModel
        {
            Discriminator = openApiDiscriminator.PropertyName
        };
        foreach (var schema in schemaOneOf)
        {
            if (schema.Reference is null)
                throw new CaffoaParserError("did not find $ref as child of oneOf");
            model.Children.Add(_classNameFunc(schema.Reference.Name()));
        }

        return model;
    }

    private (OpenApiSchema, string?) UpdateSchemaForAllOff(IList<OpenApiSchema> schemas)
    {
        string? parent = null;
        OpenApiSchema? newSchema = null;
        foreach (var schema in schemas)
        {
            if (schema.Reference != null)
            {
                if (parent != null)
                    throw new CaffoaParserError(
                        "allOf is implemented as inheritance; cannot have to children with $ref");
                parent = _classNameFunc(schema.Reference.Name());
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
            throw new CaffoaParserError("Cannot create class without content, no child of allOf is type object");
        return (newSchema, parent);
    }
}
