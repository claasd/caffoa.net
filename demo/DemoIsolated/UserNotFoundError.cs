using System.Runtime.Serialization;
using DemoIsolated.Model;

namespace DemoIsolated
{
    [Serializable]
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

        protected UserNotFoundClientException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}