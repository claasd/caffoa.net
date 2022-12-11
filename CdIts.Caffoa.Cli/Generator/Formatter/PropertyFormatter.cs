using CdIts.Caffoa.Cli.Model;

namespace CdIts.Caffoa.Cli.Generator.Formatter;

public class PropertyFormatter
{
    private readonly PropertyData _property;
    private readonly bool _net60;

    public PropertyFormatter(PropertyData property, bool net60)
    {
        _property = property;
        _net60 = net60;
    }

    public string Description()
    {
        if (_property.Description is null)
            return "";
        var itemDesc = _property.Description.Trim().Replace("\n", "\n        /// ");
        return $"/// <summary>\n        /// {itemDesc}\n        /// </summary>\n        ";
    }

    public string JsonProperty()
    {
        return _property.Required switch
        {
            true when _property.Nullable => ", Required = Required.AllowNull",
            true => ", Required = Required.Always",
            _ => ""
        };
    }

    public string Type()
    {
        var name = _net60
            ? _property.TypeName
            : _property.TypeName.Replace("DateOnly", "DateTimeOffset").Replace("TimeOnly", "TimeSpan");
        if (_property.IsArray)
            return $"ICollection<{name}>";
        if (_property.IsMap)
            return $"Dictionary<string, {name}>";

        return name;
    }

    public string Default(bool addSemicolonEnEmpty)
    {
        var name = _net60
            ? _property.TypeName
            : _property.TypeName.Replace("DateOnly", "DateTimeOffset").Replace("TimeOnly", "TimeSpan");
        if (_property.IsArray)
            return $" = new List<{name}>();";
        if (_property.IsMap)
            return $" = new Dictionary<string, {name}>();";
        if (_property.Default != null)
        {
            if (name == "DateOnly")
                return $" = DateOnly.Parse({_property.Default});";
            if (name == "TimeOnly")
                return $" = TimeOnly.Parse({_property.Default});";
            if (name == "DateTimeOffset")
                return $" = DateTimeOffset.Parse({_property.Default});";
            if (name == "TimeSpan")
                return $" = TimeSpan.Parse({_property.Default});";
            return $" = {_property.Default};";
        }

        if (!_property.Nullable && _property.IsOtherSchema)
            return $" = new {name}();";


        return addSemicolonEnEmpty ? ";" : "";
    }

    public string JsonTags()
    {
        var tags = _property.CustomAttributes.Select(a => $"[{a}]\n        ").ToList();
        if (_property.Deprecated)
            tags.Add("[Obsolete]\n        ");
        if(!string.IsNullOrEmpty(_property.Converter))
            tags.Add($"[JsonConverter(typeof({_property.Converter}))]\n        ");
        else if (_property.TypeName.StartsWith("DateOnly"))
        {
            if (_net60)
                tags.Add("[JsonConverter(typeof(CaffoaDateOnlyConverter))]\n        ");
            else
                tags.Add("[JsonConverter(typeof(CaffoaDateConverter))]\n        ");
        }
        else if (_property.TypeName.StartsWith("TimeOnly"))
        {
            if (_net60)
                tags.Add("[JsonConverter(typeof(CaffoaTimeOnlyConverter))]\n        ");
            else
                tags.Add("[JsonConverter(typeof(CaffoaTimeSpanConverter))]\n        ");
        }

        return string.Join("", tags);
    }
}
