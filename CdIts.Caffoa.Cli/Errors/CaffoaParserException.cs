using System.Runtime.Serialization;

namespace CdIts.Caffoa.Cli.Errors;

[Serializable]
public class CaffoaParserException : Exception
{
    public CaffoaParserException(string? message) : base(message)
    {
    }
    public CaffoaParserException(string? message, Exception inner) : base(message, inner)
    {
    }

    protected CaffoaParserException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
