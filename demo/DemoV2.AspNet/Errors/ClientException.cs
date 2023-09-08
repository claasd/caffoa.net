using System.Runtime.Serialization;
using Caffoa;
using DemoV2.AspNet.Model;
using Microsoft.AspNetCore.Mvc;

namespace DemoV2.AspNet.Errors
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

        public ASPError Element { get; set; } = new ASPError();
        public override IActionResult Result => new JsonResult(Element) { StatusCode = 400 };
    }
}