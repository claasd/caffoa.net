using System.Runtime.Serialization;
using Caffoa;
using DemoIsolated.Model;
using Microsoft.AspNetCore.Mvc;

namespace DemoIsolated
{
    [Serializable]
    public class ClientException : CaffoaClientError
    {
        public ClientException()
        {
        }

        protected ClientException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public IsoError Element { get; set; } = new IsoError();
        public override IActionResult Result => new JsonResult(Element) { StatusCode = 400 };
    }
}