using Demov3.Errors;
using DemoV3.Model;

namespace DemoV3.Errors
{
    public class UserNotFoundClientError : ClientError
    {
        public UserNotFoundClientError()
        {
            Element = new Error()
            {
                Status = "UserNotFound",
                Message = "The specified user was not found"
            };
        }
    }
}