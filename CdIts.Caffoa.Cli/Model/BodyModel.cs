namespace CdIts.Caffoa.Cli.Model;

public interface IBodyModel
{
    string? ContentType { get; }
}

public class NullBodyModel : IBodyModel
{
    public string? ContentType { get; }

    public NullBodyModel(string? contentType = null)
    {
        ContentType = contentType;
    }
}

public class SimpleBodyModel : IBodyModel
{
    public string TypeName { get; }
    public string ContentType { get; }

    public SimpleBodyModel(string typeName, string contentType)
    {
        TypeName = typeName;
        ContentType = contentType;
    }
}

public class SelectionBodyModel : IBodyModel
{
    public SelectionBodyModel(string disriminator, string contentType)
    {
        Disriminator = disriminator;
        ContentType = contentType;
    }

    public string Disriminator { get; }
    public string ContentType { get; }
    public Dictionary<string, string> Mapping { get; } = new();
}
