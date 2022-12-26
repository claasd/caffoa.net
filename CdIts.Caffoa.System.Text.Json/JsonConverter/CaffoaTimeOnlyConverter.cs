using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Caffoa.JsonConverter;

public class CaffoaTimeOnlyConverter : JsonConverter<TimeOnly?>
{
    public const string TimeFormat = "HH:mm:ss";
    public const string ParseFormat = "H:m:s";
    public const string FallbackParseFormat = "H:m";
    
    public override TimeOnly? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        try
        {
            var value = reader.GetString();
            if (reader.TokenType is not JsonTokenType.Null && value is not null)
            {
                if (TimeOnly.TryParseExact(value, ParseFormat, out var time))
                    return time;
                if (TimeOnly.TryParseExact(value, FallbackParseFormat, out time))
                    return time;
                throw new ArgumentException($"Cannot convert '{value}' value to TimeOnly.");
            }
            if (Nullable.GetUnderlyingType(typeToConvert) is not null) // this is a nullable type
                return null;
            throw new ArgumentException("Cannot convert null value to DateOnly.");
        }
        catch (Exception e)
        {
            throw new JsonException(e.Message);
        }
    }

    public override void Write(Utf8JsonWriter writer, TimeOnly? value, JsonSerializerOptions options)
    {
        if (value is null)
            writer.WriteNullValue();
        else
            writer.WriteStringValue(value.Value.ToString(TimeFormat, CultureInfo.InvariantCulture));
    }
}