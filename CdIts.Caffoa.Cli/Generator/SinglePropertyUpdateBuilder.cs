using System.Text;
using CdIts.Caffoa.Cli.Config;
using CdIts.Caffoa.Cli.Model;

namespace CdIts.Caffoa.Cli.Generator;

public class SinglePropertyUpdateBuilder
{
    private readonly StringBuilder _sb = new();
    private readonly PropertyData _property;
    private readonly string? _genericTypeName;
    private readonly string _targetClassName;
    private readonly string _shallowBase;
    private bool _hasCloning;
    private readonly string _name;

    public SinglePropertyUpdateBuilder(string prefix, string? targetClassName, PropertyData property, CaffoaConfig.EnumCreationMode enumMode,
        bool useOther = true, string? genericTypeName = null)
    {
        _property = property;
        _genericTypeName = genericTypeName;
        _name = $"{prefix}{_property.FieldName}";
        _targetClassName = targetClassName is null ? "" : $"{targetClassName}.";
        if (enumMode == CaffoaConfig.EnumCreationMode.Default && property.CanBeEnum())
            EnumCopy(useOther);
        else if (enumMode == CaffoaConfig.EnumCreationMode.Class && property.CanBeEnum())
            EnumClassCopy(useOther);
        else
            DefaultCopy(useOther);
        _shallowBase = _sb.ToString();
    }

    private void EnumCopy(bool useOther)
    {
        var name = _property.FieldName;
        var other = useOther ? "other." : "";
        if (_property.Nullable)
            _sb.Append($"{other}{name} == null ? null : ({_targetClassName}{name}Value){other}{name}");
        else
            _sb.Append($"({_targetClassName}{name}Value){other}{name}");
    }
    
    private void EnumClassCopy(bool useOther)
    {
        var name = _property.FieldName;
        var other = useOther ? "other." : "";
        if (_property.Nullable)
            _sb.Append($"{other}{name} == null ? null : new {_targetClassName}{name}ValueWrapper(({_targetClassName}{name}Value){other}{name}.Value)");
        else
            _sb.Append($"new {_targetClassName}{name}ValueWrapper(({_targetClassName}{name}Value){other}{name}.Value)");
    }

    private void DefaultCopy(bool useOther)
    {
        var other = useOther ? "other." : "";
        var name = _property.FieldName;
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
        if (_property.TypeName is not "object" || _property.IsMap || _property.IsArray || _genericTypeName != null) return this;
        
        _sb.Append(flavor switch
        {
            CaffoaConfig.GenerationFlavor.SystemTextJson => "?.Clone()",
            _ => "?.DeepClone()"
        });
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