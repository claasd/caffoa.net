namespace CdIts.Caffoa.Cli.Generator;

public class ExtensionGenerator
{
    public string Folder { get; }
    public string Namespace { get; }

    private readonly List<string> _elements = new();
    private readonly List<string> _imports = new();
    
    public ExtensionGenerator(string folder, string ns)
    {
        Folder = folder;
        Namespace = ns;
    }

    public void Add(IEnumerable<string> data, IEnumerable<string> imports)
    {
        _elements.AddRange(data);
        _imports.AddRange(imports);
    }

    public void Create()
    {
        var file = Templates.GetTemplate("ModelExtensionTemplate.tpl");
        var fileName = "Extensions.generated.cs";
        var parameters = new Dictionary<string, object>();
        parameters["NAMESPACE"] = Namespace;
        parameters["IMPORTS"] = string.Join("",_imports.Distinct().Select(i => $"using {i};\n"));
        parameters["CONTENT"] = string.Join("\n\n", _elements);
        var formatted = file.FormatDict(parameters);
        File.WriteAllText(Path.Combine(Folder, fileName), formatted.ToSystemNewLine());
    }
}
