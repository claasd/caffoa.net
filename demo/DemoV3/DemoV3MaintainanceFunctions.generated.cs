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
using DemoV3.Model.Base;
using DemoV3.Model;

namespace DemoV3
{
    /// AUTO GENERATED CLASS
    public class DemoV3MaintainanceFunctions
    {
        private readonly ILogger<DemoV3MaintainanceFunctions> _logger;
        private readonly ICaffoaFactory<IDemoV3MaintainanceService> _factory;
        private readonly ICaffoaErrorHandler _errorHandler;
        private readonly ICaffoaJsonParser _jsonParser;
        private readonly ICaffoaResultHandler _resultHandler;
        private readonly ICaffoaConverter _converter;
        public DemoV3MaintainanceFunctions(ILogger<DemoV3MaintainanceFunctions> logger, ICaffoaFactory<IDemoV3MaintainanceService> factory, ICaffoaErrorHandler errorHandler = null, ICaffoaJsonParser jsonParser = null, ICaffoaResultHandler resultHandler = null, ICaffoaConverter converter = null) {
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
        [FunctionName("LongRunningFunctionAsync")]
        public async Task<IActionResult> LongRunningFunctionAsync(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "api/startLongRunningFunction")]
            HttpRequest request, [DurableClient] IDurableOrchestrationClient durableClient)
        {
            try {
                await _factory.Instance(request).LongRunningFunctionAsync(durableClient);
                return _resultHandler.StatusCode(202);
            } catch(CaffoaClientError err) {
                return err.Result;
            } catch (Exception e) {
                if(_errorHandler.TryHandleFunctionException(e, out var errorHandlerResult, request, "LongRunningFunction", "api/startLongRunningFunction", "post"))
                    return errorHandlerResult;
                throw;
            }
        }
    }
}