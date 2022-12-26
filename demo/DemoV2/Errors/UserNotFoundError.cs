using System;
using System.Runtime.Serialization;
using DemoV2.Model;

namespace DemoV2.Errors
{
    [Serializable]
    public class UserNotFoundClientException : ClientException
    {
        public UserNotFoundClientException()
        {
            Element = new Error()
            {
                Status = "UserNotFound",
                Message = "The specified user was not found"
            };
        }

        protected UserNotFoundClientException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}