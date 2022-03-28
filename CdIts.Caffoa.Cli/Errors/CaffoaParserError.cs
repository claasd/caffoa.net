namespace CdIts.Caffoa.Cli.Errors;

public class CaffoaParserError : Exception
{
    public CaffoaParserError(string? message) : base(message)
    {
    }
    public CaffoaParserError(string? message, Exception inner) : base(message, inner)
    {
    }
}
