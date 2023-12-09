using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Caffoa.Defaults;

/// <summary>
/// Default Parser to parse json payload to objects.
/// uses the most simple JsonConvert and ToObject methods of Json and uses an <see cref="ICaffoaErrorHandler"/> to be able to create parse errors
/// </summary>
public class DefaultCaffoaJsonParser : ICaffoaJsonParser
{
    private readonly JsonSerializerSettings _settings;
    public ICaffoaParseErrorHandler ErrorHandler { get; }

    public DefaultCaffoaJsonParser(ICaffoaParseErrorHandler errorHandler) : this(errorHandler, null)
    {
    }
    
    public DefaultCaffoaJsonParser(ICaffoaParseErrorHandler errorHandler, JsonSerializerSettings settings)
    {
        _settings = settings ?? new JsonSerializerSettings();
        ErrorHandler = errorHandler;
    }

    public async ValueTask<T> Parse<T>(Stream httpStream)
    {
        try
        {
            Stream s;
            if (httpStream.CanSeek)
                s = httpStream;
            else
            {
                s = new MemoryStream();
                await httpStream.CopyToAsync(s);
            }

            if (s.CanSeek)
                s.Seek(0, SeekOrigin.Begin);

            using var streamReader = new StreamReader(s);
            if (streamReader.EndOfStream)
                throw ErrorHandler.NoContent();
            using var jsonReader = new JsonTextReader(streamReader);
            var serializer = JsonSerializer.Create(_settings);
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

    public T Parse<T>(string data) => JsonConvert.DeserializeObject<T>(data, _settings);

    public virtual T ToObject<T>(object token)
    {
        if (token is not JToken jToken)
            throw new ArgumentException($"ToObject expected a jToken, got {token.GetType()} instead.");
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