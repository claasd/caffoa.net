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
using Microsoft.Azure.Functions.Worker;
using Microsoft.DurableTask.Client;
using DemoIsolated.Model.Base;
using DemoIsolated.Model;

namespace DemoIsolated
{
    /// AUTO GENERATED CLASS
    public class DemoIsolatedMaintainanceFunctions
    {
        private readonly ILogger<DemoIsolatedMaintainanceFunctions> _logger;
        private readonly ICaffoaFactory<IDemoIsolatedMaintainanceService> _factory;
        private readonly ICaffoaErrorHandler _errorHandler;
        private readonly ICaffoaJsonParser _jsonParser;
        private readonly ICaffoaResultHandler _resultHandler;
        private readonly ICaffoaConverter _converter;
        public DemoIsolatedMaintainanceFunctions(ILogger<DemoIsolatedMaintainanceFunctions> logger, ICaffoaFactory<IDemoIsolatedMaintainanceService> factory, ICaffoaErrorHandler errorHandler = null, ICaffoaJsonParser jsonParser = null, ICaffoaResultHandler resultHandler = null, ICaffoaConverter converter = null) {
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
        [Function("LongRunningFunctionAsync")]
        public async Task<IActionResult> LongRunningFunctionAsync(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "api/startLongRunningFunction/{id}")]
            HttpRequest request, string id, [DurableClient] DurableTaskClient durableClient)
        {
            try {
                var instance = _factory.Instance(request);
                var result = await instance.LongRunningFunctionAsync(durableClient, _converter.ParseGuid(id, "id"), request.HttpContext.RequestAborted);
                return _resultHandler.Result(result, 202, new CaffoaResultHandlerParameter(request.Headers?.Accept ??  Array.Empty<string>()));
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