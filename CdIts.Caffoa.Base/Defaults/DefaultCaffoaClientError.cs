using System.Runtime.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace Caffoa.Defaults;

/// <summary>
/// Error that is thrown by <see cref="DefaultCaffoaErrorHandler"/> on various errors.
/// It will be translated into a REST Return with Error Code 400 and an string message.
/// </summary>
[Serializable]
public class DefaultCaffoaClientError : CaffoaClientError
{
    public DefaultCaffoaClientError(string msg) : base(msg)
    {
    }

    public DefaultCaffoaClientError(string msg, Exception inner) : base(msg, inner)
    {
    }

    protected DefaultCaffoaClientError(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public override IActionResult Result => new ContentResult {Content = Message, StatusCode = 400};
}