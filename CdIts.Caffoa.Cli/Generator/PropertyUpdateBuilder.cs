using System.Text;
using CdIts.Caffoa.Cli.Model;

namespace CdIts.Caffoa.Cli.Generator;

public class PropertyUpdateBuilder
{
    private readonly StringBuilder _sb = new();
    private readonly PropertyData _property;
    private readonly string _targetClassName;

    public PropertyUpdateBuilder(string prefix, string targetClassName, PropertyData property, bool useEnums)
    {
        _sb.Append(prefix);
        this._property = property;
        this._targetClassName = targetClassName;
        if (useEnums && property.CanBeEnum())
            EnumCopy();
        else
            DefaultCopy();
    }

    private void EnumCopy()
    {
        var name = _property.Name.ToObjectName();
        if (_property.Nullable)
            _sb.Append($"{name} = other.{name} is null ? null : ({_targetClassName}{name}Value)other.{name}");
        else
            _sb.Append($"{name} = ({_targetClassName}{name}Value)other.{name}");
    }

    private void DefaultCopy()
    {
        var name = _property.Name.ToObjectName();
        _sb.Append($"{name} = other.{name}");
    }

    public PropertyUpdateBuilder AppendOtherSchemaCopy()
    {
        if (!_property.IsOtherSchema) return this;
        if (_property.Nullable)
            _sb.Append('?');
        _sb.Append($".To{_property.TypeName.ToObjectName()}()");
        return this;
    }

    public PropertyUpdateBuilder AppendJTokenDeepClone()
    {
        if (_property.TypeName is "JToken")
            _sb.Append("?.DeepClone()");
        return this;
    }

    public PropertyUpdateBuilder AppendArrayCopy()
    {
        if (!_property.IsArray) return this;
        if (_property.InnerTypeIsOtherSchema)
            _sb.Append($".Select(value=>value.To{_property.TypeName.ToObjectName()}())");
        _sb.Append(".ToList()");
        return this;
    }

    public PropertyUpdateBuilder AppendMapCopy()
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
        _sb.Append(';');
        return _sb.ToString();
    }
}