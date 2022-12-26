using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Caffoa.JsonConverter;

public class CaffoaDateOnlyConverter : JsonConverter<DateOnly?>
{
    public const string DateFormat = "yyyy-MM-dd";


    public override DateOnly? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        try
        {
            var value = reader.GetString();
            if (reader.TokenType is not JsonTokenType.Null && value is not null)
                return DateOnly.ParseExact(value ?? "", DateFormat, CultureInfo.InvariantCulture);
            if (Nullable.GetUnderlyingType(typeToConvert) is not null) // this is a nullable type
                return null;
            throw new ArgumentException("Cannot convert null value to DateOnly.");
        }
        catch (Exception e)
        {
            throw new JsonException(e.Message);
        }
    }

    public override void Write(Utf8JsonWriter writer, DateOnly? value, JsonSerializerOptions options)
    {
        if (value is null)
            writer.WriteNullValue();
        else
            writer.WriteStringValue(value.Value.ToString(DateFormat, CultureInfo.InvariantCulture));
    }
}