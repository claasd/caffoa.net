namespace CdIts.Caffoa.Cli.Model;

public interface IBodyModel {
}

public class NullBodyModel : IBodyModel
{
}

public class SimpleBodyModel : IBodyModel
{
    public string TypeName { get; }
    public SimpleBodyModel(string typeName)
    {
        TypeName = typeName;
    }
}

public class SelectionBodyModel : IBodyModel
{
    public SelectionBodyModel(string disriminator)
    {
        Disriminator = disriminator;
    }

    public string Disriminator { get; }
    public Dictionary<string, string> Mapping { get; } = new();

}