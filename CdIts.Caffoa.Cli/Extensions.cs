using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using CdIts.Caffoa.Cli.Config;
using CdIts.Caffoa.Cli.Errors;
using CdIts.Caffoa.Cli.Model;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Interfaces;
using Microsoft.OpenApi.Models;

namespace CdIts.Caffoa.Cli;

public static class Extensions
{
    private const string StringType = "string";
    private const string NumberType = "number";
    private const string IntegerType = "integer";
    public static string ToObjectName(this string str)
    {
        var name = str.Replace("-", "_");
        name = name.Replace(".", "_");
        name = Regex.Replace(name, @"[^\w]", "");
        var parts = name.Split('_');
        return string.Join("", parts.Select(part => part.FirstCharUpper()));
    }

    public static string ToSystemNewLine(this string str)
    {
        return str.Replace("\r\n", "\n").Replace("\n", Environment.NewLine);
    }

    public static string FirstCharUpper(this string str)
    {
        if (str.Length > 1)
            return str[..1].ToUpper() + str[1..];
        return str;
    }

    public static string Quote(this string str) => $"\"{str}\"";
    public static IEnumerable<string> Quote(this IEnumerable<string> str) => str.Select(s => s.Quote());

    public static bool IsPrimitiveType(this OpenApiSchema schema)
    {
        return schema.Type is StringType or IntegerType or NumberType or "boolean";
    }

    public static bool HasOnlyAdditionalProperties(this OpenApiSchema schema)
    {
        return schema.Type == "object" && schema.AdditionalProperties != null && schema.Properties.Count == 0;
    }

    public static bool IsArray(this OpenApiSchema schema)
    {
        return schema.Type is "array";
    }

    public static bool IsRealObject(this OpenApiSchema apiSchema, CaffoaConfig.EnumCreationMode mode)
    {
        if (!apiSchema.IsPrimitiveType() && !apiSchema.HasOnlyAdditionalProperties())// && !apiSchema.IsArray())
            return true;
        if (apiSchema.CanBeEnum() && mode == CaffoaConfig.EnumCreationMode.Default)
            return true;
        return false;
    }

    public static string GetArrayType(this OpenApiSchema schema, Func<string, string> classNameFunc,
        CaffoaConfig.EnumCreationMode enumMode)
    {
        var item = schema.Items;
        if (item is null)
            return "object";
        if (!item.IsRealObject(enumMode))
            item.Reference = null;
        if (item.Reference != null)
            return classNameFunc(item.Reference.Name());
        if (item.IsPrimitiveType())
            return item.TypeName();
        var innerName = item.GetArrayType(classNameFunc, enumMode);
        return $"List<{innerName}>";
    }

    public static string TypeName(this OpenApiSchema schema)
    {
        var type = schema.Type;
        var format = schema.Format?.ToLower();
        var suffix = schema.Nullable ? "?" : "";
        return type switch
        {
            StringType when format == "uuid" => $"Guid{suffix}",
            StringType when format is "date-time" => $"DateTimeOffset{suffix}",
            StringType when format is "date" => $"DateOnly{suffix}",
            StringType when format is "time" => $"TimeOnly{suffix}",
            StringType when format is "byte" => $"byte[]",
            StringType when format is "duration" => $"TimeSpan{suffix}",
            IntegerType when format == "int64" => $"long{suffix}",
            IntegerType when format == "uint64" => $"ulong{suffix}",
            IntegerType when format == "uint32" => $"uint{suffix}",
            IntegerType => $"int{suffix}",
            NumberType when format == "float" => $"float{suffix}",
            NumberType when format == "decimal" => $"decimal{suffix}",
            NumberType => $"double{suffix}",
            "boolean" => $"bool{suffix}",
            StringType => StringType,
            null => $"object",
            _ => $"{type}{suffix}"
        };
    }

    public static string? DefaultAsString(this OpenApiSchema schema)
    {
        return AnyValue(schema.Default);
    }

