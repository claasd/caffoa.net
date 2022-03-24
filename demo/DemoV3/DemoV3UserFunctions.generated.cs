using Caffoa;
using Caffoa.Defaults;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json.Linq;
using DemoV3.Model.Base;
using DemoV3.Model;

namespace DemoV3
{
    /// AUTO GENERATED CLASS
    public class DemoV3UserFunctions
    {
        private readonly ILogger<DemoV3UserFunctions> _logger;
        private readonly ICaffoaFactory<IDemoV3UserService> _factory;
        private readonly ICaffoaErrorHandler _errorHandler;
        private readonly ICaffoaJsonParser _jsonParser;
        private readonly ICaffoaResultHandler _resultHandler;
        private readonly ICaffoaConverter _converter;
        public DemoV3UserFunctions(ILogger<DemoV3UserFunctions> logger, ICaffoaFactory<IDemoV3UserService> factory, ICaffoaErrorHandler errorHandler = null, ICaffoaJsonParser jsonParser = null, ICaffoaResultHandler resultHandler = null, ICaffoaConverter converter = null) {
            _logger = logger;
            _factory = factory;
            _errorHandler = errorHandler ?? new DefaultCaffoaErrorHandler(_logger);            
            _jsonParser = jsonParser ?? new DefaultCaffoaJsonParser(_errorHandler);
            _resultHandler = resultHandler ?? new DefaultCaffoaResultHandler();
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
                await using var instance = _factory.Instance(request);
                var result = await instance.UsersGetAsync(offsetValue, limitValue);
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
                await using var instance = _factory.Instance(request);
                var jObject = await _jsonParser.Parse<JObject>(request.Body);
                var discriminator = jObject["type"]?.ToString();
                var task = discriminator switch
                {
                    "simple" => instance.UserPostAsync(_jsonParser.ToObject<User>(jObject)),
                    "guest" => instance.UserPostAsync(_jsonParser.ToObject<GuestUser>(jObject)),
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
                await using var instance = _factory.Instance(request);
                var jObject = await _jsonParser.Parse<JObject>(request.Body);
                var discriminator = jObject["type"]?.ToString();
                var task = discriminator switch
                {
                    "simple" => instance.UserPutAsync(userId, _jsonParser.ToObject<User>(jObject)),
                    "guest" => instance.UserPutAsync(userId, _jsonParser.ToObject<GuestUser>(jObject)),
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
                await using var instance = _factory.Instance(request);
                var result = await instance.UserPatchAsync(userId, await _jsonParser.Parse<JObject>(request.Body));
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
                await using var instance = _factory.Instance(request);
                var result = await instance.UserGetAsync(userId);
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
                await using var instance = _factory.Instance(request);
                await instance.UploadImageAsync(userId, request.Body);
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
        [FunctionName("UsersGetByBirthdateAsync")]
        public async Task<IActionResult> UsersGetByBirthdateAsync(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "api/users/born-before/{date}")]
            HttpRequest request, string date)
        {
            try {
                await using var instance = _factory.Instance(request);
                var result = await instance.UsersGetByBirthdateAsync(_converter.ParseDateOnly(date, "date"));
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
                await using var instance = _factory.Instance(request);
                var result = await instance.UsersSearchByDateAsync(beforeValue, afterValue, maxResultsValue);
                return _resultHandler.Json(result, 200);
            } catch(CaffoaClientError err) {
                return err.Result;
            } catch (Exception e) {
                if(_errorHandler.TryHandleFunctionException(e, out var errorHandlerResult, request, "UsersSearchByDate", "api/users/filter/byAge", "get"))
                    return errorHandlerResult;
                throw;
            }
        }
    }
}