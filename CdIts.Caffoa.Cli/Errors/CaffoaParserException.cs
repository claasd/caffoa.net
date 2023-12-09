namespace CdIts.Caffoa.Cli.Errors;


public class CaffoaParserException : Exception
{
    public CaffoaParserException(string? message) : base(message)
    {
    }
    public CaffoaParserException(string? message, Exception inner) : base(message, inner)
    {
    }
}
