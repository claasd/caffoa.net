using CdIts.Caffoa.Cli.Model;

namespace CdIts.Caffoa.Cli.Generator;

public class ParameterBuilder
{
    private readonly bool _useDateOnly;
    private readonly bool _useDateTime;
    private readonly List<string> _parameters = new();
    private readonly List<string> _queryParameters = new();
    private readonly List<string> _bodies = new();
    private bool _withCancellation;

    private ParameterBuilder(bool useDateOnly, bool useDateTime)
    {
        _useDateOnly = useDateOnly;
        _useDateTime = useDateTime;
    }

    public static ParameterBuilder Instance(bool useDateOnly, bool useDateTime)
    {
        return new ParameterBuilder(useDateOnly, useDateTime);
    }

    public ParameterBuilder AddPathParameters(IEnumerable<ParameterObject> parameters)
    {
        _parameters.AddRange(parameters.Where(p => !p.IsQueryParameter).Select(p =>
        {
            var typeName = p.GetTypeName(_useDateOnly, _useDateTime);
            return $"{typeName} {p.Name}";
        }));
        return this;
    }

    public ParameterBuilder AddDurableClient()
    {
        _parameters.Insert(0, "IDurableOrchestrationClient orchestrationClient");
        return this;
    }

    public void AddQueryParameters(IEnumerable<ParameterObject> queryParameters, bool nullableDefaults = false)
    {
        _queryParameters.AddRange(queryParameters.Select(p =>
        {
            var typeName = p.GetTypeName(_useDateOnly, _useDateTime);
            var nullableAddition = nullableDefaults && !p.Required && typeName != "string" && !typeName.EndsWith("?")? "?" : "";
            var result = $"{typeName}{nullableAddition} {p.Name}";
            if(p.IsEnum && p.DefaultValue != null)
                result += $" = {typeName}.{ModelGenerator.EnumNameForValue(p.DefaultValue)}";
            else if (p.DefaultValue != null) 
                result += $" = {p.DefaultValue}";
            else if (!p.Required)
                result += $" = null";
            return result;
        }));
    }

    public ParameterBuilder AddCancellationToken()
    {
        _withCancellation = true;
        return this;
    }

    public ParameterBuilder AddBody(string bodyParam)
    {
        _bodies.Add(bodyParam);
        return this;
    }

    public List<string> Build()
    {
        var result = new List<string>();
        if(_bodies.Any())
            result.AddRange(_bodies.Select(BuildForBody));
        else
            result.Add(BuildForBody(null));
        return result;
    }

    private string BuildForBody(string? body)
    {
        var elements = new List<string>(_parameters);
        if(body != null)
            elements.Add(body);
        elements.AddRange(_queryParameters);
        if(_withCancellation)
            elements.Add("CancellationToken cancellationToken = default");
        return string.Join(", ", elements);
    }
}