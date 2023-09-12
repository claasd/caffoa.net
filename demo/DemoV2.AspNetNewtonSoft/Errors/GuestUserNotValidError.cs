using System.Runtime.Serialization;
using DemoV2.AspNetNewtonSoft.Model;

namespace DemoV2.AspNetNewtonSoft.Errors
{
    [Serializable]
    public class GuestUserNotValidClientException : ClientException
    {
        public GuestUserNotValidClientException()
        {
            Element = new ASPNError()
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