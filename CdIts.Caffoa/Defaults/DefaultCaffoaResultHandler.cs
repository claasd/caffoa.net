using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Caffoa.Defaults;

public class DefaultCaffoaResultHandler : ICaffoaResultHandler
{
    private JsonSerializerSettings _serializerSettings;

    public DefaultCaffoaResultHandler()
    {
        _serializerSettings = null;
    }

    public DefaultCaffoaResultHandler(JsonSerializerSettings serializerSettings)
    {
        _serializerSettings = serializerSettings;
    }

    public virtual IActionResult Json(object data, int statusCode)
        => Handle(new JsonResult(data) { StatusCode = statusCode, SerializerSettings = _serializerSettings });


    public virtual IActionResult StatusCode(int statusCode)
        => Handle(new StatusCodeResult(statusCode));

    public virtual IActionResult Handle(IActionResult input)
        => input;
}