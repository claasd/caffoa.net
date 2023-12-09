using System.Runtime.Serialization;
using Caffoa;
using DemoIsolated.Model;
using Microsoft.AspNetCore.Mvc;

namespace DemoIsolated
{
    public class ClientException : CaffoaClientError
    {
        public IsoError Element { get; set; } = new();
        public override IActionResult Result => new JsonResult(Element) { StatusCode = 400 };
    }
}