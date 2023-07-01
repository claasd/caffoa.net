using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Caffoa.Defaults;

public class CaffoaEarlySerializingResultHandler : DefaultCaffoaResultHandler
{
    public CaffoaEarlySerializingResultHandler()
    {
    }

    public CaffoaEarlySerializingResultHandler(JsonSerializerSettings serializerSettings) : base(serializerSettings)
    {
    }

    public override IActionResult Json(object data, int statusCode) =>
        new ContentResult()
        {
            Content = JsonString(data),
            StatusCode = statusCode,
            ContentType = MediaTypeNames.Application.Json
        };
    public override IActionResult Json<T>(IEnumerable<T> data, int statusCode) => Json((object)data, statusCode);
}