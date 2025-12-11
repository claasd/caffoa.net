using Microsoft.AspNetCore.Mvc;

namespace Caffoa;

/// <summary>
/// interface for serializing outgoing data
/// </summary>
public interface ICaffoaResultHandler : ICaffoaJsonSerializer
{
    /// <summary>
    /// should return a valid result for the requested mime type.
    /// implement these if you support different mime types
    /// </summary>
    IActionResult Result(object data, int statusCode, string[] acceptedMimeTypes);
    IActionResult Result<T>(IEnumerable<T> data, int statusCode, string[] acceptedMimeTypes);
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
