var jToken = _jsonParser.Parse<JToken>(request.Body);
                var discriminator = jToken["{DISC}"]?.ToString();
                {VARNAME}discriminator switch
                {{
                    {CASES}
                    _ => throw _errorHandler.WrongContent("{DISC}", discriminator, new [] {{ {CASES_ALLOWED_VALUES} }})
                }}{AWAIT}