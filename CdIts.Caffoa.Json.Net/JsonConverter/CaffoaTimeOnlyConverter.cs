#if NET6_0_OR_GREATER
using System.Globalization;
using Newtonsoft.Json;

namespace Caffoa.JsonConverter;

public class CaffoaTimeOnlyConverter : JsonConverter<TimeOnly?>
{
    public const string TimeFormat = "HH:mm:ss";
    public const string ParseFormat = "H:m:s";
    public const string FallbackParseFormat = "H:m";

    public override TimeOnly? ReadJson(JsonReader reader, Type objectType, TimeOnly? existingValue,
        bool hasExistingValue, JsonSerializer serializer)
    {
        try
        {
            var value = reader.Value?.ToString();
            if (reader.TokenType is not JsonToken.Null && value is not null)
            {
                if (TimeOnly.TryParseExact(value, ParseFormat, out var time))
                    return time;
                if (TimeOnly.TryParseExact(value, FallbackParseFormat, out time))
                    return time;
                throw new ArgumentException($"Cannot convert '{value}' value to TimeOnly.");
            }

            if (Nullable.GetUnderlyingType(objectType) is not null) // this is a nullable type
                return null;
            throw new ArgumentException("Cannot convert null value to TimeOnly.");
        }
        catch (Exception e)
        {
            var lineInfo = reader as IJsonLineInfo;
            throw new JsonSerializationException(e.Message, reader.Path,
                lineInfo?.LineNumber ?? 0, lineInfo?.LinePosition ?? 0, null);
        }
    }

    public override void WriteJson(JsonWriter writer, TimeOnly? value, JsonSerializer serializer)
    {
        if (value is null)
            writer.WriteNull();
        else
            writer.WriteValue(value.Value.ToString(TimeFormat, CultureInfo.InvariantCulture));
    }
}
#endif