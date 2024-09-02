using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Caffoa;

public class CaffoaClientStringException : CaffoaClientError
{
    public int StatusCode { get; set; }

    public CaffoaClientStringException(string msg, int statusCode = StatusCodes.Status400BadRequest) : base(msg)
    {
        StatusCode = statusCode;
    }

    public override IActionResult Result => new ContentResult
    {
        Content = Message,
        StatusCode = StatusCode
    };
}