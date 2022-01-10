namespace Caffoa;

public interface ICaffoaConverter
{
    DateTime ParseDate(string parameter, string parameterName);
    DateTime ParseDateTime(string parameter, string parameterName);
    
    T Parse<T>(string parameter, string parameterName);
}