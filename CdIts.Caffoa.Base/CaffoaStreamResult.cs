using System.Net.Http.Headers;

namespace Caffoa;

#pragma warning disable CA1816
public class CaffoaStreamResult(MemoryStream stream, HttpResponseHeaders headers) : IDisposable, IAsyncDisposable
{
    public MemoryStream Stream { get; } = stream;
    public HttpResponseHeaders Headers { get; } = headers;
    public void Dispose() => Stream.Dispose();
    public ValueTask DisposeAsync() => Stream.DisposeAsync();
}