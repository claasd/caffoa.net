        /// <summary>
        /// auto-generated function invocation.
        ///</summary>
        [FunctionName("{NAME}Async")]
        public async Task<IActionResult> {NAME}Async(
            [HttpTrigger(AuthorizationLevel.Function, "{OPERATION}", Route = "{PATH}")]
            HttpRequest request{PARAM_NAMES})
        {{
            try {{
                {CALL};
                return {RESULT};
            }} catch(CaffoaClientError err) {{
                return err.Result;
            }} catch (Exception e) {{
                return _errorHandler.HandleFunctionException(e, request, "{NAME}", "{PATH}", "{OPERATION}"{ADDITIONAL_ERROR_INFOS});
            }}
        }}