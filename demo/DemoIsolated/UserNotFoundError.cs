using DemoIsolated.Model;

namespace DemoIsolated
{
    public class UserNotFoundClientException : ClientException
    {
        public UserNotFoundClientException()
        {
            Element = new IsoError()
            {
                Status = "UserNotFound",
                Message = "The specified user was not found"
            };
        }
    }
}