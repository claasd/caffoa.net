using System;
using System.Runtime.Serialization;
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

        protected ClientException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public STJError Element { get; set; } = new STJError();
        public override IActionResult Result => new JsonResult(Element) { StatusCode = 400 };
    }
}