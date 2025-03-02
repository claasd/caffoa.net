using System.Text.Json;
using System.Text.Json.Serialization;

namespace Caffoa.JsonConverter;

public class CaffoaEnumWrapperConverter<T> : JsonConverter<object> where T: class, ICaffoaEnumWrapper,  new() 
{
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert == typeof(T) || Nullable.GetUnderlyingType(typeToConvert) == typeof(T);
    }

    public override object Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        try
        {
            var value = reader.GetString();
            if (reader.TokenType is not JsonTokenType.Null && value is not null)
            {
                return new T()
                {
                    StringValue = value
                };
            }
            if (Nullable.GetUnderlyingType(typeToConvert) is not null) // this is a nullable type
                return null;
            throw new ArgumentException($"Cannot convert null value to Enum of type {typeof(T)} via CaffoaEnumWrapperConverter.");
        }
        catch (Exception e)
        {
            throw new JsonException(e.Message);
        }
    }

    public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
    {
        if(value is null)
            writer.WriteNullValue();
        else
            writer.WriteStringValue(((T)value).StringValue);
    }
}