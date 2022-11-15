using CdIts.Caffoa.Cli.Errors;
using CdIts.Caffoa.Cli.Model;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Interfaces;
using Microsoft.OpenApi.Models;

namespace CdIts.Caffoa.Cli.Parser;

public abstract class ObjectParser
{
    protected readonly Func<string, string> ClassNameFunc;
    protected readonly SchemaItem Item;
    private readonly IDictionary<string, OpenApiSchema> _knownTypes;

    protected ObjectParser(SchemaItem item, IDictionary<string, OpenApiSchema> knownTypes,
        Func<string, string> classNameGenerator)
    {
        Item = item;
        _knownTypes = knownTypes;
        ClassNameFunc = classNameGenerator;
    }

    public SchemaItem Parse(OpenApiSchema schema)
    {
        try
        {
            if (schema.AllOf.Count > 0)
                schema = UpdateSchemaForAllOff(schema);
            if (schema.OneOf.Count > 0)
                Item.Interface = ExtractInterface(schema.OneOf, schema.Discriminator);

            else if (schema.Properties.Count > 0)
            {
                Item.Properties = schema.Properties
                    .Select(item => ParseProperty(item.Key, item.Value, schema.Required.Contains(item.Key))).ToList();
                Item.AdditionalPropertiesAllowed = schema.AdditionalPropertiesAllowed;
            }

            Item.Description = schema.Description;
            return Item;
        }
        catch (CaffoaParserException e)
        {
            throw new CaffoaParserException($"Error during parsing of object {Item.Name}: {e.Message}", e);
        }
    }

    private PropertyData ParseProperty(string name, OpenApiSchema schema, bool required)
    {
        if (schema.AnyOf.Any())
            throw new CaffoaParserException("anyOf is not supported on object properties");
        var property = new PropertyData(name, required);
        property.Deprecated = schema.Deprecated;
        property.CustomAttributes = ParseCustomAttributes(schema.Extensions, name);
        property.Converter = ParseCustomConverter(schema.Extensions, name);
    

        if (schema.Reference != null &&
            _knownTypes.TryGetValue(ClassNameFunc(schema.Reference.Name()), out var knownSchema))
        {
            schema = knownSchema;
            schema.Reference = null;
        }

        property.Description = schema.Description;
        property.Nullable = schema.Nullable;
        if (schema.Reference != null)
        {
            property.TypeName = ClassNameFunc(schema.Reference.Name());
            property.Nullable = !required;
            property.IsOtherSchema = true;
        }
        else if (schema.IsArray())
        {
            property.IsArray = true;
            property.TypeName = schema.GetArrayType(ClassNameFunc, _knownTypes);
            property.InnerTypeIsOtherSchema = schema.Items.Reference != null;
        }
        else if (schema.AdditionalProperties != null)
        {
            if (schema.Properties.Count > 0)
                throw new CaffoaParserException(
                    "object with properties and additional properties are currently not supported.");
            if (schema.AdditionalProperties.Reference != null)
            {
                property.TypeName = ClassNameFunc(schema.AdditionalProperties.Reference.Name());
                property.InnerTypeIsOtherSchema = true;
            }
            else if (schema.AdditionalProperties.IsArray())
            {
                var arrayType = schema.AdditionalProperties.GetArrayType(ClassNameFunc, _knownTypes);
                property.TypeName = $"List<{arrayType}>";
                property.InnerTypeIsOtherSchema = false;
            }
            else
            {
                property.TypeName = schema.AdditionalProperties.TypeName();
                property.InnerTypeIsOtherSchema = false;
            }

            property.IsMap = true;
        }
        else if (schema.Properties == null)
        {
            throw new CaffoaParserException(
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

    private static string? ParseCustomConverter(IDictionary<string, IOpenApiExtension> schemaExtensions, string name)
    {
        if (schemaExtensions.TryGetValue("x-caffoa-converter", out var converter))
        {
            if (converter is OpenApiString converterStr)
                return converterStr.Value;
            Console.Error.WriteLine($"Could not parse custom converter of {name}: value is not a string");
        }

        return null;
    }

    private static List<string> ParseCustomAttributes(IDictionary<string, IOpenApiExtension> extensions, string name)
    {
        try
        {
            if (!extensions.TryGetValue("x-caffoa-attributes", out var annotations))
                return new List<string>();
            var annotationsArray = annotations as OpenApiArray;
            if (annotationsArray is null)
                throw new CaffoaParserException("Not an array");
            return annotationsArray.Select(item =>
            {
                var strItem = item as OpenApiString ?? throw new CaffoaParserException("one item is not a string");
                return strItem.Value;
            }).ToList();
        }
        catch (CaffoaParserException e)
        {
            Console.Error.WriteLine($"Could not parse custom attributes of {name}: {e.Message}");
            return new List<string>();
        }
    }

    private InterfaceModel ExtractInterface(IList<OpenApiSchema> schemaOneOf, OpenApiDiscriminator openApiDiscriminator)
    {
        if (openApiDiscriminator.PropertyName is null)
            throw new CaffoaParserException("cannot create oneOf interface without discriminator property");
        var model = new InterfaceModel
        {
            Discriminator = openApiDiscriminator.PropertyName
        };
        model.Children.AddRange(schemaOneOf.Select(schema =>
            schema.Reference is null
                ? throw new CaffoaParserException("did not find $ref as child of oneOf")
                : ClassNameFunc(schema.Reference.Name())));

        return model;
    }

    protected abstract OpenApiSchema UpdateSchemaForAllOff(OpenApiSchema schema);
}