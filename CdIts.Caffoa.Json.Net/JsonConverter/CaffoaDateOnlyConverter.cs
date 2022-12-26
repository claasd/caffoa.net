#if NET6_0_OR_GREATER
using System.Globalization;
using Newtonsoft.Json;

namespace Caffoa.JsonConverter;

public class CaffoaDateOnlyConverter : JsonConverter<DateOnly?>
{
    public const string DateFormat = "yyyy-MM-dd";

    public override DateOnly? ReadJson(JsonReader reader, Type objectType, DateOnly? existingValue,
        bool hasExistingValue, JsonSerializer serializer)
    {
        try
        {
            var value = reader.Value;
            if (reader.TokenType is not JsonToken.Null && value is not null)
                return DateOnly.ParseExact(value.ToString() ?? "", DateFormat, CultureInfo.InvariantCulture);
            if (Nullable.GetUnderlyingType(objectType) is not null) // this is a nullable type
                return null;
            throw new ArgumentException("Cannot convert null value to DateOnly.");
        }
        catch (Exception e)
        {
            var lineInfo = reader as IJsonLineInfo;
            throw new JsonSerializationException(e.Message, reader.Path,
                lineInfo?.LineNumber ?? 0, lineInfo?.LinePosition ?? 0, null);
        }
    }

    public override void WriteJson(JsonWriter writer, DateOnly? value, JsonSerializer serializer)
    {
        if (value is null)
            writer.WriteNull();
        else
            writer.WriteValue(value.Value.ToString(DateFormat, CultureInfo.InvariantCulture));
    }
}
#endif