namespace Caffoa;

public interface ICaffoaParseErrorHandler
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
}