namespace CdIts.Caffoa.Cli.Config;

public class ServiceConfig
{
    public string ApiPath { get; set; }
    public CaffoaConfig? Config { get; set; }
    public FunctionConfig? Function;
    public ModelConfig? Model;
    

}