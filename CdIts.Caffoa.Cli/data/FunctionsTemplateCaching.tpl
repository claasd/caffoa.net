using Caffoa;
using Caffoa.Defaults;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private readonly ICaffoaCachingHandler _cachingHandler;
        {ADDITIONAL_VARIABLES}
        public {CLASSNAME}(ILogger<{CLASSNAME}> logger, ICaffoaFactory<{INTERFACE}> factory, ICaffoaErrorHandler errorHandler = null, ICaffoaJsonParser jsonParser = null, ICaffoaCachingHandler cachingHandler = null, ICaffoaResultHandler resultHandler = null{ADDITIONAL_INTERFACES}) {{
            _logger = logger;
            _factory = factory;
            _cachingHandler = cachingHandler ?? new DefaultCaffoaCachingHandler(resultHandler ?? new DefaultCaffoaResultHandler());
            _errorHandler = errorHandler ?? new DefaultCaffoaErrorHandler(_logger, _cachingHandler);
            _jsonParser = jsonParser ?? new DefaultCaffoaJsonParser(_errorHandler);
{ADDITIONAL_INITS}        }}
{METHODS}
    }}
}}