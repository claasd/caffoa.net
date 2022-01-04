using Microsoft.AspNetCore.Mvc;

namespace Caffoa;

/// <summary>
/// represents a client error, that should be returned to the caller with a 4xx result.
/// Class should be inherited for specialized errors.
/// </summary>
public abstract class CaffoaClientError : Exception
{
    public CaffoaClientError() {}
    public CaffoaClientError(string msg) : base(msg){}
    public CaffoaClientError(string msg, Exception inner) : base(msg, inner){}
    public abstract IActionResult Result { get; }
}
