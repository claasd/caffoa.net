#if NET6_0
using System.Globalization;
using Newtonsoft.Json;

namespace Caffoa.JsonConverter;

public class CaffoaTimeOnlyConverter : JsonConverter<TimeOnly?>
{
    private const string TimeFormat = "HH:mm:ss";

    public override TimeOnly? ReadJson(JsonReader reader, Type objectType, TimeOnly? existingValue,
        bool hasExistingValue, JsonSerializer serializer)
    {
        try
        {
            var value = reader.Value;
            if (reader.TokenType is not JsonToken.Null && value is not null)
                return TimeOnly.Parse(value.ToString() ?? "", CultureInfo.InvariantCulture);
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