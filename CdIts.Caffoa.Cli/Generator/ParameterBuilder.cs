using CdIts.Caffoa.Cli.Model;

namespace CdIts.Caffoa.Cli.Generator;

public class ParameterBuilder
{
    public const string OpenapiTagsParameterName = "openApiTags";

    public record Parameter(string Type, string Name)
    {
        public string? DefaultValue { get; set; }
        public List<string> Attributes { get; set; } = new();
        public bool IsBody { get; set; }
        public string Declaration => $"{string.Join(" ", Attributes)} {Type} {Name}{(DefaultValue != null ? $" = {DefaultValue}" : "")}".Trim();
        public static implicit operator string(Parameter p) => p.Declaration;
        public override string ToString()
        {
            return this;
        }
    }

    public record Overload(IEnumerable<Parameter> ParametersIncludingBody)
    {
        public string Declaration => string.Join(", ", ParametersIncludingBody);
        public Parameter? BodyParameter => ParametersIncludingBody.FirstOrDefault(p => p.IsBody);
        public static implicit operator string(Overload overload) => overload.Declaration;
        public override string ToString()
        {
            return this;
        }
    }
    
    private readonly bool _useDateOnly;
    private readonly bool _useDateTime;
    private readonly bool _addAspNetAttributes;
    private readonly List<Parameter> _parameters = new();
    private readonly List<Parameter> _queryParameters = new();
    private readonly List<Parameter> _bodies = new();
    private bool _withCancellation;
    private Parameter? CancellationToken => _withCancellation? new Parameter("CancellationToken", "cancellationToken") { DefaultValue = "default"} : null;

    private ParameterBuilder(bool useDateOnly, bool useDateTime, bool addAspNetAttributes)
    {
        _useDateOnly = useDateOnly;
        _useDateTime = useDateTime;
        _addAspNetAttributes = addAspNetAttributes;
    }

    public static ParameterBuilder Instance(bool useDateOnly, bool useDateTime, bool addAspNetAttributes = false)
    {
        return new ParameterBuilder(useDateOnly, useDateTime, addAspNetAttributes);
    }

    public ParameterBuilder AddPathParameters(IEnumerable<ParameterObject> parameters)
    {
        _parameters.AddRange(parameters.Where(p => !p.IsQueryParameter).Select(p =>
        {
            var typeName = p.GetTypeName(_useDateOnly, _useDateTime);
           
            var result = new Parameter(typeName, p.Name);
            if (_addAspNetAttributes) result.Attributes.Add("[FromRoute]");
            return result;
        }));
        return this;
    }

    public ParameterBuilder AddDurableClient(bool isolated)
    {
        if (isolated)
            _parameters.Insert(0, new Parameter("DurableTaskClient","durableTaskClient"));
        else
            _parameters.Insert(0, new Parameter("IDurableOrchestrationClient","orchestrationClient"));
        return this;
    }
    public ParameterBuilder AddTags()
    {
        _parameters.Insert(0, new Parameter("IReadOnlyList<string>", OpenapiTagsParameterName));
        return this;
    }
    public void AddQueryParameters(IEnumerable<ParameterObject> queryParameters, bool nullableDefaults = false)
    {
        _queryParameters.AddRange(queryParameters.Select(p =>
        {
            var typeName = p.GetTypeName(_useDateOnly, _useDateTime);
            var nullableAddition = nullableDefaults && !p.Required && typeName != "string" && !typeName.EndsWith('?')? "?" : "";
            var result = new Parameter($"{typeName}{nullableAddition}", p.VarName);
            if (_addAspNetAttributes) result.Attributes.Add("[FromQuery]");
            if (p.IsEnum && p.DefaultValue != null)
                result.DefaultValue = $"{typeName}.{ModelGenerator.EnumNameForValue(p.DefaultValue)}";
            else if (p.DefaultValue != null)
                result.DefaultValue = p.DefaultValue;
            else if (!p.Required)
                result.DefaultValue = "null";
            return result;
        }));
    }

    public ParameterBuilder AddCancellationToken()
    {
        _withCancellation = true;
        return this;
    }

    public ParameterBuilder AddBody(string type, string name)
    {
        var result = new Parameter(type, name) { IsBody = true };
        if (_addAspNetAttributes) result.Attributes.Add("[FromBody]"); 
        _bodies.Add(result);
        return this;
    }

    public List<Overload> BuildOverloads()
    {
        if (_bodies.Any()) 
            return _bodies.Select(b=>new Overload(GetOrderedParameters(b))).ToList();
        return new() { new Overload(GetOrderedParameters(null)) };

    }

    public List<string> Build() => BuildOverloads().Select(o=>o.Declaration).ToList();

    private IEnumerable<Parameter> GetOrderedParameters(Parameter? body)
    {
        foreach (var parameter in _parameters) yield return parameter;
        if (body != null) yield return body;
        foreach (var parameter in _queryParameters) yield return parameter;
        if (CancellationToken != null) yield return CancellationToken;
    }
}