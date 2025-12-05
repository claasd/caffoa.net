using System.Net.Http.Headers;

namespace Caffoa;

#pragma warning disable CA1816
public class CaffoaStreamResult(MemoryStream stream, HttpContentHeaders contentHeaders, HttpResponseHeaders headers) : IDisposable, IAsyncDisposable
{
    public MemoryStream Stream { get; } = stream;
    public HttpContentHeaders ContentHeaders { get; } = contentHeaders;
    public HttpResponseHeaders Headers { get; } = headers;
    public void Dispose() => Stream.Dispose();
    public ValueTask DisposeAsync() => Stream.DisposeAsync();
}