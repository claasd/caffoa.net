using System;
using System.Runtime.Serialization;
using DemoV2.Text.Json.Model;

namespace DemoV2.Text.Json.Errors
{
    [Serializable]
    public class GuestUserNotValidClientException : ClientException
    {
        public GuestUserNotValidClientException()
        {
            Element = new STJError()
            {
                Status = "GuestUserNotValid",
                Message = "The guest user's email must match the user-id"
            };
        }

        protected GuestUserNotValidClientException(SerializationInfo info, StreamingContext context) : base(info,
            context)
        {
        }
    }
}