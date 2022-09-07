using System.Runtime.Serialization;

namespace CdIts.Caffoa.Cli.Errors;

[Serializable]
public class ConfigurationMissingException : Exception
{
    public ConfigurationMissingException(string? message) : base(message)
    {
    }

    protected ConfigurationMissingException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}