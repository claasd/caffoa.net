using System;
using Caffoa;
using DemoV2.Text.Json.Model;
using Microsoft.AspNetCore.Mvc;

namespace DemoV2.Text.Json.Errors
{
    [Serializable]
    public class ClientException : CaffoaClientError
    {
        public ClientException()
        {
        }
        public STJError Element { get; set; } = new STJError();
        public override IActionResult Result => new JsonResult(Element) { StatusCode = 400 };
    }
}