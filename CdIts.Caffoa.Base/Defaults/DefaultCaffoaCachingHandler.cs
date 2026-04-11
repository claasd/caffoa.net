using Microsoft.AspNetCore.Mvc;

namespace Caffoa.Defaults;

public class DefaultCaffoaCachingHandler(ICaffoaResultHandler resultHandler) : ICaffoaCachingHandler
{
    public string JsonString(object o) => resultHandler.JsonString(o);
    public ValueTask<IActionResult> GetCachedResult(CaffoaResultHandlerParameter parameter) => ValueTask.FromResult<IActionResult>(null);
    public ValueTask<IActionResult> Result(object data, int statusCode, CaffoaResultHandlerParameter parameter) => ValueTask.FromResult(resultHandler.Result(data, statusCode, parameter));
    public ValueTask<IActionResult> Result<T>(IEnumerable<T> data, int statusCode, CaffoaResultHandlerParameter parameter) => ValueTask.FromResult(resultHandler.Result(data, statusCode, parameter));
    public ValueTask<IActionResult> StatusCode(int statusCode) => ValueTask.FromResult(resultHandler.StatusCode(statusCode));
    public ValueTask<IActionResult> Handle(IActionResult input) => ValueTask.FromResult(resultHandler.Handle(input));
}