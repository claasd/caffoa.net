using System.Runtime.Serialization;

namespace Caffoa;

[Serializable]
public class CaffoaWebClientException : Exception
{
    public int StatusCode { get; }
    public string ErrorMessage { get; }

    public CaffoaWebClientException(int statusCode, string error) : base($"Error {statusCode}: {error}")
    {
        StatusCode = statusCode;
        ErrorMessage = error;
    }

    protected CaffoaWebClientException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}

[Serializable]
public class CaffoaWebClientException<T> : CaffoaWebClientException where T: class
{
    public int StatusCode { get; }
    public T Result { get; }

    public CaffoaWebClientException(int statusCode, T result) : base(statusCode, $"ErrorCode {statusCode}, see Result for error.")
    {
        StatusCode = statusCode;
        Result = result;
    }
    protected CaffoaWebClientException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
