using System.Runtime.Serialization;
using Microsoft.OpenApi.Readers;

namespace CdIts.Caffoa.Cli.Errors;

[Serializable]
public class CaffoaValidationException : Exception
{
    public OpenApiDiagnostic? Diagnostic { get; }

    public CaffoaValidationException(string message, OpenApiDiagnostic diagnostic) : base(message)
    {
        Diagnostic = diagnostic;
    }

    protected CaffoaValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
