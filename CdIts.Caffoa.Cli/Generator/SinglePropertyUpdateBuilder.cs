using System.Text;
using CdIts.Caffoa.Cli.Model;

namespace CdIts.Caffoa.Cli.Generator;

public class SinglePropertyUpdateBuilder
{
    private readonly StringBuilder _sb = new();
    private readonly PropertyData _property;
    private readonly string _targetClassName;

    public SinglePropertyUpdateBuilder(string prefix, string? targetClassName, PropertyData property, bool useEnums, bool useOther = true)
    {
        _sb.Append(prefix);
        this._property = property;
        this._targetClassName = targetClassName is null ? "" : $"{targetClassName}.";
        if (useEnums && property.CanBeEnum())
            EnumCopy(useOther);
        else
            DefaultCopy(useOther);
    }

    private void EnumCopy(bool useOther)
    {
        var name = _property.Name.ToObjectName();
        var other = useOther ? "other." : "";
        if (_property.Nullable)
            _sb.Append($"{name} = {other}{name} is null ? null : ({_targetClassName}{name}Value){other}{name}");
        else
            _sb.Append($"{name} = ({_targetClassName}{name}Value){other}{name}");
    }

    private void DefaultCopy(bool useOther)
    {
        var other = useOther ? "other." : "";
        var name = _property.Name.ToObjectName();
        _sb.Append($"{name} = {other}{name}");
    }

    public SinglePropertyUpdateBuilder AppendOtherSchemaCopy()
    {
        if (!_property.IsOtherSchema) return this;
        if (_property.Nullable)
            _sb.Append('?');
        _sb.Append($".To{_property.TypeName.ToObjectName()}()");
        return this;
    }

    public SinglePropertyUpdateBuilder AppendJTokenDeepClone()
    {
        if (_property.TypeName is "JToken")
            _sb.Append("?.DeepClone()");
        return this;
    }

    public SinglePropertyUpdateBuilder AppendArrayCopy()
    {
        if (!_property.IsArray) return this;
        if (_property.InnerTypeIsOtherSchema)
            _sb.Append($".Select(value=>value.To{_property.TypeName.ToObjectName()}())");
        _sb.Append(".ToList()");
        return this;
    }

    public SinglePropertyUpdateBuilder AppendMapCopy()
    {
        if (!_property.IsMap) return this;
        
        _sb.Append(".ToDictionary(entry => entry.Key, entry => entry.Value");
        if (_property.InnerTypeIsOtherSchema)
            _sb.Append($".To{_property.TypeName.ToObjectName()}()");
        _sb.Append(')');
        return this;
    }

    public string Build()
    {
        return _sb.ToString();
    }
}