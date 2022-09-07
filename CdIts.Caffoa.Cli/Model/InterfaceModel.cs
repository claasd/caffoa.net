namespace CdIts.Caffoa.Cli.Model;

public class InterfaceModel
{
    public string? Discriminator { get; set; }
    public List<string> Children { get; } = new();
}
