using System.Globalization;
using System.Linq.Expressions;

namespace Caffoa.Defaults;

public class DefaultCaffoaConverter : ICaffoaConverter
{
    private ICaffoaErrorHandler _errorHandler;

    public DefaultCaffoaConverter(ICaffoaErrorHandler errorHandler)
    {
        _errorHandler = errorHandler;
    }

    public DateTime ToDate(string parameter, string parameterName)
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

    public DateTime ToDateTime(string parameter, string parameterName)
    {
        try
        {
            return DateTime.Parse(parameter);
        }
        catch (Exception e)
        {
            throw _errorHandler.ParameterConvertError(parameterName, "date", e);
        }
    }
}
