using System.Linq.Expressions;
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

    public T Parse<T>(Stream s)
    {
        try
        {
            if (s.CanSeek)
                s.Seek(0, SeekOrigin.Begin);

            using var streamReader = new StreamReader(s);
            if (streamReader.EndOfStream)
                throw ErrorHandler.NoContent();
            using var jsonReader = new JsonTextReader(streamReader);
            var serializer = new JsonSerializer();
            return serializer.Deserialize<T>(jsonReader);
        }
        catch (CaffoaClientError)
        {
            throw;
        }
        catch (Exception e)
        {
            throw ErrorHandler.JsonParseError(e);
        }
    }

    public virtual T ToObject<T>(JToken jToken)
    {
        try
        {
            return jToken.ToObject<T>();
        }
        catch (Exception e)
        {
            throw ErrorHandler.JsonParseError(e);
        }
    }
}