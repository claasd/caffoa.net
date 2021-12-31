using Microsoft.OpenApi.Readers;

namespace CdIts.Caffoa.Cli.Errors;

public class CaffoaValidationError : Exception
{
    public OpenApiDiagnostic Diagnostic { get; }

    public CaffoaValidationError(string message, OpenApiDiagnostic diagnostic) : base(message)
    {
        Diagnostic = diagnostic;
    }
}