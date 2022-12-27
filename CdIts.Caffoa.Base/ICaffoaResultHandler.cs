using Microsoft.AspNetCore.Mvc;

namespace Caffoa;

/// <summary>
/// interface for serializing outgoing data
/// </summary>
public interface ICaffoaResultHandler
{
    /// <summary>
    /// Should return a valid JSON result with the passed object as payload and the passed statusCode as statusCode
    /// </summary>
    IActionResult Json(object data, int statusCode);
    IActionResult Json<T>(IEnumerable<T> data, int statusCode);

    string JsonString(object o);
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
