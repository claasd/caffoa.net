using System.Net;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CdIts.AzFuncTestHelper;

public static class ActionResultExtensions
{
    public static async Task<HttpResponseMessage> ToMsg(this Task<IActionResult> task)
    {
        try
        {
            var result = await task;
            return result.ToMsg();
        }
        catch (Exception e)
        {
            await Console.Error.WriteLineAsync(e.Message);
            await Console.Error.WriteLineAsync(e.StackTrace);
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

    public static async Task Check(this Task<IActionResult> result) => await result.ToMsg().Check();
    public static async Task Check(this Task<IActionResult> result, HttpStatusCode expectedCode) => await result.ToMsg().Check(expectedCode);
    public static async Task Check(this Task<IActionResult> result, HttpStatusCode[] expectedCodes) => await result.ToMsg().Check(expectedCodes);

    public static Task<T> Json<T>(this Task<IActionResult> result) where T: class => result.ToMsg().Json<T>();
    public static Task<T> Json<T>(this Task<IActionResult> result, HttpStatusCode expectedCode) where T: class => result.ToMsg().Json<T>(expectedCode);
    public static Task<T> Json<T>(this Task<IActionResult> result, HttpStatusCode[] expectedCodes) where T: class => result.ToMsg().Json<T>(expectedCodes);

}