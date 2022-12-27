using CdIts.Caffoa.Cli.Config;
using CdIts.Caffoa.Cli.Model;

namespace CdIts.Caffoa.Cli.Generator.Formatter;

public class PropertyFormatter
{
    private readonly PropertyData _property;
    private readonly CaffoaGlobalConfig _config;

    public PropertyFormatter(PropertyData property, CaffoaGlobalConfig config)
    {
        _property = property;
        _config = config;
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
        if (_config.Flavor is CaffoaConfig.GenerationFlavor.SystemTextJson)
            return "";
        return _property.Required switch
        {
            true when _property.Nullable => ", Required = Required.AllowNull",
            true => ", Required = Required.Always",
            _ => ""
        };
    }

    public string JsonExtraProperties()
    {
//        if (_property.Required && _config.Flavor is CaffoaConfig.GenerationFlavor.SystemTextJson)
//            return "\n        [JsonRequired]";
        return "";
    }

    public string Type()
    {
        var name = _config.UseDateOnly is true
            ? _property.TypeName
            : _property.TypeName.Replace("DateOnly", "DateTimeOffset").Replace("TimeOnly", "TimeSpan");
        if (_property.IsArray)
            return $"ICollection<{name}>";
        if (_property.IsMap)
            return $"Dictionary<string, {name}>";
        if (_property.TypeName == "object")
            return _config.GetGenericType();
        return name;
    }

    public string Default(bool addSemicolonEnEmpty)
    {
        var name = _config.UseDateOnly is true
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
        if (!string.IsNullOrEmpty(_property.Converter))
            tags.Add($"[JsonConverter(typeof({_property.Converter}))]\n        ");
        else if (_property.TypeName.StartsWith("DateOnly"))
        {
            if (_config.UseDateOnly is true)
                tags.Add("[JsonConverter(typeof(CaffoaDateOnlyConverter))]\n        ");
            else
                tags.Add("[JsonConverter(typeof(CaffoaDateConverter))]\n        ");
        }
        else if (_property.TypeName.StartsWith("TimeOnly"))
        {
            if (_config.UseDateOnly is true)
                tags.Add("[JsonConverter(typeof(CaffoaTimeOnlyConverter))]\n        ");
            else
                tags.Add("[JsonConverter(typeof(CaffoaTimeSpanConverter))]\n        ");
        }

        return string.Join("", tags);
    }

    public string JsonTagName() =>
        _config.Flavor is CaffoaConfig.GenerationFlavor.SystemTextJson ? "JsonPropertyName" : "JsonProperty";

    public string Imports() => Imports(_config.Flavor);

    public static string Imports(CaffoaConfig.GenerationFlavor? flavor)
    {
        if (flavor is CaffoaConfig.GenerationFlavor.SystemTextJson)
            return "using System.Text.Json.Serialization;";
        return "using Newtonsoft.Json;\nusing Newtonsoft.Json.Converters;";
    }
}