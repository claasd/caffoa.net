using Newtonsoft.Json.Linq;

namespace Caffoa;

/// <summary>
/// interface for parsing incoming JSON data to objects
/// </summary>
public interface ICaffoaJsonParser
{
    /// <summary>
    /// Should parse the incoming stream to JSON of type T and handle errors
    /// Should throw an CaffoaClientError for parsing errors.
    /// (See <see cref="ICaffoaErrorHandler"/> for error handling via CI)
    /// </summary>
    public ValueTask<T> Parse<T>(Stream httpStream);
    /// <summary>
    /// Should parse the passed jObject to T with errorHandling.
    /// Should throw an CaffoaClientError for parsing errors.
    /// (See <see cref="ICaffoaErrorHandler"/> for error handling via CI)
    /// </summary>
    public T ToObject<T>(JToken jToken);
}