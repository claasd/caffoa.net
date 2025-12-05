using System;
using DemoV2.Text.Json.Model;

namespace DemoV2.Text.Json.Errors
{
    [Serializable]
    public class UserNotFoundClientException : ClientException
    {
        public UserNotFoundClientException()
        {
            Element = new STJError()
            {
                Status = "UserNotFound",
                Message = "The specified user was not found"
            };
        }
    }
}