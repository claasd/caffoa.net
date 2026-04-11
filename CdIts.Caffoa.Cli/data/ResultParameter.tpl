var caffoaResultParameter = new CaffoaResultHandlerParameter(
                    new int[] {{ {STATUS_CODES} }},
                    new string[] {{ {CONTENT_TYPES} }},
                    request,
                    HttpMethod.{OPERATION},
                    "{PATH}",
                    new Dictionary<string, object>(){PATH_PARAMS}{BODY}
                );
                