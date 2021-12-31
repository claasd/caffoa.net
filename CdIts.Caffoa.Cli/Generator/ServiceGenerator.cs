using System.Reflection;
using System.Resources;
using System.Text;
using CdIts.Caffoa.Cli.Config;
using CdIts.Caffoa.Cli.Generator.Formatter;
using CdIts.Caffoa.Cli.Model;

namespace CdIts.Caffoa.Cli.Generator;

public class ServiceGenerator
{
    private readonly ServiceConfig _service;

    public ServiceGenerator(ServiceConfig service)
    {
        _service = service;
    }

    public void WriteModel(List<SchemaItem> objects, CaffoaConfig serviceConfig)
    {
        var file = ReadEmbeddedFile("ModelTemplate.tpl");
        Directory.CreateDirectory(_service.Model!.TargetFolder);
        foreach (var item in objects)
        {
            var formatter = new SchemaItemFormatter(item);
            var fileName = $"{item.ClassName}.generated.cs";
            var parameters = new Dictionary<string, object>();
            parameters["NAMESPACE"] = _service.Model!.Namespace;
            parameters["IMPORTS"] = formatter.Imports(serviceConfig.Imports);
            parameters["NAME"] = item.ClassName;
            parameters["PARENTS"] = formatter.Parents(objects);
            parameters["RAWNAME"] = item.Name;
            parameters["UPDATEPROPS"] = "";
            parameters["PROPERTIES"] = FormatProperties(item);
            parameters["DESCRIPTION"] = formatter.Description;
            var formatted = file.FormatDict(parameters);
            File.WriteAllText(Path.Combine(_service.Model.TargetFolder, fileName), formatted);
        }
    }

    private string FormatProperties(SchemaItem item)
    {
        var file = ReadEmbeddedFile("ModelPropertyTemplate.tpl");
        foreach (var property in item.Properties!)
        {
            
        }

        return "";
    }

    private string ReadEmbeddedFile(string name)
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