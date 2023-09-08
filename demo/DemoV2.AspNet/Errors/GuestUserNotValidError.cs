using System.Runtime.Serialization;
using DemoV2.AspNet.Model;

namespace DemoV2.AspNet.Errors
{
    [Serializable]
    public class GuestUserNotValidClientException : ClientException
    {
        public GuestUserNotValidClientException()
        {
            Element = new ASPError()
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