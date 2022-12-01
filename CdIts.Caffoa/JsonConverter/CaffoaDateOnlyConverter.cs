using System.Globalization;
using Newtonsoft.Json;

namespace Caffoa.JsonConverter;

public class CaffoaDateOnlyConverter : JsonConverter<DateOnly?>
{
    private const string DateFormat = "yyyy-MM-dd";

    public override DateOnly? ReadJson(JsonReader reader, Type objectType, DateOnly? existingValue,
        bool hasExistingValue, JsonSerializer serializer)
    {
        var value = reader.Value;
        if (reader.TokenType is JsonToken.Null || value is null)
            return null;
        
        return DateOnly.ParseExact(value.ToString() ?? "", DateFormat, CultureInfo.InvariantCulture);
    }

    public override void WriteJson(JsonWriter writer, DateOnly? value, JsonSerializer serializer)
    {
        if (value is null)
            writer.WriteNull();
        else
            writer.WriteValue(value.Value.ToString(DateFormat, CultureInfo.InvariantCulture));
    }
}