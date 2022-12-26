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

{IMPORTS}
namespace {NAMESPACE}
{{
    /// AUTO GENERATED CLASS
    public class {CLASSNAME}
    {{
        private readonly ILogger<{CLASSNAME}> _logger;
        private readonly ICaffoaFactory<{INTERFACE}> _factory;
        private readonly ICaffoaErrorHandler _errorHandler;
        private readonly ICaffoaJsonParser _jsonParser;
        private readonly ICaffoaResultHandler _resultHandler;
        {ADDITIONAL_VARIABLES}
        public {CLASSNAME}(ILogger<{CLASSNAME}> logger, ICaffoaFactory<{INTERFACE}> factory, ICaffoaErrorHandler errorHandler = null, ICaffoaJsonParser jsonParser = null, ICaffoaResultHandler resultHandler = null{ADDITIONAL_INTERFACES}) {{
            _logger = logger;
            _factory = factory;
            _resultHandler = resultHandler ?? new DefaultCaffoaResultHandler();
            _errorHandler = errorHandler ?? new DefaultCaffoaErrorHandler(_logger, _resultHandler);
            _jsonParser = jsonParser ?? new DefaultCaffoaJsonParser(_errorHandler);
{ADDITIONAL_INITS}        }}
{METHODS}
    }}
}}