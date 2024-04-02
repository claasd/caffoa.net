namespace Caffoa.JsonConverter;
using Newtonsoft.Json;

public class CaffoaValueTypeConverter<T1,T2> : JsonConverter<T1> where T1 : ICaffoaValueType<T2>, new()
{
    public override void WriteJson(JsonWriter writer, T1 value, JsonSerializer serializer)
    {
        serializer.Serialize(writer, value.Value);
    }

    public override T1 ReadJson(JsonReader reader, Type objectType, T1 existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        var data = serializer.Deserialize<T2>(reader);
        return new T1()
        {
            Value = data
        };
    }
}