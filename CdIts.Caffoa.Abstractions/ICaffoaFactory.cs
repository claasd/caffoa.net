using Microsoft.AspNetCore.Http;

namespace Caffoa;

public interface ICaffoaFactory<T>
{
    public T Instance(HttpRequest request);
}