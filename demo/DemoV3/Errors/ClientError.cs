using Caffoa;
using Microsoft.AspNetCore.Mvc;
using DemoV3.Model;


namespace Demov3.Errors
{
    public class ClientError : CaffoaClientError
    {
        public Error Element { get; set; } = new Error();
        public override IActionResult Result => new JsonResult(Element) {StatusCode = 400};
    }
}