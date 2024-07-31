namespace CdIts.Caffoa.Cli.Model;

public class Server
{
    public Server(string uri)
    {
        Uri = uri;
        ResolvedUris = new List<string>() { uri };
    }

    public string Uri { get; set; }
    public List<string> ResolvedUris { get; set; }
}