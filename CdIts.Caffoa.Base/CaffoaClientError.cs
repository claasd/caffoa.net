using System.Runtime.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace Caffoa;

/// <summary>
/// represents a client error, that should be returned to the caller with a 4xx result.
/// Class should be inherited for specialized errors.
/// </summary>
[Serializable]
public abstract class CaffoaClientError : Exception
{
    protected CaffoaClientError(SerializationInfo info, StreamingContext context) : base(info, context){}
    protected CaffoaClientError() {}
    protected CaffoaClientError(string msg) : base(msg){}
    protected CaffoaClientError(string msg, Exception inner) : base(msg, inner){}
    public abstract IActionResult Result { get; }
}
