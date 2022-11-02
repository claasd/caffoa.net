var jObject = await _jsonParser.Parse<JObject>(request.Body);
                var discriminator = jObject["{DISC}"]?.ToString();
                {VARNAME}discriminator switch
                {{
                    {CASES}
                    _ => throw _errorHandler.WrongContent("{DISC}", discriminator, new [] {{ {CASES_ALLOWED_VALUES} }})
                }}{AWAIT}