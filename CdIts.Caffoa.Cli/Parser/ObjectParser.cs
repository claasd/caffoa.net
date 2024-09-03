using CdIts.Caffoa.Cli.Config;
using CdIts.Caffoa.Cli.Errors;
using CdIts.Caffoa.Cli.Model;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Interfaces;
using Microsoft.OpenApi.Models;
using YamlDotNet.Core.Tokens;

namespace CdIts.Caffoa.Cli.Parser;

public abstract class ObjectParser
{
    protected readonly Func<string, string> ClassNameFunc;
    private readonly bool _nullableIsDefault;
    protected readonly SchemaItem Item;
    private readonly CaffoaConfig.EnumCreationMode _enumMode;
    private ILogger? _logger;

    protected ObjectParser(SchemaItem item, CaffoaConfig.EnumCreationMode enumMode,
        Func<string, string> classNameGenerator, bool nullableIsDefault)
    {
        Item = item;
        _enumMode = enumMode;
        ClassNameFunc = classNameGenerator;
        _nullableIsDefault = nullableIsDefault;
    }

    public SchemaItem Parse(OpenApiSchema schema, ILogger logger)
    {
        _logger = logger;
        try
        {
            schema = ResolveExternal(schema);
            Item.GenerateEqualsOverload = schema.Extensions.ParseCaffoaOption("x-caffoa-generate-equals");
            Item.GenerateComparerOverload = schema.Extensions.ParseCaffoaOption("x-caffoa-generate-comparer");
            var nullableIsDefault = schema.Extensions.ParseCaffoaOption("x-caffoa-default-nullable") ?? _nullableIsDefault;
            if (schema.AllOf.Count > 0)
                schema = UpdateSchemaForAllOff(schema, schema.AllOf);
            if (schema.AnyOf.Count > 0)
                schema = UpdateSchemaForAllOff(schema, schema.AnyOf);
            if (schema.OneOf.Count > 0)
                Item.Interface = ExtractInterface(schema.OneOf, schema.Discriminator);
            else if (schema.Properties.Count > 0)
            {
                var objectDelegates = schema.Extensions.ParseCaffoaList("x-caffoa-delegates", Item.Name);
                var aliases = schema.Extensions.ParseCaffoaMap("x-caffoa-aliases", Item.Name);
                Item.Properties = schema.Properties
                    .Select(item =>
                        ParseProperty(item.Key, item.Value, schema.Required.Contains(item.Key), nullableIsDefault, objectDelegates.Contains(item.Key),
                            aliases.GetValueOrDefault(item.Key))).ToList();
                Item.AdditionalPropertiesAllowed = schema.AdditionalPropertiesAllowed;
            }
            else if (schema.IsPrimitiveType() && schema.CanBeEnum())
            {
                if (schema.Type.StartsWith("string"))
                {
                    Item.Type = SchemaItem.ObjectType.StringEnum;
                    Item.NullableEnum = schema.Nullable;
                }

                Item.EnumsAliases = ParseCustomEnumAliases(schema.Extensions, Item.Name);
                Item.Enums = schema.EnumsAsStrings().Concat(Item.EnumsAliases.Keys).Distinct().ToList();
                Item.Default = schema.DefaultAsString();
            }

            Item.Description = schema.Description;
            return Item;
        }
        catch (CaffoaParserException e)
        {
            throw new CaffoaParserException($"Error during parsing of object {Item.Name}: {e.Message}", e);
        }
    }

