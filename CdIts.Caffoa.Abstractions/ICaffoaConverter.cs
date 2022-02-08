namespace Caffoa;

/// <summary>
/// Interface to parse different incoming parameters from string to the correct format
/// </summary>
public interface ICaffoaConverter
{
    /// <summary>
    /// Should parse openapi date format ("2022-01-01") into DateTime
    /// </summary>
    /// <param name="parameter">the input string</param>
    /// <param name="parameterName">the name of the variable as defined in the openapi spec</param>
    DateTime ParseDate(string parameter, string parameterName);
#if NET6_0
    DateOnly ParseDateOnly(string date, string dateName);
#endif
    /// <summary>
    /// Should parse openapi date-time ISO format into DateTime
    /// </summary>
    /// <param name="parameter">the input string</param>
    /// <param name="parameterName">the name of the variable as defined in the openapi spec</param>
    DateTime ParseDateTime(string parameter, string parameterName);
    
    /// <summary>
    /// Should parse openapi uuid format string into a Guid
    /// </summary>
    /// <param name="parameter">the input string</param>
    /// <param name="parameterName">the name of the variable as defined in the openapi spec</param>
    Guid ParseGuid(string parameter, string parameterName);
    
    /// <summary>
    /// Should parse all other items supported by openapi (e.g. int, uint, long, ulong, Guid)
    /// </summary>
    /// <param name="parameter">the input string</param>
    /// <param name="parameterName">the name of the variable as defined in the openapi spec</param>
    T Parse<T>(string parameter, string parameterName);
}