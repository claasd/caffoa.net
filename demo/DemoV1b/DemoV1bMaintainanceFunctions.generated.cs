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
using DemoV1b.Model.Base;
using DemoV1b.Model;

namespace DemoV1b
{
    /// AUTO GENERATED CLASS
    public class DemoV1bMaintainanceFunctions
    {
        private readonly ILogger<DemoV1bMaintainanceFunctions> _logger;
        private readonly ICaffoaFactory<IDemoV1bMaintainanceService> _factory;
        private readonly ICaffoaErrorHandler _errorHandler;
        private readonly ICaffoaJsonParser _jsonParser;
        private readonly ICaffoaResultHandler _resultHandler;
        private readonly ICaffoaConverter _converter;
        public DemoV1bMaintainanceFunctions(ILogger<DemoV1bMaintainanceFunctions> logger, ICaffoaFactory<IDemoV1bMaintainanceService> factory, ICaffoaErrorHandler errorHandler = null, ICaffoaJsonParser jsonParser = null, ICaffoaResultHandler resultHandler = null, ICaffoaConverter converter = null) {
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
        [FunctionName("LongRunningFunctionAsync")]
        public async Task<IActionResult> LongRunningFunctionAsync(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "api/startLongRunningFunction/{id}")]
            HttpRequest request, string id, [DurableClient] IDurableOrchestrationClient durableClient)
        {
            try {
                var instance = _factory.Instance(request);
                var result = await instance.LongRunningFunctionAsync(durableClient, _converter.ParseGuid(id, "id"), request.HttpContext.RequestAborted);
                return _resultHandler.Json(result, 202);
            } catch(CaffoaClientError err) {
                return err.Result;
            } catch (Exception e) {
                if(_errorHandler.TryHandleFunctionException(e, out var errorHandlerResult, request, "LongRunningFunction", "api/startLongRunningFunction/{id}", "post", ("id", id)))
                    return errorHandlerResult;
                throw;
            }
        }
    }
}