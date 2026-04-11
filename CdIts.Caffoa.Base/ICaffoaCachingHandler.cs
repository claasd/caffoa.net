using Microsoft.AspNetCore.Mvc;

namespace Caffoa;

public interface ICaffoaCachingHandler : ICaffoaJsonSerializer
{
    ValueTask<IActionResult> GetCachedResult(CaffoaResultHandlerParameter parameter);
    ValueTask<IActionResult> Result(object data, int statusCode, CaffoaResultHandlerParameter parameter);
    ValueTask<IActionResult> Result<T>(IEnumerable<T> data, int statusCode, CaffoaResultHandlerParameter parameter);
    /// <summary>
    /// Should return a valid result without payload and the passed statusCode as statusCode
    /// </summary>
    ValueTask<IActionResult> StatusCode(int statusCode);
    
    /// <summary>
    /// can be used to enhance raw results with headers or other data.
    /// Is only called if neither <see cref="Result"/> nor <see cref="StatusCode"/> is called.
    /// </summary>
    ValueTask<IActionResult> Handle(IActionResult input);
}