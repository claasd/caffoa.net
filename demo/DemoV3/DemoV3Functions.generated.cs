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

using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Newtonsoft.Json.Linq;
using DemoV3.Model;

namespace DemoV3
{
    /// AUTO GENERATED CLASS
    public class DemoV3Functions
    {
        private readonly ILogger<DemoV3Functions> _logger;
        private readonly ICaffoaFactory<IDemoV3Service> _factory;
        private readonly ICaffoaErrorHandler _errorHandler;
        private readonly ICaffoaJsonParser _jsonParser;
        private readonly ICaffoaResultHandler _resultHandler;
        private readonly ICaffoaConverter _converter;
        public DemoV3Functions(ILogger<DemoV3Functions> logger, ICaffoaFactory<IDemoV3Service> factory, ICaffoaErrorHandler errorHandler = null, ICaffoaJsonParser jsonParser = null, ICaffoaResultHandler resultHandler = null, ICaffoaConverter converter = null) {
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
                int offset = 0;
                if(request.Query.TryGetValue("offset", out var offsetQueryValue))
                    offset = _converter.Parse<int>(offsetQueryValue, nameof(offset));
                int limit = 1000;
                if(request.Query.TryGetValue("limit", out var limitQueryValue))
                    limit = _converter.Parse<int>(limitQueryValue, nameof(limit));
                var result = await _factory.Instance(request).UsersGetAsync(offset, limit);
                return _resultHandler.Json(result, 200);
            } catch(CaffoaClientError err) {
                return err.Result;
            } catch (Exception e) {
                return _errorHandler.HandleFunctionException(e, request, "UsersGet", "api/users", "get");
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
                var jObject = await _jsonParser.Parse<JObject>(request.Body);
                var discriminator = jObject["type"]?.ToString();
                var task = discriminator switch
                {
                    "simple" => _factory.Instance(request).UserPostAsync(_jsonParser.ToObject<User>(jObject)),
                    "guest" => _factory.Instance(request).UserPostAsync(_jsonParser.ToObject<GuestUser>(jObject)),
                    _ => throw _errorHandler.WrongContent("type", discriminator, new [] { "simple", "guest" })
                };
                var result = await task;
                return _resultHandler.Json(result, 201);
            } catch(CaffoaClientError err) {
                return err.Result;
            } catch (Exception e) {
                return _errorHandler.HandleFunctionException(e, request, "UserPost", "api/users", "post");
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
                var jObject = await _jsonParser.Parse<JObject>(request.Body);
                var discriminator = jObject["type"]?.ToString();
                var task = discriminator switch
                {
                    "simple" => _factory.Instance(request).UserPutAsync(userId, _jsonParser.ToObject<User>(jObject)),
                    "guest" => _factory.Instance(request).UserPutAsync(userId, _jsonParser.ToObject<GuestUser>(jObject)),
                    _ => throw _errorHandler.WrongContent("type", discriminator, new [] { "simple", "guest" })
                };
                var (result, code) = await task;
                return _resultHandler.Json(result, code);
            } catch(CaffoaClientError err) {
                return err.Result;
            } catch (Exception e) {
                return _errorHandler.HandleFunctionException(e, request, "UserPut", "api/users/{userId}", "put", ("userId", userId));
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
                var result = await _factory.Instance(request).UserPatchAsync(userId, await _jsonParser.Parse<JObject>(request.Body));
                return _resultHandler.Json(result, 200);
            } catch(CaffoaClientError err) {
                return err.Result;
            } catch (Exception e) {
                return _errorHandler.HandleFunctionException(e, request, "UserPatch", "api/users/{userId}", "patch", ("userId", userId));
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
                var result = await _factory.Instance(request).UserGetAsync(userId);
                return _resultHandler.Json(result, 200);
            } catch(CaffoaClientError err) {
                return err.Result;
            } catch (Exception e) {
                return _errorHandler.HandleFunctionException(e, request, "UserGet", "api/users/{userId}", "get", ("userId", userId));
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
                var result = await _factory.Instance(request).UsersGetByBirthdateAsync(_converter.ParseDateOnly(date, nameof(date)));
                return _resultHandler.Json(result, 200);
            } catch(CaffoaClientError err) {
                return err.Result;
            } catch (Exception e) {
                return _errorHandler.HandleFunctionException(e, request, "UsersGetByBirthdate", "api/users/born-before/{date}", "get", ("date", date));
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
                DateOnly before;
                if(request.Query.TryGetValue("before", out var beforeQueryValue))
                    before = _converter.ParseDateOnly(beforeQueryValue, nameof(before));
                else
                    throw _errorHandler.RequiredQueryParameterMissing("before");
                DateOnly after;
                if(request.Query.TryGetValue("after", out var afterQueryValue))
                    after = _converter.ParseDateOnly(afterQueryValue, nameof(after));
                else
                    throw _errorHandler.RequiredQueryParameterMissing("after");
                int? maxResults = null;
                if(request.Query.TryGetValue("maxResults", out var maxResultsQueryValue))
                    maxResults = _converter.Parse<int>(maxResultsQueryValue, nameof(maxResults));
                var result = await _factory.Instance(request).UsersSearchByDateAsync(before, after, maxResults);
                return _resultHandler.Json(result, 200);
            } catch(CaffoaClientError err) {
                return err.Result;
            } catch (Exception e) {
                return _errorHandler.HandleFunctionException(e, request, "UsersSearchByDate", "api/users/filter/byAge", "get");
            }
        }
        /// <summary>
        /// auto-generated function invocation.
        ///</summary>
        [FunctionName("LongRunningFunctionAsync")]
        public async Task<IActionResult> LongRunningFunctionAsync(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "api/startLongRunningFunction")]
            HttpRequest request,  [DurableClient] IDurableOrchestrationClient durableClient)
        {
            try {
                await _factory.Instance(request).LongRunningFunctionAsync(durableClient);
                return _resultHandler.StatusCode(202);
            } catch(CaffoaClientError err) {
                return err.Result;
            } catch (Exception e) {
                return _errorHandler.HandleFunctionException(e, request, "LongRunningFunction", "api/startLongRunningFunction", "post");
            }
        }
    }
}