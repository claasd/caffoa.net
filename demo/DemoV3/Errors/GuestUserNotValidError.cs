using Demov3.Errors;
using DemoV3.Model;

namespace DemoV3.Errors
{
    public class GuestUserNotValidClientError : ClientError
    {
        public GuestUserNotValidClientError()
        {
            Element = new Error()
            {
                Status = "GuestUserNotValid",
                Message = "The guest user's email must match the user-id"
            };
        }
    }
}