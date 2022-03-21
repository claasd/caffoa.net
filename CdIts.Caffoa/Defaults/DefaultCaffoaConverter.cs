using System.Globalization;

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

    public DateTime ParseDate(string parameter, string parameterName)
    {
        try
        {
            return DateTime.ParseExact(parameter, "yyyy-MM-dd", CultureInfo.InvariantCulture);
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
        throw _errorHandler.ParameterConvertError(parameterName, "time", new ArgumentException("Could not parse time. Expected format HH:mm:ss or H:m"));    
    }
    
#if NET6_0    
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
    
    public DateTime ParseDateTime(string parameter, string parameterName)
    {
        try
        {
            return DateTime.Parse(parameter);
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

    public T Parse<T>(string parameter, string parameterName) 
    {
        try
        {
            return (T)Convert.ChangeType(parameter, typeof(T), CultureInfo.InvariantCulture);
        }
        catch (Exception e)
        {
            throw _errorHandler.ParameterConvertError(parameterName, nameof(T), e);
        }
    }
}
