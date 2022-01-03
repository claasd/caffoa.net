using Microsoft.AspNetCore.Http;

namespace Caffoa;

public interface ICaffoaErrorHandler
{
    CaffoaClientError NoContent();
    CaffoaClientError JsonParseError(Exception err);
    CaffoaClientError WrongContent(string type, object value, string[] allowedValues);

    void LogException(Exception e, HttpRequest request, string functionName, string route, string operation,
        params (string, object)[] namedParams);
}