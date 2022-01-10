namespace Caffoa;

public interface ICaffoaConverter
{
    DateTime ToDate(string parameter, string parameterName);
    DateTime ToDateTime(string parameter, string parameterName);
}