    private PropertyData ParseProperty(string name, OpenApiSchema schema, bool required, bool nullableIsDefault, bool doDelegate,
        string? alias)
    {
        schema = ResolveExternal(schema);
        if (schema.AnyOf.Any())
            throw new CaffoaParserException("anyOf is not supported on object properties");
        var property = new PropertyData(name, required, schema.ReadOnly);
        property.Deprecated = schema.Deprecated;
        property.CustomAttributes = ParseCustomAttributes(schema.Extensions, name);
        property.Generate = schema.Extensions.ParseCaffoaOption("x-caffoa-generate") ?? true;
        property.Delegate = schema.Extensions.ParseCaffoaOption("x-caffoa-delegate") ?? doDelegate;
        property.Alias = ParseAliasAttribute(schema.Extensions, name, alias);
        property.AliasGet = schema.Extensions.ParseCaffoaValue("x-caffoa-alias-get", name);
        property.AliasSet = schema.Extensions.ParseCaffoaValue("x-caffoa-alias-set", name);
        property.Converter = ParseCustomConverter(schema.Extensions, name);

        if (!schema.IsRealObject(_enumMode))
        {
            schema.Reference = null;
        }

        property.Description = schema.Description;
        property.Nullable = schema.Nullable || (nullableIsDefault && !required);
        if (schema.Reference != null)
        {
            property.TypeName = ClassNameFunc(schema.Reference.Name());
            property.Nullable = !required;
            property.IsOtherSchema = !schema.IsPrimitiveType();
        }
        else if (schema.IsArray())
        {
            Console.WriteLine(name);
            property.IsArray = true;
            property.TypeName = schema.GetArrayType(ClassNameFunc, _enumMode);
            property.InnerTypeIsOtherSchema = schema.Items.Reference != null && !schema.Items.IsRealObject(_enumMode);

            if (schema.Items.IsPrimitiveType() && schema.Default is OpenApiArray defaultArray)
            {
                property.ArrayDefaults = defaultArray.Select(item => item.AnyValue()).Where(v => v != null).ToArray()!;
            }
        }
        else if (schema.AdditionalProperties != null)
        {
            ParseAdditionalProperties(schema, property);
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
            property.EnumsAliases = ParseCustomEnumAliases(schema.Extensions, name);
            property.Enums = schema.EnumsAsStrings().Concat(Item.EnumsAliases.Keys).Distinct().ToList();
        }

        return property;
    }

    private void ParseAdditionalProperties(OpenApiSchema schema, PropertyData property)
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
            var arrayType = schema.AdditionalProperties.GetArrayType(ClassNameFunc, _enumMode);
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

    private string? ParseCustomConverter(IDictionary<string, IOpenApiExtension> schemaExtensions, string name) =>
        schemaExtensions.ParseCaffoaValue("x-caffoa-converter", name);

    private string? ParseAliasAttribute(IDictionary<string, IOpenApiExtension> extensions, string name, string? externAliasDef) =>
        (extensions.ParseCaffoaValue("x-caffoa-alias", name) ?? externAliasDef)?.ToObjectName();

    private IList<string> ParseCustomAttributes(IDictionary<string, IOpenApiExtension> extensions, string name)
    {
        var attribute = extensions.ParseCaffoaValue("x-caffoa-attribute", name);
        if (attribute != null)
            return new List<string>() { attribute };
        return extensions.ParseCaffoaList("x-caffoa-attributes", name);
    }

    private Dictionary<string, string> ParseCustomEnumAliases(IDictionary<string, IOpenApiExtension> extensions, string name)
    {
        return extensions.ParseCaffoaMap("x-caffoa-enum-aliases", name).ToDictionary(item => item.Key.Escaped(), item => item.Value.Escaped());
    }

    private InterfaceModel ExtractInterface(IList<OpenApiSchema> schemaOneOf, OpenApiDiscriminator openApiDiscriminator)
    {
        if (openApiDiscriminator?.PropertyName is null)
            _logger?.LogWarning("discriminator is null, createing the correct subtype might not be possible for server implementations");
        var mapping = openApiDiscriminator?.Mapping.ToDictionary(m => m.Value, m => m.Key);
        var model = new InterfaceModel
        {
            Discriminator = openApiDiscriminator?.PropertyName,
        };
        foreach (var schema in schemaOneOf)
        {
            if (!schema.IsPrimitiveType() && schema.Reference is null)
                throw new CaffoaParserException("oneOf interface can only contain references or primitive types");
            
            if (mapping is null || schema.Reference is null || !mapping.TryGetValue(schema.Reference.ReferenceV3, out var mapName))
                mapName = schema.Reference?.Name() ?? schema.TypeName();
            var typeName = schema.Reference != null ? ClassNameFunc(schema.Reference.Name()) : schema.TypeName();
            model.Mapping[mapName] = typeName;
            model.Children.Add(typeName);
        }

        return model;
    }

    public static OpenApiSchema ResolveExternal(OpenApiSchema subSchema)
    {
        if (subSchema.Reference?.IsExternal ?? false)
        {
            var result = subSchema.Reference.HostDocument.Workspace.ResolveReference(subSchema.Reference);
            if (result is OpenApiSchema schema)
                return schema;
        }

        return subSchema;
    }

    protected abstract OpenApiSchema UpdateSchemaForAllOff(OpenApiSchema schema, IList<OpenApiSchema> list);
}