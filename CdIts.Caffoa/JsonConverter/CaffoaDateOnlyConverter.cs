#if NET6_0
using System.Globalization;
using Newtonsoft.Json;

namespace Caffoa.JsonConverter;

public class CaffoaDateOnlyConverter : JsonConverter<DateOnly>
{
    private const string DateFormat = "yyyy-MM-dd";

    public override DateOnly ReadJson(JsonReader reader, Type objectType, DateOnly existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        return DateOnly.ParseExact((string)reader.Value, DateFormat, CultureInfo.InvariantCulture);
    }

    public override void WriteJson(JsonWriter writer, DateOnly value, JsonSerializer serializer)
    {
        writer.WriteValue(value.ToString(DateFormat, CultureInfo.InvariantCulture));
    }
}
#endif