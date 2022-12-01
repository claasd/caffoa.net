using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CdIts.Caffoa.Tests.TestGeneratedModules;

public static class ActionResultExtensions
{
    public static async Task Check(this Task<HttpResponseMessage> task) => (await task).Check();

    public static void Check(this HttpResponseMessage result) => result.Check(new[]
    {
        HttpStatusCode.OK, HttpStatusCode.Created, HttpStatusCode.Accepted, HttpStatusCode.NoContent
    });

    public static void Check(this HttpResponseMessage result, HttpStatusCode[] expectedStatusCodes) =>
        result.StatusCode.Should().BeOneOf(expectedStatusCodes);

    public async static Task<T> Json<T>(this Task<HttpResponseMessage> task) where T : class
    {
        return await (await task).Json<T>();
    }
    
    public static async Task<T> Json<T>(this Task<IActionResult> task) where T : class
    {
        return await task.ToMsg().Json<T>();
    }

    public static Task<T> Json<T>(this HttpResponseMessage result) where T : class => result.Json<T>(new[]
    {
        HttpStatusCode.OK, HttpStatusCode.Created, HttpStatusCode.Accepted, HttpStatusCode.NoContent
    });

    public static Task<T> Json<T>(this HttpResponseMessage result, HttpStatusCode expectedResult) where T : class =>
        result.Json<T>(new[] { expectedResult });

    public static async Task<T> Json<T>(this HttpResponseMessage result, HttpStatusCode[] expectedStatusCodes)
        where T : class
    {
        var content = await result.Content.ReadAsStringAsync();
        result.StatusCode.Should().BeOneOf(expectedStatusCodes, content);
        return JsonConvert.DeserializeObject<T>(content)!;
    }

    public static async Task<HttpResponseMessage> ToMsg(this Task<IActionResult> task)
    {
        try
        {
            var result = await task;
            return result.ToMsg();
        }
        catch (Exception e)
        {
            return new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent(e.Message)
            };
        }
    }

    public static HttpResponseMessage ToMsg(this IActionResult res)
    {
        return res switch
        {
            JsonResult jsonResult => new HttpResponseMessage((HttpStatusCode)(jsonResult.StatusCode ?? 200))
            {
                Content = new StringContent(
                    JsonConvert.SerializeObject(jsonResult.Value, null,
                        jsonResult.SerializerSettings as JsonSerializerSettings), Encoding.UTF8,
                    "application/json")
            },
            ContentResult contentResult => new HttpResponseMessage(
                (HttpStatusCode)(contentResult.StatusCode ?? 200))
            {
                Content = new StringContent(contentResult.Content ?? "", Encoding.UTF8, contentResult.ContentType)
            },
            FileStreamResult fileStreamResult => new HttpResponseMessage()
            {
                Content = new StreamContent(fileStreamResult.FileStream)
            },
            StatusCodeResult statusCodeResult => new HttpResponseMessage(
                (HttpStatusCode)statusCodeResult.StatusCode) { Content = new ByteArrayContent(Array.Empty<byte>()) },
            _ => new HttpResponseMessage() { Content = new ByteArrayContent(Array.Empty<byte>()) }
        };
    }
}