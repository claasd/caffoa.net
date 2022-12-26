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
    /// Should parse the passed object to T with errorHandling.
    /// For Json.NET, this is a jRokwn. For System.Text.Json, it is an JsonElement
    /// Should throw an CaffoaClientError for parsing errors.
    /// (See <see cref="ICaffoaErrorHandler"/> for error handling via CI)
    /// </summary>
    public T ToObject<T>(object token);
}