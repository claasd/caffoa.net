using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Caffoa;

public record CaffoaResultHandlerParameter(
    int[] ReturnedStatusCodes,
    string[] DefinedMimeTypes,
    HttpRequest Request,
    HttpMethod Method,
    string Path,
    Dictionary<string, object> PathParameters,
    object RequestObject = null)
{
    public string[] AcceptedMimeTypes => Request?.Headers?.Accept ?? Array.Empty<string>();
}

/// <summary>
/// interface for serializing outgoing data
/// </summary>
public interface ICaffoaResultHandler : ICaffoaJsonSerializer
{
    /// <summary>
    /// should return a valid result for the requested mime type.
    /// implement these if you support different mime types
    /// </summary>
    IActionResult Result(object data, int statusCode, CaffoaResultHandlerParameter parameter);
    IActionResult Result<T>(IEnumerable<T> data, int statusCode, CaffoaResultHandlerParameter parameter);
    /// <summary>
    /// Should return a valid result without payload and the passed statusCode as statusCode
    /// </summary>
    IActionResult StatusCode(int statusCode);
    
    /// <summary>
    /// can be used to enhance raw results with headers or other data.
    /// Is only called if neither <see cref="Json"/> nor <see cref="StatusCode"/> is called.
    /// </summary>
    IActionResult Handle(IActionResult input);
}
