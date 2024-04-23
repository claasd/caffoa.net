using CdIts.Caffoa.Cli.Errors;

namespace CdIts.Caffoa.Cli.Config;

public class RequestBodyTypeConfig
{
    private string? _type;

    public string Type
    {
        get => _type ?? throw new ConfigurationMissingException("'type' is required when specifying 'requestBodyType'");
        set => _type = value;
    }
    public string ContentType { get; set; } = "application/json";

    public string? Import { get; set; }
    public FilterConfig Filter { get; set; } = new();
}
