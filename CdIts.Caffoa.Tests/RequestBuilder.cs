﻿using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Moq;
using Newtonsoft.Json;

namespace CdIts.Caffoa.Tests;

public class RequestBuilder
{
    private readonly Dictionary<string, StringValues> _query = new();
    private Stream? _data;
    private readonly HeaderDictionary _header = new();
    public static HttpRequest Default => new RequestBuilder().Build();

    public RequestBuilder Query(string key, string? value)
    {
        if(value != null)
            _query.Add(key, value);
        return this;
    }

    public RequestBuilder Header(string name, string? value)
    {
        if(value != null)
            _header.Add(name, value);
        return this;
    }
    public RequestBuilder Content<T>(T content) =>
        Content(JsonConvert.SerializeObject(content));
    public RequestBuilder Content(string content) => Content(Encoding.UTF8.GetBytes(content));
    public RequestBuilder Content(byte[] data) => Content(new MemoryStream(data) as Stream);

    public RequestBuilder Content(Stream data)
    {
        _data = data;
        return this;
    }

    public HttpRequest Build() => BuildMock().Object;

    public Mock<HttpRequest> BuildMock()
    {
        var mockRequest = new Mock<HttpRequest>();
        mockRequest.Setup(x => x.Body).Returns(_data ?? new MemoryStream());
        mockRequest.Setup(x => x.Headers).Returns(_header);
        mockRequest.Setup(r => r.Query).Returns(new QueryCollection(_query));
        mockRequest.Setup(r => r.HttpContext.RequestAborted).Returns(new CancellationToken());
        return mockRequest;
    }
}