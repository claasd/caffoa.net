using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Caffoa.Defaults;

public class DefaultCaffoaErrorHandler : ICaffoaErrorHandler
{
    private readonly ILogger _logger;

    public DefaultCaffoaErrorHandler(ILogger logger)
    {
        this._logger = logger;
    }

    public virtual CaffoaClientError NoContent()
    {
        return new DefaultCaffoaClientError("Error during JSON parsing of payload: no body found");
    }

    public virtual CaffoaClientError JsonParseError(Exception err)
    {
        var inner = err;
        while (inner.InnerException != null)
            inner = inner.InnerException;
        return new DefaultCaffoaClientError($"Error during JSON parsing of payload: {err.Message}", err);
    }

    public virtual CaffoaClientError WrongContent(string type, object value, string[] allowedValues)
    {
        var allowedValuesString = string.Join(", ", allowedValues);
        var valueString = value == null ? "<null>" : value.ToString();
        return new DefaultCaffoaClientError($"Error during JSON parsing of payload: Could not find correct value to parse for discriminator '{type}'. Must be one of [{allowedValuesString}], not '{valueString}'");
    }

    public virtual void LogException(Exception e, HttpRequest request, string functionName, string route, string operation,
        params (string, object)[] namedParams)
    {
        var debugInformation = new Dictionary<string,  string>();
        debugInformation["Error"] = e.Message;
        debugInformation["ExecptionType"] = e.GetType().Name;
        debugInformation["FunctionName"] = functionName;
        debugInformation["Route"] = route;
        debugInformation["Operation"] = operation;
        foreach (var (name,value) in namedParams)
        {
            debugInformation["p_" + name] = value.ToString();
        }
        debugInformation["Payload"] = GetPayloadForExceptionLogging(request);
        _logger.LogCritical(JsonConvert.SerializeObject(debugInformation));
    }
    
    public virtual string GetPayloadForExceptionLogging(HttpRequest req)
    {
        try
        {
            if (req.ContentLength == 0)
                return "no payload";

            using var ms = new MemoryStream();
            req.Body.CopyTo(ms);
            return Convert.ToBase64String(ms.ToArray());
        }
        catch (Exception e)
        {
            return "error while reading payload: " + e.Message;
        }
    }
}