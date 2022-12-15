﻿using System.Net;
using FluentAssertions;
using Newtonsoft.Json;

namespace CdIts.AzFuncTestHelper;

public static class HttpResponseMessageExtensions
{
    public static readonly HttpStatusCode[] DefaultStatusCodes =
    {
        HttpStatusCode.OK, HttpStatusCode.Created, HttpStatusCode.Accepted, HttpStatusCode.NoContent
    };

    public static Task Check(this Task<HttpResponseMessage> result) => result.Check(DefaultStatusCodes);

    public static Task Check(this Task<HttpResponseMessage> result, HttpStatusCode expectedStatusCode) =>
        result.Check(new[] { expectedStatusCode });

    public static async Task Check(this Task<HttpResponseMessage> result, IEnumerable<HttpStatusCode> expectedStatusCodes) =>
        (await result).StatusCode.Should().BeOneOf(expectedStatusCodes);

    public static Task<T> Json<T>(this Task<HttpResponseMessage> result) where T : class =>
        result.Json<T>(DefaultStatusCodes);


    public static Task<T> Json<T>(this Task<HttpResponseMessage> result, HttpStatusCode expectedResult) where T : class =>
        result.Json<T>(new[] { expectedResult });

    public static async Task<T> Json<T>(this Task<HttpResponseMessage> result, HttpStatusCode[] expectedStatusCodes)
        where T : class
    {
        var response = await result;
        var content = await response.Content.ReadAsStringAsync();
        response.StatusCode.Should().BeOneOf(expectedStatusCodes, content);
        return JsonConvert.DeserializeObject<T>(content)!;
    }
}