var jsonToken = await _jsonParser.Parse<{GENERIC_TYPE}>(request.Body);
                var discriminator = {DISC_READ};
                {VARNAME}discriminator switch
                {{
                    {CASES}
                    _ => throw _errorHandler.WrongContent("{DISC}", discriminator, new [] {{ {CASES_ALLOWED_VALUES} }})
                }}{AWAIT}