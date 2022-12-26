using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Runtime.Serialization;

namespace Caffoa.Defaults;

/// <summary>
/// Converter that uses the default converter elements and raises an CaffoaClientError on failure
/// </summary>
public class DefaultCaffoaConverter : ICaffoaConverter
{
    private readonly ICaffoaErrorHandler _errorHandler;

    public DefaultCaffoaConverter(ICaffoaErrorHandler errorHandler)
    {
        _errorHandler = errorHandler;
    }

    public DateTimeOffset ParseDate(string parameter, string parameterName)
    {
        try
        {
            return DateTimeOffset.ParseExact(parameter, "yyyy-MM-dd", CultureInfo.InvariantCulture);
        }
        catch (Exception e)
        {
            throw _errorHandler.ParameterConvertError(parameterName, "date", e);
        }
    }

    public TimeSpan ParseTimeSpan(string parameter, string parameterName)
    {
        if (TimeSpan.TryParseExact(parameter, @"hh\:mm\:ss", CultureInfo.InvariantCulture, out var result))
            return result;
        if (TimeSpan.TryParseExact(parameter, @"h\:m", CultureInfo.InvariantCulture, out result))
            return result;
        throw _errorHandler.ParameterConvertError(parameterName, "time",
            new ArgumentException("Could not parse time. Expected format HH:mm:ss or H:m"));
    }

#if NET6_0_OR_GREATER
    public DateOnly ParseDateOnly(string parameter, string parameterName)
    {
        try
        {
            return DateOnly.ParseExact(parameter, "yyyy-MM-dd", CultureInfo.InvariantCulture);
        }
        catch (Exception e)
        {
            throw _errorHandler.ParameterConvertError(parameterName, "date", e);
        }
    }

    public TimeOnly ParseTimeOnly(string parameter, string parameterName)
    {
        try
        {
            return TimeOnly.Parse(parameter, CultureInfo.InvariantCulture);
        }
        catch (Exception e)
        {
            throw _errorHandler.ParameterConvertError(parameterName, "time", e);
        }
    }
#endif

    public DateTimeOffset ParseDateTime(string parameter, string parameterName)
    {
        try
        {
            return DateTimeOffset.Parse(parameter);
        }
        catch (Exception e)
        {
            throw _errorHandler.ParameterConvertError(parameterName, "date-time", e);
        }
    }

    public Guid ParseGuid(string parameter, string parameterName)
    {
        try
        {
            return Guid.Parse(parameter);
        }
        catch (Exception e)
        {
            throw _errorHandler.ParameterConvertError(parameterName, "uuid", e);
        }
    }

    public T ParseEnum<T>(string parameter, string parameterName, bool ignoreCase = true) where T : Enum
    {
        try
        {
            return EnumConverter.FromString<T>(parameter);
        }
        catch (Exception e)
        {
            throw _errorHandler.ParameterConvertError(parameterName, typeof(T).Name, e);
        }
    }

    public T Parse<T>(string parameter, string parameterName) => (T)Parse(parameter, typeof(T), parameterName);

    public object Parse(string parameter, Type type, string parameterName)
    {
        try
        {
            return Convert.ChangeType(parameter, type, CultureInfo.InvariantCulture);
        }
        catch (Exception e)
        {
            throw _errorHandler.ParameterConvertError(parameterName, type.Name, e);
        }
    }
}