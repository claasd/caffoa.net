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

    public virtual string JsonString(object o) => JsonSerializer.Serialize(Convert.ChangeType(o, o.GetType()), SerializerOptions); // System.Text.Json does not handle polymorphy of interfaces

    public virtual IActionResult Result<T>(IEnumerable<T> data, int statusCode, CaffoaResultHandlerParameter parameter) =>
        Result((object)data.Select(item => Convert.ChangeType(item, item.GetType())), statusCode, parameter); // System.Text.Json does not handle polymorphy of interfaces

    public virtual IActionResult Result(object data, int statusCode, CaffoaResultHandlerParameter parameter)
        => Handle(new JsonResult(data) { StatusCode = statusCode, SerializerSettings = SerializerOptions });


    public virtual IActionResult StatusCode(int statusCode)
        => Handle(new StatusCodeResult(statusCode));

    public virtual IActionResult Handle(IActionResult input)
        => input;
}