using Microsoft.AspNetCore.Http;

namespace Caffoa;

/// <summary>
/// Factory to create an implementation of a function interface.
/// </summary>
/// <typeparam name="T">The interface that was created by caffoa</typeparam>
public interface ICaffoaFactory<out T>
{
    /// <summary>
    /// Must return a valid instance of T.
    /// Can throw an CaffoaClientError or an Exception on error.
    /// </summary>
    /// <param name="request">The request is passed to allow the function to extract headers or other information</param>
    public T Instance(HttpRequest request);
}