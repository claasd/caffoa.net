using System.Runtime.Serialization;
using Caffoa;
using DemoV2.AspNetNewtonSoft.Model;
using Microsoft.AspNetCore.Mvc;

namespace DemoV2.AspNetNewtonSoft.Errors
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

        public ASPNError Element { get; set; } = new ASPNError();
        public override IActionResult Result => new JsonResult(Element) { StatusCode = 400 };
    }
}