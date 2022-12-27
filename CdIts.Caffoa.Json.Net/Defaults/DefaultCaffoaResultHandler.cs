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


    public string JsonString(object o) => JsonConvert.SerializeObject(o, SerializerSettings);
    public IActionResult Json<T>(IEnumerable<T> data, int statusCode)
        => Handle(new JsonResult(data) { StatusCode = statusCode, SerializerSettings = SerializerSettings });
    public virtual IActionResult Json(object data, int statusCode)
        => Handle(new JsonResult(data) { StatusCode = statusCode, SerializerSettings = SerializerSettings });


    public virtual IActionResult StatusCode(int statusCode)
        => Handle(new StatusCodeResult(statusCode));

    public virtual IActionResult Handle(IActionResult input)
        => input;
}