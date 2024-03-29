using Microsoft.Extensions.Primitives;

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
    DateTimeOffset ParseDate(string parameter, string parameterName);
    
    /// <summary>
    /// Should parse openapi date format ("2022-01-01") into DateTime
    /// </summary>
    /// <param name="parameter">the input string</param>
    /// <param name="parameterName">the name of the variable as defined in the openapi spec</param>
    TimeSpan ParseTimeSpan(string parameter, string parameterName);
#if NET6_0_OR_GREATER
    DateOnly ParseDateOnly(string parameter, string parameterName);
    TimeOnly ParseTimeOnly(string parameter, string parameterName);
#endif
    /// <summary>
    /// Should parse openapi date-time ISO format into DateTime
    /// </summary>
    /// <param name="parameter">the input string</param>
    /// <param name="parameterName">the name of the variable as defined in the openapi spec</param>
    DateTimeOffset ParseDateTime(string parameter, string parameterName);

    /// <summary>
    /// Should parse openapi uuid format string into a Guid
    /// </summary>
    /// <param name="parameter">the input string</param>
    /// <param name="parameterName">the name of the variable as defined in the openapi spec</param>
    Guid ParseGuid(string parameter, string parameterName);
    
    /// <summary>
    /// Should parse enum types from string to the required enum type
    /// </summary>
    /// <param name="parameter">the input string</param>
    /// <param name="parameterName">the name of the variable as defined in the openapi spec</param>
    /// <param name="ignoreCase">set to false to make case-sensitive string-to-enum conversions</param>
    T ParseEnum<T>(string parameter, string parameterName, bool ignoreCase = true)  where T : Enum;
    
    /// <summary>
    /// Should parse enum types from string to the required enum type list
    /// </summary>
    /// <param name="parameter">the input string</param>
    /// <param name="parameterName">the name of the variable as defined in the openapi spec</param>
    /// <param name="ignoreCase">set to false to make case-sensitive string-to-enum conversions</param>
    ICollection<T> ParseEnumArray<T>(ICaffoaJsonParser parser, string parameter, string parameterName, bool ignoreCase = true)  where T : Enum;
    
    /// <summary>
    /// Should parse all other items supported by openapi (e.g. int, uint, long, ulong, Guid)
    /// </summary>
    /// <param name="parameter">the input string</param>
    /// <param name="parameterName">the name of the variable as defined in the openapi spec</param>
    T Parse<T>(string parameter, string parameterName);
}