using Caffoa;
using Caffoa.Defaults;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Newtonsoft.Json.Linq;
using DemoV1a.Model.Base;
using DemoV1a.Model;

namespace DemoV1a
{
    /// AUTO GENERATED CLASS
    public class DemoV1aUserFunctions
    {
        private readonly ILogger<DemoV1aUserFunctions> _logger;
        private readonly ICaffoaFactory<IDemoV1aUserService> _factory;
        private readonly ICaffoaErrorHandler _errorHandler;
        private readonly ICaffoaJsonParser _jsonParser;
        private readonly ICaffoaResultHandler _resultHandler;
        private readonly ICaffoaConverter _converter;
        public DemoV1aUserFunctions(ILogger<DemoV1aUserFunctions> logger, ICaffoaFactory<IDemoV1aUserService> factory, ICaffoaErrorHandler errorHandler = null, ICaffoaJsonParser jsonParser = null, ICaffoaResultHandler resultHandler = null, ICaffoaConverter converter = null) {
            _logger = logger;
            _factory = factory;
            _resultHandler = resultHandler ?? new DefaultCaffoaResultHandler();
            _errorHandler = errorHandler ?? new DefaultCaffoaErrorHandler(_logger, _resultHandler);
            _jsonParser = jsonParser ?? new DefaultCaffoaJsonParser(_errorHandler);
            _converter = converter ?? new DefaultCaffoaConverter(_errorHandler);
        }
        /// <summary>
        /// auto-generated function invocation.
        ///</summary>
        [FunctionName("UsersGetAsync")]
        public async Task<IActionResult> UsersGetAsync(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "api/users")]
            HttpRequest request)
        {
            try {
                int offsetValue = 0;
                if(request.Query.TryGetValue("offset", out var offsetQueryValue))
                    offsetValue = _converter.Parse<int>(offsetQueryValue, "offset");
                int limitValue = 1000;
                if(request.Query.TryGetValue("limit", out var limitQueryValue))
                    limitValue = _converter.Parse<int>(limitQueryValue, "limit");
                var instance = _factory.Instance(request);
                var result = await instance.UsersGetAsync(offsetValue, limitValue, request.HttpContext.RequestAborted);
                return _resultHandler.Json(result, 200);
            } catch(CaffoaClientError err) {
                return err.Result;
            } catch (Exception e) {
                if(_errorHandler.TryHandleFunctionException(e, out var errorHandlerResult, request, "UsersGet", "api/users", "get"))
                    return errorHandlerResult;
                throw;
            }
        }
        /// <summary>
        /// auto-generated function invocation.
        ///</summary>
        [FunctionName("UserPostAsync")]
        public async Task<IActionResult> UserPostAsync(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "api/users")]
            HttpRequest request)
        {
            try {
                var instance = _factory.Instance(request);
                var jsonToken = await _jsonParser.Parse<JToken>(request.Body);
                var discriminator = jsonToken["type"]?.ToString()?.ToLower();
                var task = discriminator switch
                {
                    "simple" => instance.UserPostAsync(_jsonParser.ToObject<L1User>(jsonToken), request.HttpContext.RequestAborted),
                    "guest" => instance.UserPostAsync(_jsonParser.ToObject<L1GuestUser>(jsonToken), request.HttpContext.RequestAborted),
                    _ => throw _errorHandler.WrongContent("type", discriminator, new [] { "simple", "guest" })
                };
                var result = await task;
                return _resultHandler.Json(result, 201);
            } catch(CaffoaClientError err) {
                return err.Result;
            } catch (Exception e) {
                if(_errorHandler.TryHandleFunctionException(e, out var errorHandlerResult, request, "UserPost", "api/users", "post"))
                    return errorHandlerResult;
                throw;
            }
        }
        /// <summary>
        /// auto-generated function invocation.
        ///</summary>
        [FunctionName("UserPutAsync")]
        public async Task<IActionResult> UserPutAsync(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = "api/users/{userId}")]
            HttpRequest request, string userId)
        {
            try {
                var instance = _factory.Instance(request);
                var jsonToken = await _jsonParser.Parse<JToken>(request.Body);
                var discriminator = jsonToken["type"]?.ToString()?.ToLower();
                var task = discriminator switch
                {
                    "simple" => instance.UserPutAsync(userId, _jsonParser.ToObject<L1User>(jsonToken), request.HttpContext.RequestAborted),
                    "guest" => instance.UserPutAsync(userId, _jsonParser.ToObject<L1GuestUser>(jsonToken), request.HttpContext.RequestAborted),
                    _ => throw _errorHandler.WrongContent("type", discriminator, new [] { "simple", "guest" })
                };
                var (result, code) = await task;
                return _resultHandler.Json(result, code);
            } catch(CaffoaClientError err) {
                return err.Result;
            } catch (Exception e) {
                if(_errorHandler.TryHandleFunctionException(e, out var errorHandlerResult, request, "UserPut", "api/users/{userId}", "put", ("userId", userId)))
                    return errorHandlerResult;
                throw;
            }
        }
        /// <summary>
        /// auto-generated function invocation.
        ///</summary>
        [FunctionName("UserPatchAsync")]
        public async Task<IActionResult> UserPatchAsync(
            [HttpTrigger(AuthorizationLevel.Function, "patch", Route = "api/users/{userId}")]
            HttpRequest request, string userId)
        {
            try {
                var instance = _factory.Instance(request);
                var result = await instance.UserPatchAsync(userId, await _jsonParser.Parse<JObject>(request.Body), request.HttpContext.RequestAborted);
                return _resultHandler.Json(result, 200);
            } catch(CaffoaClientError err) {
                return err.Result;
            } catch (Exception e) {
                if(_errorHandler.TryHandleFunctionException(e, out var errorHandlerResult, request, "UserPatch", "api/users/{userId}", "patch", ("userId", userId)))
                    return errorHandlerResult;
                throw;
            }
        }
        /// <summary>
        /// auto-generated function invocation.
        ///</summary>
        [FunctionName("UserGetAsync")]
        public async Task<IActionResult> UserGetAsync(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "api/users/{userId}")]
            HttpRequest request, string userId)
        {
            try {
                var instance = _factory.Instance(request);
                var result = await instance.UserGetAsync(userId, request.HttpContext.RequestAborted);
                return _resultHandler.Json(result, 200);
            } catch(CaffoaClientError err) {
                return err.Result;
            } catch (Exception e) {
                if(_errorHandler.TryHandleFunctionException(e, out var errorHandlerResult, request, "UserGet", "api/users/{userId}", "get", ("userId", userId)))
                    return errorHandlerResult;
                throw;
            }
        }
        /// <summary>
        /// auto-generated function invocation.
        ///</summary>
        [FunctionName("UploadImageAsync")]
        public async Task<IActionResult> UploadImageAsync(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "api/users/{userId}/uploadImage")]
            HttpRequest request, string userId)
        {
            try {
                var instance = _factory.Instance(request);
                await instance.UploadImageAsync(userId, request.Body, request.HttpContext.RequestAborted);
                return _resultHandler.StatusCode(201);
            } catch(CaffoaClientError err) {
                return err.Result;
            } catch (Exception e) {
                if(_errorHandler.TryHandleFunctionException(e, out var errorHandlerResult, request, "UploadImage", "api/users/{userId}/uploadImage", "post", ("userId", userId)))
                    return errorHandlerResult;
                throw;
            }
        }
        /// <summary>
        /// auto-generated function invocation.
        ///</summary>
        [FunctionName("UploadImage2Async")]
        public async Task<IActionResult> UploadImage2Async(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = "api/users/{userId}/uploadImage")]
            HttpRequest request, string userId)
        {
            try {
                var instance = _factory.Instance(request);
                await instance.UploadImage2Async(userId, request.Body, request.HttpContext.RequestAborted);
                return _resultHandler.StatusCode(201);
            } catch(CaffoaClientError err) {
                return err.Result;
            } catch (Exception e) {
                if(_errorHandler.TryHandleFunctionException(e, out var errorHandlerResult, request, "UploadImage2", "api/users/{userId}/uploadImage", "put", ("userId", userId)))
                    return errorHandlerResult;
                throw;
            }
        }
        /// <summary>
        /// auto-generated function invocation.
        ///</summary>
        [FunctionName("UsersGetByBirthdateAsync")]
        public async Task<IActionResult> UsersGetByBirthdateAsync(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "api/users/born-before/{date}")]
            HttpRequest request, string date)
        {
            try {
                var instance = _factory.Instance(request);
                var result = await instance.UsersGetByBirthdateAsync(_converter.ParseDateOnly(date, "date"), request.HttpContext.RequestAborted);
                return _resultHandler.Json(result, 200);
            } catch(CaffoaClientError err) {
                return err.Result;
            } catch (Exception e) {
                if(_errorHandler.TryHandleFunctionException(e, out var errorHandlerResult, request, "UsersGetByBirthdate", "api/users/born-before/{date}", "get", ("date", date)))
                    return errorHandlerResult;
                throw;
            }
        }
        /// <summary>
        /// auto-generated function invocation.
        ///</summary>
        [FunctionName("UsersSearchByDateAsync")]
        public async Task<IActionResult> UsersSearchByDateAsync(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "api/users/filter/byAge")]
            HttpRequest request)
        {
            try {
                DateOnly beforeValue;
                if(request.Query.TryGetValue("before", out var beforeQueryValue))
                    beforeValue = _converter.ParseDateOnly(beforeQueryValue, "before");
                else
                    throw _errorHandler.RequiredQueryParameterMissing("before");
                DateOnly afterValue;
                if(request.Query.TryGetValue("after", out var afterQueryValue))
                    afterValue = _converter.ParseDateOnly(afterQueryValue, "after");
                else
                    throw _errorHandler.RequiredQueryParameterMissing("after");
                int? maxResultsValue = null;
                if(request.Query.TryGetValue("maxResults", out var maxResultsQueryValue))
                    maxResultsValue = _converter.Parse<int>(maxResultsQueryValue, "maxResults");
                var instance = _factory.Instance(request);
                var result = await instance.UsersSearchByDateAsync(beforeValue, afterValue, maxResultsValue, request.HttpContext.RequestAborted);
                return _resultHandler.Json(result, 200);
            } catch(CaffoaClientError err) {
                return err.Result;
            } catch (Exception e) {
                if(_errorHandler.TryHandleFunctionException(e, out var errorHandlerResult, request, "UsersSearchByDate", "api/users/filter/byAge", "get"))
                    return errorHandlerResult;
                throw;
            }
        }
        /// <summary>
        /// auto-generated function invocation.
        ///</summary>
        [FunctionName("GetTagsAsync")]
        public async Task<IActionResult> GetTagsAsync(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "api/tags")]
            HttpRequest request)
        {
            try {
                var instance = _factory.Instance(request);
                var result = await instance.GetTagsAsync(request.HttpContext.RequestAborted);
                return _resultHandler.Json(result, 200);
            } catch(CaffoaClientError err) {
                return err.Result;
            } catch (Exception e) {
                if(_errorHandler.TryHandleFunctionException(e, out var errorHandlerResult, request, "GetTags", "api/tags", "get"))
                    return errorHandlerResult;
                throw;
            }
        }
        /// <summary>
        /// auto-generated function invocation.
        ///</summary>
        [FunctionName("GetUserTagsAsync")]
        public async Task<IActionResult> GetUserTagsAsync(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "api/tags/users")]
            HttpRequest request)
        {
            try {
                var instance = _factory.Instance(request);
                var result = await instance.GetUserTagsAsync(request.HttpContext.RequestAborted);
                return _resultHandler.Json(result, 200);
            } catch(CaffoaClientError err) {
                return err.Result;
            } catch (Exception e) {
                if(_errorHandler.TryHandleFunctionException(e, out var errorHandlerResult, request, "GetUserTags", "api/tags/users", "get"))
                    return errorHandlerResult;
                throw;
            }
        }
        /// <summary>
        /// auto-generated function invocation.
        ///</summary>
        [FunctionName("ListEnumsAsync")]
        public async Task<IActionResult> ListEnumsAsync(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "api/enums/list")]
            HttpRequest request)
        {
            try {
                string filterValue = null;
                if(request.Query.TryGetValue("filter", out var filterQueryValue))
                    filterValue = filterQueryValue;
                ICollection<string> includeValue = null;
                if(request.Query.TryGetValue("include[]", out var includeQueryValue))
                    includeValue = includeQueryValue.ToArray();
                ICollection<string> flagsValue = null;
                if(request.Query.TryGetValue("flags[]", out var flagsQueryValue))
                    flagsValue = flagsQueryValue.ToArray();
                ICollection<string> excludeValue = null;
                if(request.Query.TryGetValue("exclude", out var excludeQueryValue))
                    excludeValue = excludeQueryValue.ToArray();
                var instance = _factory.Instance(request);
                var result = await instance.ListEnumsAsync(filterValue, includeValue, flagsValue, excludeValue, request.HttpContext.RequestAborted);
                return _resultHandler.Json(result, 200);
            } catch(CaffoaClientError err) {
                return err.Result;
            } catch (Exception e) {
                if(_errorHandler.TryHandleFunctionException(e, out var errorHandlerResult, request, "ListEnums", "api/enums/list", "get"))
                    return errorHandlerResult;
                throw;
            }
        }
        /// <summary>
        /// auto-generated function invocation.
        ///</summary>
        [FunctionName("ListEnums2Async")]
        public async Task<IActionResult> ListEnums2Async(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "api/enums/list/filter/{filter}")]
            HttpRequest request, string filter)
        {
            try {
                var instance = _factory.Instance(request);
                var result = await instance.ListEnums2Async(filter, request.HttpContext.RequestAborted);
                return _resultHandler.Json(result, 200);
            } catch(CaffoaClientError err) {
                return err.Result;
            } catch (Exception e) {
                if(_errorHandler.TryHandleFunctionException(e, out var errorHandlerResult, request, "ListEnums2", "api/enums/list/filter/{filter}", "get", ("filter", filter)))
                    return errorHandlerResult;
                throw;
            }
        }
        /// <summary>
        /// auto-generated function invocation.
        ///</summary>
        [FunctionName("EchoOneOfAsync")]
        public async Task<IActionResult> EchoOneOfAsync(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "api/echo/oneOfTest")]
            HttpRequest request)
        {
            try {
                var instance = _factory.Instance(request);
                var result = await instance.EchoOneOfAsync(await _jsonParser.Parse<L1GroupedOneOf>(request.Body), request.HttpContext.RequestAborted);
                return _resultHandler.Json(result, 200);
            } catch(CaffoaClientError err) {
                return err.Result;
            } catch (Exception e) {
                if(_errorHandler.TryHandleFunctionException(e, out var errorHandlerResult, request, "EchoOneOf", "api/echo/oneOfTest", "get"))
                    return errorHandlerResult;
                throw;
            }
        }
        /// <summary>
        /// auto-generated function invocation.
        ///</summary>
        [FunctionName("EchoOneOfArrayAsync")]
        public async Task<IActionResult> EchoOneOfArrayAsync(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "api/echo/oneOfTestArray")]
            HttpRequest request)
        {
            try {
                var instance = _factory.Instance(request);
                var result = await instance.EchoOneOfArrayAsync(await _jsonParser.Parse<IEnumerable<L1AnyUser>>(request.Body), request.HttpContext.RequestAborted);
                return _resultHandler.Json(result, 200);
            } catch(CaffoaClientError err) {
                return err.Result;
            } catch (Exception e) {
                if(_errorHandler.TryHandleFunctionException(e, out var errorHandlerResult, request, "EchoOneOfArray", "api/echo/oneOfTestArray", "get"))
                    return errorHandlerResult;
                throw;
            }
        }
    }
}