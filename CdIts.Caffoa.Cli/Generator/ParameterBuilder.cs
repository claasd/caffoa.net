﻿using CdIts.Caffoa.Cli.Model;

namespace CdIts.Caffoa.Cli.Generator;

public class ParameterBuilder
{
    private readonly bool _useDateOnly;
    private readonly List<string> _parameters = new();
    private readonly List<string> _queryParameters = new();
    private readonly List<string> _bodies = new();
    private bool _withCancellation;

    private ParameterBuilder(bool useDateOnly)
    {
        _useDateOnly = useDateOnly;
    }

    public static ParameterBuilder Instance(bool useDateOnly)
    {
        return new ParameterBuilder(useDateOnly);
    }

    public ParameterBuilder AddPathParameters(IEnumerable<ParameterObject> parameters)
    {
        _parameters.AddRange(parameters.Where(p => !p.IsQueryParameter).Select(p =>
        {
            var typeName = p.GetTypeName(_useDateOnly);
            return $"{typeName} {p.Name}";
        }));
        return this;
    }

    public ParameterBuilder AddDurableClient()
    {
        _parameters.Insert(0, "IDurableOrchestrationClient orchestrationClient");
        return this;
    }

    public void AddQueryParameters(IEnumerable<ParameterObject> queryParameters)
    {
        _queryParameters.AddRange(queryParameters.Select(p =>
        {
            var typeName = p.GetTypeName(_useDateOnly);
            var result = $"{typeName} {p.Name}";
            if (p.DefaultValue != null)
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