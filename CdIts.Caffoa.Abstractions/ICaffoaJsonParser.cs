using Newtonsoft.Json.Linq;

namespace Caffoa;

public interface ICaffoaJsonParser
{
    public Task<T> Parse<T>(Stream s);
    public T ToObject<T>(JObject jObject);
}