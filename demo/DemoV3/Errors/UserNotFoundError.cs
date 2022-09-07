using System;
using System.Runtime.Serialization;
using Demov3.Errors;
using DemoV3.Model;

namespace DemoV3.Errors
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