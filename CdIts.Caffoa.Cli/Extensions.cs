using System.Text;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace CdIts.Caffoa.Cli;

public static class Extensions
{
    public static string ToCamelCase(this string str)
    {
        var parts = str.Replace('-', '_').Split('_');
        return string.Join("", parts.Select(part => part.FirstCharUpper()));
    }

    public static string FirstCharUpper(this string str)
    {
        if (str.Length > 1)
            return str[..1].ToUpper() + str[1..];
        return str;
    }

    public static bool IsPrimitiveType(this OpenApiSchema schema)
    {
        return schema.Type is "string" or "integer" or "number" or "boolean";
    }
    
    public static string TypeName(this OpenApiSchema schema)
    {
        var type = schema.Type;
        var format = schema.Format?.ToLower();
        var suffix = schema.Nullable ? "?" : "";
        return type switch
        {
            "string" when format == "uuid" => $"Guid{suffix}",
            "string" when format is "date-time" or "date" => $"DateTime{suffix}",
            "integer" when format == "int64" => $"long{suffix}",
            "integer" when format == "uint64" => $"ulong{suffix}",
            "integer" when format == "uint32" => $"uint{suffix}",
            "integer" => $"int{suffix}",
            "number" => $"double{suffix}",
            "boolean" => $"bool{suffix}",
            "string" => "string",
            _ => $"{type}{suffix}"
        };
    }

    public static string? DefaultAsString(this OpenApiSchema schema)
    {
        switch (schema.Default)
        {
            case OpenApiString str:
                return $"\"{str.Value}\"";
            case OpenApiBoolean boolean:
                return boolean.Value ? "true" : "false";
            case OpenApiDouble dbl:
                return dbl.ToString();
            case OpenApiFloat flt:
                return flt.ToString();
            case OpenApiInteger integer:
                return integer.ToString();
            case OpenApiLong vLong:
                return vLong.ToString();
            default:
                return null;
        }
    }

    public static string FormatDict(this string str, IDictionary<string, object> values)
    {
        var i = 0;
        var newFormatString = new StringBuilder(str);
        var keyToInt = new Dictionary<string,int>();
        foreach (var (key, value) in values)
        {
            newFormatString = newFormatString.Replace("{" + key + "}", "{" + i + "}");
            keyToInt.Add(key, i);
            i++;                    
        }
        return string.Format(newFormatString.ToString(), values.OrderBy(x => keyToInt[x.Key]).Select(x => x.Value).ToArray());
    }
}