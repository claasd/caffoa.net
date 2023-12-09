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
#if NET8_0_OR_GREATER
    [Obsolete(DiagnosticId = "SYSLIB0051")] // add this attribute to GetObjectData
#endif
    protected CaffoaValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}