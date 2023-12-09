namespace CdIts.Caffoa.Cli.Errors;

public class ConfigurationMissingException : Exception
{
    public ConfigurationMissingException(string? message) : base(message)
    {
    }

}