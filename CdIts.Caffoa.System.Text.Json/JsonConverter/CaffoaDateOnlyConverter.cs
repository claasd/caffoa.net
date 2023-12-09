using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Caffoa.JsonConverter;

public class CaffoaDateOnlyConverter : JsonConverter<object>
{
    public const string DateFormat = "yyyy-MM-dd";

    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert == typeof(DateOnly) || Nullable.GetUnderlyingType(typeToConvert) == typeof(DateOnly);
    }
    public override object Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        try
        {
            var value = reader.GetString();
            if (reader.TokenType is not JsonTokenType.Null && value is not null)
                return DateOnly.ParseExact(value, DateFormat, CultureInfo.InvariantCulture);
            if (Nullable.GetUnderlyingType(typeToConvert) is not null) // this is a nullable type
                return null;
            throw new ArgumentException("Cannot convert null value to DateOnly.");
        }
        catch (Exception e)
        {
            throw new JsonException(e.Message);
        }
    }

    public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
    {
        if (value is null)
            writer.WriteNullValue();
        else
            writer.WriteStringValue(((DateOnly)value).ToString(DateFormat, CultureInfo.InvariantCulture));
    }
}