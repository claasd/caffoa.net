using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Caffoa.Defaults;

/// <summary>
/// Default Parser to parse json payload to objects.
/// uses the most simple JsonConvert and ToObject methods of Json and uses an <see cref="ICaffoaErrorHandler"/> to be able to create parse errors
/// </summary>
public class DefaultCaffoaJsonParser : ICaffoaJsonParser
{
    public ICaffoaErrorHandler ErrorHandler { get; }
    public DefaultCaffoaJsonParser(ICaffoaErrorHandler errorHandler)
    {
        ErrorHandler = errorHandler;
    }

    public virtual async Task<T> Parse<T>(Stream s)
    {
        string requestBody;
        if(s.CanSeek)
            s.Seek(0, SeekOrigin.Begin);
        using (var streamReader =  new  StreamReader(s))
            requestBody = await streamReader.ReadToEndAsync();
        return Parse<T>(requestBody);
    }

    public virtual T Parse<T>(string requestBody)
    {
        if (string.IsNullOrWhiteSpace(requestBody))
            throw ErrorHandler.NoContent();
        try {
            return JsonConvert.DeserializeObject<T>(requestBody);
        } catch (Exception e)
        {
            throw ErrorHandler.JsonParseError(e);
        }
    }

    public virtual T ToObject<T>(JObject jObject)
    {
        try {
            return jObject.ToObject<T>();
        } catch (Exception e) {
            throw ErrorHandler.JsonParseError(e);
        }
    }
}