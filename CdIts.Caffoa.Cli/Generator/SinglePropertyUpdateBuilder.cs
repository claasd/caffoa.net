using System.Text;
using CdIts.Caffoa.Cli.Config;
using CdIts.Caffoa.Cli.Model;

namespace CdIts.Caffoa.Cli.Generator;

public class SinglePropertyUpdateBuilder
{
    private readonly StringBuilder _sb = new();
    private readonly PropertyData _property;
    private readonly string _targetClassName;
    private readonly string _shallowBase;
    private bool _hasCloning;
    private readonly string _name;

    public SinglePropertyUpdateBuilder(string prefix, string? targetClassName, PropertyData property, bool useEnums,
        bool useOther = true)
    {
        _property = property;
        _name = $"{prefix}{_property.Name.ToObjectName()}";
        _targetClassName = targetClassName is null ? "" : $"{targetClassName}.";
        if (useEnums && property.CanBeEnum())
            EnumCopy(useOther);
        else
            DefaultCopy(useOther);
        _shallowBase = _sb.ToString();
    }

    private void EnumCopy(bool useOther)
    {
        var name = _property.Name.ToObjectName();
        var other = useOther ? "other." : "";
        if (_property.Nullable)
            _sb.Append($"{other}{name} == null ? null : ({_targetClassName}{name}Value){other}{name}");
        else
            _sb.Append($"({_targetClassName}{name}Value){other}{name}");
    }

    private void DefaultCopy(bool useOther)
    {
        var other = useOther ? "other." : "";
        var name = _property.Name.ToObjectName();
        _sb.Append($"{other}{name}");
    }

    public SinglePropertyUpdateBuilder AppendOtherSchemaCopy()
    {
        if (!_property.IsOtherSchema) return this;
        _sb.Append('?');
        _sb.Append($".To{_property.TypeName.ToObjectName()}()");
        _hasCloning = true;
        return this;
    }

    public SinglePropertyUpdateBuilder AppendJTokenDeepClone(CaffoaConfig.GenerationFlavor? flavor)
    {
        if (_property.TypeName is not "object") return this;
        _sb.Append(flavor is CaffoaConfig.GenerationFlavor.SystemTextJson ? "?.Clone()" : "?.DeepClone()");
        _hasCloning = true;
        return this;
    }

    public SinglePropertyUpdateBuilder AppendArrayCopy()
    {
        if (!_property.IsArray) return this;
        if (_property.InnerTypeIsOtherSchema)
            _sb.Append($"?.Select(value=>value?.To{_property.TypeName.ToObjectName()}())");
        _sb.Append("?.ToList()");
        _hasCloning = true;
        return this;
    }

    public SinglePropertyUpdateBuilder AppendMapCopy()
    {
        if (!_property.IsMap) return this;

        _sb.Append("?.ToDictionary(entry => entry.Key, entry => entry.Value");
        if (_property.InnerTypeIsOtherSchema)
            _sb.Append($"?.To{_property.TypeName.ToObjectName()}()");
        _sb.Append(')');
        _hasCloning = true;
        return this;
    }

    public string Build(bool shallowSeparator)
    {
        if (!shallowSeparator || !_hasCloning)
            return $"{_name} = {_sb}";
        return $"{_name} = deepClone ? {_sb} : {_shallowBase}";
    }
}