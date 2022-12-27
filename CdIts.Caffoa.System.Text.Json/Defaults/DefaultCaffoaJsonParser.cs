using System.Text.Json;
using System.Text.Json.Serialization;

namespace Caffoa.Defaults;

/// <summary>
/// Default Parser to parse json payload to objects.
/// uses the most simple JsonConvert and ToObject methods of Json and uses an <see cref="ICaffoaErrorHandler"/> to be able to create parse errors
/// </summary>
public class DefaultCaffoaJsonParser : ICaffoaJsonParser
{
    public ICaffoaErrorHandler ErrorHandler { get; }

    public JsonSerializerOptions Options { get; set; } = new JsonSerializerOptions
    {
        Converters =
        {
            new JsonStringEnumConverter()
        }
    };

    public DefaultCaffoaJsonParser(ICaffoaErrorHandler errorHandler)
    {
        ErrorHandler = errorHandler;
    }

    public async ValueTask<T> Parse<T>(Stream httpStream)
    {
        try
        {
            return await JsonSerializer.DeserializeAsync<T>(httpStream, Options);
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

    public virtual T ToObject<T>(object token)
    {
        if (token is not JsonElement element)
            throw new ArgumentException($"ToObject expected a JsonElement, got {token.GetType()} instead.");
        try
        {
            return element.Deserialize<T>(Options);
        }
        catch (Exception e)
        {
            throw ErrorHandler.JsonParseError(e);
        }
    }
}