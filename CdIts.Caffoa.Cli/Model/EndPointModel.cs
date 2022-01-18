namespace CdIts.Caffoa.Cli.Model;

public class EndPointModel
{
    public string Operation { get; }
    public string Name { get; }
    public string Route { get; }
    public List<ParameterObject> Parameters { get; set; } = new();

    public List<string> DocumentationLines { get; set; } = new();
    public List<ResponseModel> Responses { get; set; } = new();
    public bool HasRequestBody { get; set; }
    public IBodyModel RequestBodyType { get; set; } = new NullBodyModel();
    public List<string> Imports { get; } = new();
    public bool DurableClient { get; set; }

    public EndPointModel(string operation, string name, string route)
    {
        Operation = operation.ToLower();
        Name = name;
        Route = route;
    }
}