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

    public T Parse<T>(string parameter, string parameterName) 
    {
        try
        {
            return (T)Convert.ChangeType(parameter, typeof(T));
        }
        catch (Exception e)
        {
            throw _errorHandler.ParameterConvertError(parameterName, nameof(T), e);
        }
    }
}
