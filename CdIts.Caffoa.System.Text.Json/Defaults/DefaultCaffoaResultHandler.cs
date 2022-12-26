using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace Caffoa.Defaults;

/// <summary>
/// Default Result handler. Returns a JsonResult or StatusResult.
/// can optionally take a JsonSerializerSettings.
/// All results are routed through <see cref="Handle"/>.
/// If you need to enhance all results with headers or other data, you can overwrite Handle.
/// </summary>
public class DefaultCaffoaResultHandler : ICaffoaResultHandler
{
    protected JsonSerializerOptions SerializerOptions { get; set; }

    public DefaultCaffoaResultHandler()
    {
        SerializerOptions = null;
    }

    public DefaultCaffoaResultHandler(JsonSerializerOptions serializerSettings)
    {
        SerializerOptions = serializerSettings;
    }

    public string JsonString(object o) => JsonSerializer.Serialize(o, SerializerOptions);

    public virtual IActionResult Json(object data, int statusCode)
        => Handle(new JsonResult(data) { StatusCode = statusCode, SerializerSettings = SerializerOptions });


    public virtual IActionResult StatusCode(int statusCode)
        => Handle(new StatusCodeResult(statusCode));

    public virtual IActionResult Handle(IActionResult input)
        => input;
}