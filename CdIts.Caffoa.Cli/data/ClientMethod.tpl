
        /// <summary>
        /// {DOC}
        /// </summary>
        public async {RESULT} {NAME}Async({PARAMS}) {{
            var uriBuilder = new UriBuilder($"{{BaseUri}}{ROUTE}");{QUERYPARAMS}
            using var httpRequest = new HttpRequestMessage(HttpMethod.{METHOD}, uriBuilder.ToString());{PAYLOAD}
            PrepareRequest(httpRequest);
            using var httpResult = await Client.SendAsync(httpRequest, cancellationToken);
            ProcessResponse(httpResult);
            if(!httpResult.IsSuccessStatusCode) {{
                var errorData = await httpResult.Content.ReadAsStringAsync(cancellationToken);{ERRORHANDLING}
                throw new CaffoaWebClientException((int)httpResult.StatusCode, errorData);
            }}{RESULTCODE}
        }}