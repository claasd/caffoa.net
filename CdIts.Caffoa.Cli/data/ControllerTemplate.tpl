using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Caffoa;
{IMPORTS}
namespace {NAMESPACE};

/// AUTOGENERATED BY caffoa
/// <summary>
/// Controller to be implemented to serve the api
/// </summary>
[ApiController]
[Route("{BASEPATH}")]
public class {CLASSNAME} : ControllerBase
{{
    private readonly ICaffoaFactory<{INTERFACE}> _factory;
    
    public {CLASSNAME}(ICaffoaFactory<{INTERFACE}> factory)
    {{
        _factory = factory;
    }}
    public {INTERFACE} GetService() => _factory.Instance(Request);

{METHODS}
}}