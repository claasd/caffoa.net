using CdIts.Caffoa.Cli.Model;
using Microsoft.OpenApi.Models;

namespace CdIts.Caffoa.Cli;

public class ObjectParser
{
    private readonly Func<string, string> _classNameFunc;
    private readonly SchemaItem _item;
    private readonly IDictionary<string, OpenApiSchema> _knownTypes;

    public ObjectParser(SchemaItem item, IDictionary<string, OpenApiSchema> knownTypes, Func<string, string> classNameGenerator)
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
            _item.Properties =
                schema.Properties.Select(item => ParseProperty(item.Key, item.Value, schema.Required.Contains(item.Key))).ToList();
        _item.Description = schema.Description;
        return _item;
    }

    private PropertyData ParseProperty(string name, OpenApiSchema schema, bool required)
    {
        var property = new PropertyData(name, required);
        if (schema.Reference != null && _knownTypes.TryGetValue(_classNameFunc(schema.Reference.Id), out var knownSchema))
            schema = knownSchema;

        property.Description = schema.Description;
        property.Nullable = schema.Nullable;
        if (schema.Reference != null)
        {
            property.TypeName = _classNameFunc(schema.Reference.Id);
            property.Nullable = !required;
            property.IsOtherSchema = true;
        }
        else if(schema.Type == "array")
        {
            var item = schema.Items;
            property.IsArray = true;
            if (item.Reference != null)
                property.TypeName = _classNameFunc(item.Reference.Id);
            else if (!item.IsPrimitiveType())
                throw new ApplicationException(
                    $"Cannot parse array trees: '{name}' child of '{_item.Name}' should have it's array item declared in own schema directly under 'components'");
            else
                property.TypeName = schema.TypeName();
        }
        else
        {
            property.TypeName = schema.TypeName();
            property.Default = schema.DefaultAsString();
        }
        return property;
    }

    private InterfaceModel ExtractInterface(IList<OpenApiSchema> schemaOneOf, OpenApiDiscriminator openApiDiscriminator)
    {
        var model = new InterfaceModel
        {
            Discriminator = openApiDiscriminator.PropertyName
        };
        foreach (var schema in schemaOneOf)
        {
            if (schema.Reference is null)
                throw new ApplicationException("did not find $ref as child of oneOf");
            model.Children.Add(_classNameFunc(schema.Reference.Id));
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
                    throw new ApplicationException(
                        "allOf is implemented as inheritance; cannot have to children with $ref");
                parent = _classNameFunc(schema.Reference.Id);
            }
            else
            {
                if (newSchema != null)
                    throw new ApplicationException(
                        "allOf is implemented as inheritance; cannot have to children of allOf with direct implementation");
                newSchema = schema;
            }
        }

        if (newSchema is null)
            throw new ApplicationException("Cannot create class without content, no child of allOf is type object");
        return (newSchema, parent);
    }
}