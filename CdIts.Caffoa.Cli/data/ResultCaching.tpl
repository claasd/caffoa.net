var cachedResult = await _cachingHandler.GetCachedResult(caffoaResultParameter);
                if(cachedResult != null)
                    return cachedResult;
                