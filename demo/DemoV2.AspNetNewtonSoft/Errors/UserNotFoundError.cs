using System.Runtime.Serialization;
using DemoV2.AspNetNewtonSoft.Model;

namespace DemoV2.AspNetNewtonSoft.Errors
{
    [Serializable]
    public class UserNotFoundClientException : ClientException
    {
        public UserNotFoundClientException()
        {
            Element = new ASPNError()
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