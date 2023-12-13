using System.ComponentModel;
using System.Reflection;
using System.Runtime.Serialization;

namespace Caffoa;

public static class EnumConverter
{
    /// <summary>
    /// Returns the [EnumMember] value if present, else returns the name of the enum
    /// </summary>
    public static string Value(this Enum value) => EnumValue(value);

    /// <summary>
    /// returns a comma seperated list of enum string values. See <see cref="Value"/>.
    /// </summary>
    public static string AsStringList<T>(this IEnumerable<T> values) where T : Enum
    {
        return string.Join(",", values.Select(v => v.Value()));
    }
    public static string EnumValue<T>(T value) where T : Enum
    {
        var type = typeof(T);
        var dataType = Convert.ChangeType(value, value.GetTypeCode()); 
        foreach (var field in type.GetFields(BindingFlags.Static | BindingFlags.Public))
        {
            var obj = (T)field.GetValue(null)!;
            var dataType2 = Convert.ChangeType(obj, obj.GetTypeCode());
            if (dataType.Equals(dataType2))
                return field.GetCustomAttribute(typeof(EnumMemberAttribute)) is EnumMemberAttribute customAttribute ? customAttribute.Value ?? field.Name : field.Name;
        }
        return value.ToString();
    }
    
    public static T FromString<T>(string value, StringComparison comparer = StringComparison.OrdinalIgnoreCase)
        where T : Enum => (T)FromString(typeof(T), value, comparer);

    public static object FromString(Type type, string value,
        StringComparison comparer = StringComparison.OrdinalIgnoreCase)
    {
        var names = Enum.GetNames(type);
        foreach (var name in names)
        {
            var f = type.GetField(name, BindingFlags.Public | BindingFlags.Static)!;
            var v = f.GetValue(null)!;
            if (string.Compare(name, value, comparer) == 0)
                return v;
            var specifiedName = f.GetCustomAttributes(typeof(EnumMemberAttribute), true)
                .Cast<EnumMemberAttribute>()
                .Select(a => a.Value)
                .SingleOrDefault();
            if (specifiedName != null && string.Compare(specifiedName, value, comparer) == 0)
                return v;
        }

        throw new InvalidEnumArgumentException(
            $"The value of argument '{nameof(value)}' ('{value}') is invalid for Enum type '{type}'.");
    }
}