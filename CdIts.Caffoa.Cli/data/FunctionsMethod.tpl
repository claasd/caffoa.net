        /// <summary>
        /// auto-generated function invocation.
        ///</summary>
        [FunctionName("{PREFIX}{NAME}Async")]
        public async Task<IActionResult> {NAME}Async(
            [HttpTrigger(AuthorizationLevel.{AUTHORIZATION_LEVEL}, "{OPERATION}", Route = "{PATH}")]
            HttpRequest request{PARAM_NAMES})
        {{
            try {{
                {QUERY_VARIABLES}{INSTANTIATION}
                {CALL};
                return {RESULT};
            }} catch(CaffoaClientError err) {{
                return err.Result;
            }} catch (Exception e) {{
                if(_errorHandler.TryHandleFunctionException(e, out var errorHandlerResult, request, "{NAME}", "{PATH}", "{OPERATION}"{ADDITIONAL_ERROR_INFOS}))
                    return errorHandlerResult;
                throw;
            }}
        }}