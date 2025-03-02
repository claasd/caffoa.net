using System.Globalization;
using Newtonsoft.Json;

namespace Caffoa.JsonConverter;
public class CaffoaEnumWrapperConverter<T> : JsonConverter<T> where T : class, ICaffoaEnumWrapper, new()
{
    public override void WriteJson(JsonWriter writer, T value, JsonSerializer serializer)
    {
        if (value is null)
            writer.WriteNull();
        else
            writer.WriteValue(value.StringValue);
    }


    public override T ReadJson(JsonReader reader, Type objectType, T existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        try
        {
            var value = reader.Value;
            if (reader.TokenType is not JsonToken.Null && value is not null)
                return new T()
                {
                    StringValue = value.ToString()
                };
            return null;
        }
        catch (Exception e)
        {
            var lineInfo = reader as IJsonLineInfo;
            throw new JsonSerializationException(e.Message, reader.Path,
                lineInfo?.LineNumber ?? 0, lineInfo?.LinePosition ?? 0, null);
        }
    }
}