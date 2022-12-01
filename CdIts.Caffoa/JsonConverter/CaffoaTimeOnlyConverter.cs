#if NET6_0
using System.Globalization;
using Newtonsoft.Json;

namespace Caffoa.JsonConverter;

public class CaffoaTimeOnlyConverter : JsonConverter<TimeOnly?>
{
    private const string TimeFormat = "HH:mm:ss";

    public override TimeOnly? ReadJson(JsonReader reader, Type objectType, TimeOnly? existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        var value = reader.Value;
        if (reader.TokenType is JsonToken.Null || value is null)
            return null;

        return TimeOnly.Parse(value.ToString() ?? "", CultureInfo.InvariantCulture);
    }

    public override void WriteJson(JsonWriter writer, TimeOnly? value, JsonSerializer serializer)
    {
        writer.WriteValue(value?.ToString(TimeFormat, CultureInfo.InvariantCulture));
    }
}
#endif