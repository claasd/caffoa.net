using System.Reflection;
using System.Resources;
using System.Text;

namespace CdIts.Caffoa.Cli.Generator;

public class Templates
{
    public static string GetTemplate(string name)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var file = $"CdIts.Caffoa.Cli.data.{name}";
        var stream = assembly.GetManifestResourceStream(file);
        if (stream is null)
            throw new MissingManifestResourceException($"Could not load {file}");
        using var reader = new StreamReader(stream, Encoding.UTF8);
        return reader.ReadToEnd();
    }
}