using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Caffoa.Defaults;

/// <summary>
/// Default Result handler. Returns a JsonResult or StatusResult.
/// can optionally take a JsonSerializerSettings.
/// All results are routed through <see cref="Handle"/>.
/// If you need to enhance all results with headers or other data, you can overwrite Handle.
/// </summary>
public class DefaultCaffoaResultHandler : ICaffoaResultHandler
{
    protected JsonSerializerSettings SerializerSettings { get; set; }

    public DefaultCaffoaResultHandler()
    {
        SerializerSettings = null;
    }

    public DefaultCaffoaResultHandler(JsonSerializerSettings serializerSettings)
    {
        SerializerSettings = serializerSettings;
    }


    public virtual string JsonString(object o) => JsonConvert.SerializeObject(o, SerializerSettings);
    public IActionResult Json(object data, int statusCode) =>
        new ContentResult()
        {
            Content = JsonString(data),
            StatusCode = statusCode,
            ContentType = MediaTypeNames.Application.Json
        };
    public IActionResult Json<T>(IEnumerable<T> data, int statusCode) => Json((object)data, statusCode);

    public virtual IActionResult StatusCode(int statusCode)
        => Handle(new StatusCodeResult(statusCode));

    public virtual IActionResult Handle(IActionResult input)
        => input;
}