using System;
using System.Runtime.Serialization;
using DemoV2.Model;

namespace DemoV2.Errors
{
    [Serializable]
    public class GuestUserNotValidClientException : ClientException
    {
        public GuestUserNotValidClientException()
        {
            Element = new Error()
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