    public static string? AnyValue(this IOpenApiAny any)
    {
        switch (any)
        {
            case OpenApiString str:
                return $"\"{str.Value}\"";
            case OpenApiBoolean boolean:
                return boolean.Value ? "true" : "false";
            case OpenApiDouble dbl:
                return dbl.Value.ToString(CultureInfo.InvariantCulture);
            case OpenApiFloat flt:
                return flt.Value.ToString(CultureInfo.InvariantCulture);
            case OpenApiInteger integer:
                return integer.Value.ToString();
            case OpenApiLong vLong:
                return vLong.Value.ToString();
            default:
                return null;
        }
    }

    public static List<string?> EnumsAsStrings(this OpenApiSchema schema)
    {
        return schema.Enum.Select(AnyValue).ToList();
    }

    public static string FormatDict(this string str, IDictionary<string, object> values)
    {
        var i = 0;
        var newFormatString = new StringBuilder(str);
        var keyToInt = new Dictionary<string, int>();
        foreach (var key in values.Keys)
        {
            newFormatString = newFormatString.Replace("{" + key + "}", "{" + i + "}");
            keyToInt.Add(key, i);
            i++;
        }

        return string.Format(newFormatString.ToString(),
            values.OrderBy(x => keyToInt[x.Key]).Select(x => x.Value).ToArray());
    }

    public static string Name(this OpenApiReference reference)
    {
        return reference.Id.Split("/")[0];
    }

    public static bool CanBeConstant(this PropertyData property)
    {
        return property.Enums.Count == 1 && property.TypeName is StringType or "int" or "long" or "ulong" or "uint" && property.Default != null;
    }

    public static bool CanBeEnum(this PropertyData property)
    {
        return property.Enums.Count > 0 && property.TypeName.StartsWith(StringType);
    }

    public static bool CanBeEnum(this OpenApiSchema schema)
    {
        return schema.Enum.Count > 0 && schema.Type.StartsWith(StringType);
    }

    public static string Escaped(this string str) => $"\"{str}\"";

    public static bool? ParseCaffoaOption(this IDictionary<string, IOpenApiExtension> extensions, string flag)
    {
        if (!extensions.TryGetValue(flag, out var singleAnnotation)) return null;
        var item = singleAnnotation as OpenApiBoolean ?? new OpenApiBoolean(false);
        return item.Value;
    }

    public static string? ParseCaffoaValue(this IDictionary<string, IOpenApiExtension> extensions, string flag, string fieldName)
    {
        if (!extensions.TryGetValue(flag, out var data)) return null;
        if (data is OpenApiString converterStr)
            return converterStr.Value;
        throw new CaffoaParserException($"could not parse {flag}: not a string type on field {fieldName}");
    }

    public static string[] ParseCaffoaList(this IDictionary<string, IOpenApiExtension> extensions, string flag, string fieldName)
    {
        if (!extensions.TryGetValue(flag, out var annotations))
            return Array.Empty<string>();
        var annotationsArray = annotations as OpenApiArray;
        if (annotationsArray is null)
            throw new CaffoaParserException($"{flag} annotation on {fieldName} must be an array");
        return annotationsArray.Select(item =>
        {
            var strItem = item as OpenApiString ?? throw new CaffoaParserException($"one item of {flag} on {fieldName} is not a string");
            return strItem.Value;
        }).ToArray();
    }

    public static Dictionary<string, string> ParseCaffoaMap(this IDictionary<string, IOpenApiExtension> extensions, string flag, string fieldName)
    {
        if (!extensions.TryGetValue(flag, out var data))
            return new();
        var aliasObject = data as OpenApiObject;
        if (aliasObject is null)
            throw new CaffoaParserException($"{flag} on {fieldName} must be a list of key->value objects");
        var result = new Dictionary<string, string>();
        foreach (var (key, value) in aliasObject)
        {
            if (value is not OpenApiString str)
                throw new CaffoaParserException($"value of {key} in list {flag} on {fieldName} is not a string value");
            result[key] = str.Value;
        }
        return result;
    }
}