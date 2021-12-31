using CdIts.Caffoa.Cli.Errors;

namespace CdIts.Caffoa.Cli.Config;

public class ServiceConfig
{
    private string? _apiPath;
    public string ApiPath
    {
        get => _apiPath ?? throw new ConfigurationMissingError("'apiPath' is required for 'services'");
        set => _apiPath = value;
    }

    public CaffoaConfig? Config { get; set; }
    public FunctionConfig? Function;
    public ModelConfig? Model;
    
}