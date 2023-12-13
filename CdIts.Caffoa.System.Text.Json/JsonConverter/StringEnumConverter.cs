using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Caffoa.JsonConverter;

public class StringEnumConverter: JsonConverter<object>
{
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert.IsEnum || (Nullable.GetUnderlyingType(typeToConvert)?.IsEnum ?? false);
    }

    public override object Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        try
        {
            return EnumConverter.FromString(typeToConvert, reader.GetString());
        }
        catch (Exception e)
        {
            throw new JsonException(e.Message, e);
        }
    }

    public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(EnumConverter.EnumValue(value as Enum));
    }
}