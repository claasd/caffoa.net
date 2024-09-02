using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Caffoa;

public class CaffoaClientJsonException<T> : CaffoaClientError
{
    public T Element { get; set; }
    public int StatusCode { get; set; }
    public CaffoaClientJsonException(T element, int statusCode = StatusCodes.Status400BadRequest)
    {
        StatusCode = statusCode;
        Element = element;
    }

    public CaffoaClientJsonException(T element, string msg, int statusCode = StatusCodes.Status400BadRequest) : base(msg)
    {
        Element = element;
        StatusCode = statusCode;
    }

    public override IActionResult Result => new JsonResult(Element) { StatusCode = StatusCode };
}