namespace CdIts.Caffoa.Cli.Errors;

public class ConfigurationMissingError : Exception
{
    public ConfigurationMissingError(string? message) : base(message)
    {
    }
}