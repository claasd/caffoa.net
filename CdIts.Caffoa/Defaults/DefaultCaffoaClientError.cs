using Microsoft.AspNetCore.Mvc;

namespace Caffoa.Defaults;

public class DefaultCaffoaClientError : CaffoaClientError
{
    public DefaultCaffoaClientError(string msg) : base(msg)
    {
    }

    public DefaultCaffoaClientError(string msg, Exception inner) : base(msg, inner)
    {
    }

    public override IActionResult Result => new ContentResult {Content = Message, StatusCode = 400};
}