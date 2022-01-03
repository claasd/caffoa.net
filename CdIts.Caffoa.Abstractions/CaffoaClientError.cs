using Microsoft.AspNetCore.Mvc;

namespace Caffoa;

public abstract class CaffoaClientError : Exception
{
    public CaffoaClientError() {}
    public CaffoaClientError(string msg) : base(msg){}
    public CaffoaClientError(string msg, Exception inner) : base(msg, inner){}
    public abstract IActionResult Result { get; }
}
