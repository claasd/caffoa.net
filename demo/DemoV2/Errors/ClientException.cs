using System;
using System.Runtime.Serialization;
using Caffoa;
using DemoV2.Model;
using Microsoft.AspNetCore.Mvc;

namespace DemoV2.Errors
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

        public Error Element { get; set; } = new Error();
        public override IActionResult Result => new JsonResult(Element) { StatusCode = 400 };
    }
}