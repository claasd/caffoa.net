using Microsoft.AspNetCore.Mvc;

namespace Caffoa;

public interface ICaffoaResultHandler
{
    IActionResult Json(object data, int statusCode);
    IActionResult StatusCode(int statusCode);
    IActionResult Handle(IActionResult input);
    
}