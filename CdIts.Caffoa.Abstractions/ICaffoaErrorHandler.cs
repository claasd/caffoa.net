using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Caffoa;

/// <summary>
/// Interface for caffoa error handling.
/// </summary>
public interface ICaffoaErrorHandler
{
    /// <summary>
    /// is called when the spec requires a content to be passed, but no content was given. 
    /// </summary>
    CaffoaClientError NoContent();
    
    /// <summary>
    /// is called when the spec requires a certain type, but the parsing of the payload failed.
    /// The passed Exception is the exception that raised by <see cref="ICaffoaJsonParser"/> 
    /// </summary>
    CaffoaClientError JsonParseError(Exception err);
    
    /// <summary>
    /// is called when the spec requires a certain type, but the parsing of the payload failed.
    /// The passed Exception is the exception that raised by <see cref="ICaffoaJsonParser"/> 
    /// </summary>
    CaffoaClientError ParameterConvertError(string fieldName, string type, Exception err);
    
    /// <summary>
    /// Is called when the function cannot decide which implementation to use.
    /// This only happens when OneOf is used, and the discriminator is missing or not recognized.
    /// See https://swagger.io/docs/specification/data-models/inheritance-and-polymorphism/
    /// </summary>
    /// <param name="fieldName">the name of the discriminator field</param>
    /// <param name="value">The value that was passed. Could be null, string int of a different primitive type, based on the api spec</param>
    /// <param name="allowedValues">a list of all allowed values as strings, according to the parsed spec</param>
    CaffoaClientError WrongContent(string fieldName, object value, string[] allowedValues);

    /// <summary>
    /// Is called when an exception was thrown and was not handled.
    /// The Handler can either handle the exception and return an IActionResult, or can do some logging
    /// and rethrow the error or throw a different error.
    /// </summary>
    /// <param name="e">The Exception that occured</param>
    /// <param name="request">The request object</param>
    /// <param name="functionName">the function name that was called</param>
    /// <param name="route">the route (e.g. api/getSomething/{user}</param>
    /// <param name="operation">the method (e.g. post, get, patch ...)</param>
    /// <param name="namedParams">a list of values that are part of the route</param>
    IActionResult HandleFunctionException(Exception e, HttpRequest request, string functionName, string route, string operation,
        params (string, object)[] namedParams);

    
}