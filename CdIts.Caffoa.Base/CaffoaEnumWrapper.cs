namespace Caffoa;

// ReSharper disable VirtualMemberCallInConstructor

public interface ICaffoaEnumWrapper
{
    string StringValue { get; set; }
}

public class CaffoaEnumWrapper<T> : IEquatable<CaffoaEnumWrapper<T>>, ICaffoaEnumWrapper where T : Enum
{
    protected T _value;

    public virtual T Value
    {
        get => _value;
        set => _value = value;
    }

    public virtual string StringValue
    {
        get => _value.ToString();
        set => _value = ParseString(value);
    }

    public CaffoaEnumWrapper(T value)
    {
        _value = value;
    }
    public CaffoaEnumWrapper(string value)
    {
        _value = ParseString(value);
    }
    public CaffoaEnumWrapper()
    {
    }

    protected virtual T ParseString(string value) => EnumConverter.FromString<T>(value);

    public static implicit operator T(CaffoaEnumWrapper<T> value) => value.Value;

    public bool Equals(CaffoaEnumWrapper<T> other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Value.Equals(other.Value);
    }

    public bool Equals(T other) => other is not null && _value.Equals(other);

    public override bool Equals(object obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() == typeof(T)) return Equals((T)obj);
        if (obj.GetType() != GetType()) return false;
        return Equals((CaffoaEnumWrapper<T>)obj);
    }

    // ReSharper disable once NonReadonlyMemberInGetHashCode
    public override int GetHashCode() => _value.GetHashCode();
}