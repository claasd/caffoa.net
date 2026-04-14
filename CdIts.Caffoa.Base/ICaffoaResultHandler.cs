using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Caffoa;

public record CaffoaResultHandlerParameter
{
    [Obsolete("The called constructor to CaffoaResultHandlerParameter is obsolete. Please upgrade and run caffoa CLI.")]
    public CaffoaResultHandlerParameter(string[] acceptedMimeTypes)
    {
        AcceptedMimeTypes = acceptedMimeTypes;
    }

    public CaffoaResultHandlerParameter(int[] ReturnedStatusCodes,
        string[] DefinedMimeTypes,
        HttpRequest Request,
        HttpMethod Method,
        string Path,
        Dictionary<string, object> PathParameters,
        object RequestObject = null)
    {
        this.ReturnedStatusCodes = ReturnedStatusCodes;
        this.DefinedMimeTypes = DefinedMimeTypes;
        this.Request = Request;
        this.Method = Method;
        this.Path = Path;
        this.PathParameters = PathParameters;
        this.RequestObject = RequestObject;
        AcceptedMimeTypes = Request?.Headers?.Accept ?? Array.Empty<string>();
    }

    public string[] AcceptedMimeTypes { get; private set; }
    public int[] ReturnedStatusCodes { get; init; }
    public string[] DefinedMimeTypes { get; init; }
    public HttpRequest Request { get; init; }
    public HttpMethod Method { get; init; }
    public string Path { get; init; }
    public Dictionary<string, object> PathParameters { get; init; }
    public object RequestObject { get; init; }
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
