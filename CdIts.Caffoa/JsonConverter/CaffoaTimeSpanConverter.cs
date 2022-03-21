using System.Globalization;
using Newtonsoft.Json;

namespace Caffoa.JsonConverter;

public class CaffoaTimeSpanConverter : JsonConverter<TimeSpan>
{
    private const string TimeFormat = @"hh\:mm\:ss";
    private const string FallbackTimeFormat = @"h\:m";

    public override void WriteJson(JsonWriter writer, TimeSpan value, JsonSerializer serializer)
    {
        writer.WriteValue(value.ToString(TimeFormat, CultureInfo.InvariantCulture));
    }

    public override TimeSpan ReadJson(JsonReader reader, Type objectType, TimeSpan existingValue, bool hasExistingValue,
        JsonSerializer serializer)
    {
        if (TimeSpan.TryParseExact((string) reader.Value, TimeFormat, CultureInfo.InvariantCulture, out var result))
            return result;
        if (TimeSpan.TryParseExact((string) reader.Value, FallbackTimeFormat, CultureInfo.InvariantCulture, out result))
            return result;
        throw new ArgumentException($"could create time from '{reader.Value}' for '{reader.Path}'");
    }
}