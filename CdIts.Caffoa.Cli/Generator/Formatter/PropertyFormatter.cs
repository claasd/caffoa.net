using CdIts.Caffoa.Cli.Model;

namespace CdIts.Caffoa.Cli.Generator.Formatter;

public class PropertyFormatter
{
    private readonly PropertyData _property;

    public PropertyFormatter(PropertyData property)
    {
        _property = property;
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
        var name = _property.TypeName;
        if (_property.IsArray)
            return $"ICollection<{name}>";
        if (_property.IsMap)
            return $"Dictionary<string, {name}>";

        return name;
    }

    public string Default(bool addSemicolonEnEmpty)
    {
        var name = _property.TypeName;
        if (_property.IsArray)
            return $" = new List<{name}>();";
        if (_property.IsMap)
            return $" = new Dictionary<string, {name}>();";
        if (_property.Default != null)
        {
            if (name.StartsWith("DateOnly"))
                return $" = DateTime.Parse({_property.Default});";
            if (name.StartsWith("TimeOnly"))
                return $" = TimeOnly.Parse({_property.Default});";
            if (name.StartsWith("DateTime"))
                return $" = DateTime.Parse({_property.Default});";
            if (name.StartsWith("TimeSpan"))
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
        if (!string.IsNullOrEmpty(_property.Converter))
            tags.Add($"[JsonConverter(typeof({_property.Converter}))]\n        ");
        else if (_property.TypeName.StartsWith("DateOnly"))
            tags.Add("[JsonConverter(typeof(CaffoaDateOnlyConverter))]\n        ");
        else if (_property.TypeName.StartsWith("TimeOnly"))
            tags.Add("[JsonConverter(typeof(CaffoaTimeOnlyConverter))]\n        ");
        return string.Join("", tags);
    }
}