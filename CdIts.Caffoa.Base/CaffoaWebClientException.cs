﻿using System.Runtime.Serialization;

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
#if NET8_0_OR_GREATER
    [Obsolete(DiagnosticId = "SYSLIB0051")] // add this attribute to GetObjectData
#endif
    protected CaffoaWebClientException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}

[Serializable]
public class CaffoaWebClientException<T> : CaffoaWebClientException where T: class
{
    public T Result { get; }

    public CaffoaWebClientException(int statusCode, T result) : base(statusCode, $"Error {statusCode}, see Result for error.")
    {
        Result = result;
    }
    public CaffoaWebClientException(int statusCode, T result, string raw) : base(statusCode, $"Error {statusCode}: {raw}")
    {
        Result = result;
    }
#if NET8_0_OR_GREATER
    [Obsolete(DiagnosticId = "SYSLIB0051")] // add this attribute to GetObjectData
#endif
    protected CaffoaWebClientException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
