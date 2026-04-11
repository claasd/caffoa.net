var caffoaResultParameter = new CaffoaResultHandlerParameter(
                    new int[] {{ {STATUS_CODES} }},
                    new string[] {{ {CONTENT_TYPES} }},
                    request.Headers?.Accept ??  Array.Empty<string>(),
                    request.Query,
                    HttpMethod.{OPERATION},
                    "{PATH}"
                );
                