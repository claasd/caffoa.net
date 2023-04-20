using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

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
            return EnumConverter.FromString<T>(parameter.Trim());
        }
        catch (Exception e)
        {
            throw _errorHandler.ParameterConvertError(parameterName, typeof(T).Name, e);
        }
    }
    
    public ICollection<T> ParseEnumArray<T>(ICaffoaJsonParser parser, string parameter, string parameterName, bool ignoreCase = true) where T : Enum
    {
        try
        {
            if (string.IsNullOrWhiteSpace(parameter))
                return Array.Empty<T>();
            parameter = parameter.Trim();
            IEnumerable<string> stringList = parameter[0] == '[' ? parser.Parse<string[]>(parameter) : parameter.Split(',');
            return stringList.Select(v => ParseEnum<T>(v, parameterName, ignoreCase)).Distinct().ToArray();
        }
        catch (Exception e)
        {
            throw _errorHandler.ParameterConvertError(parameterName, $"array[{typeof(T)}", e);
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