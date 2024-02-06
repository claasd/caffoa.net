using Caffoa;
using Caffoa.Defaults;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Collections.Specialized;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using static System.FormattableString;
{IMPORTS}
#nullable enable

namespace {NAMESPACE}
{{
    /// AUTO GENERATED CLASS
    public partial class {CLASSNAME}
    {{
        private string _baseUri = null!;
        {FIELD_VISIBILITY} string BaseUri {{
            get => _baseUri;
            set => _baseUri = value.EndsWith("/") ? value : $"{{value}}/";
        }}
        {FIELD_VISIBILITY} HttpClient Client {{ get; }}
        {FIELD_VISIBILITY} ILogger Logger {{ get; }}
        {FIELD_VISIBILITY} ICaffoaParseErrorHandler ErrorHandler  {{ get; }}
        {FIELD_VISIBILITY} ICaffoaJsonParser JsonParser {{ get; }}
        {FIELD_VISIBILITY} ICaffoaJsonSerializer JsonSerializer {{ get; }}
        {CONSTRUCTOR_VISIBILITY} {CLASSNAME}(string baseUri, HttpClient? client = null, ILogger? logger = null, ICaffoaParseErrorHandler? errorHandler = null, ICaffoaJsonParser? jsonParser = null, ICaffoaJsonSerializer? jsonSerializer = null) {{
            BaseUri = baseUri;
            Client = client ?? new HttpClient();
            Logger = logger ?? NullLogger.Instance;
            JsonSerializer = jsonSerializer ?? new DefaultCaffoaResultHandler();
            ErrorHandler = errorHandler ?? new DefaultCaffoaErrorHandler(Logger, JsonSerializer);
            JsonParser = jsonParser ?? new DefaultCaffoaJsonParser(ErrorHandler);
        }}
        partial void PrepareRequest(HttpRequestMessage msg);
        partial void ProcessResponse(HttpResponseMessage msg);
{METHODS}
    }}
}}