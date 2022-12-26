using System.ComponentModel;
using System.Reflection;
using System.Runtime.Serialization;

namespace Caffoa;

public static class EnumConverter
{
    public static string Value(this Enum value)
    {
        var name = Enum.GetName(value.GetType(), value);
        if (name == null) return Convert.ToString(value) ?? "";
        var field = value.GetType().GetTypeInfo().GetDeclaredField(name);
        if (field != null && field.GetCustomAttribute(typeof(EnumMemberAttribute)) is EnumMemberAttribute attribute)
            return attribute.Value ?? name;
        return name;
    }

    public static T FromString<T>(string value, StringComparison comparer = StringComparison.OrdinalIgnoreCase)
        where T : Enum
    {
        var type = typeof(T);
        var names = Enum.GetNames(type);
        foreach (var name in names)
        {
            var f = type.GetField(name, BindingFlags.Public | BindingFlags.Static)!;
            var v = (T)f.GetValue(null)!;
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
            $"The value of argument '{nameof(value)}' ('{value}') is invalid for Enum type '{typeof(T)}'.");
    }
}