using System.Globalization;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Utilities;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace Caffoa.JsonConverter;

public class CaffoaNumericEnumConverter<T> : JsonConverter<T> where T : Enum
{
    public override void WriteJson(JsonWriter writer, T value, JsonSerializer serializer)
    {
        writer.WriteValue(value);
    }

    public override T ReadJson(JsonReader reader, Type objectType, T existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        var baseType = Enum.GetUnderlyingType(typeof(T));
        var converted = Convert.ChangeType(reader.Value, baseType);
        if(converted is null)
            throw new ArgumentException($"could not use value {reader.Value:D} for enum type {typeof(T)}, could not convert to {baseType.FullName}");
        if (Enum.IsDefined(typeof(T), converted))
            return (T)converted;
        throw new ArgumentException($"could not use value {reader.Value:D} for enum type {typeof(T).Name}'");
    }
}