using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Caffoa;
using Newtonsoft.Json.Linq;
using DemoV2.AspNetNewtonSoft.Model.Base;
using DemoV2.AspNetNewtonSoft.Model;

namespace DemoV2.AspNetNewtonSoft;

/// AUTOGENERATED BY caffoa
/// <summary>
/// Controller to be implemented to serve the api
/// </summary>
[ApiController]
[Route("api")]
public class DemoV2AspNetNewtonSoftUserController : ControllerBase
{
    private readonly ICaffoaFactory<IDemoV2AspNetNewtonSoftUserService> _factory;
    
    public DemoV2AspNetNewtonSoftUserController(ICaffoaFactory<IDemoV2AspNetNewtonSoftUserService> factory)
    {
        _factory = factory;
    }
    public IDemoV2AspNetNewtonSoftUserService GetService() => _factory.Instance(Request);

    /// <summary>
    /// get information about the users
    /// 200 -> return user object
    /// 400 -> Error
    ///</summary>
    [HttpGet("users")]
    public async Task<ActionResult<IEnumerable<ASPNAnyCompleteUser>>> UsersGetAsync([FromQuery] int offset = 0, [FromQuery] int limit = 1000, CancellationToken cancellationToken = default) { return StatusCode(200, await GetService().UsersGetAsync(offset, limit, cancellationToken)); }


    /// <summary>
    /// create or update a user without return test
    /// 201 -> User was created
    ///</summary>
    [HttpPost("users")]
    public async Task<ActionResult<IEnumerable<ASPNAnyCompleteUser>>> UserPostAsync(JToken payload, CancellationToken cancellationToken = default) {         switch (payload.Value<string>("type"))
        {
        case "simple": { return StatusCode(201, await GetService().UserPostAsync(payload.ToObject<ASPNUser>(), cancellationToken)); }
        case "guest": { return StatusCode(201, await GetService().UserPostAsync(payload.ToObject<ASPNGuestUser>(), cancellationToken)); }
        default: return BadRequest("Discriminator not found");
        }
 }


    /// <summary>
    /// create or update a user
    /// 200 -> User was updated
    /// 201 -> User was created
    ///</summary>
    [HttpPut("users/{userId}")]
    public async Task<ActionResult<ASPNAnyCompleteUser>> UserPutAsync([FromRoute] string userId, JToken payload, CancellationToken cancellationToken = default) {         switch (payload.Value<string>("type"))
        {
        case "simple": { var (res, code) = await GetService().UserPutAsync(userId, payload.ToObject<ASPNUser>(), cancellationToken); return StatusCode(code, res); }
        case "guest": { var (res, code) = await GetService().UserPutAsync(userId, payload.ToObject<ASPNGuestUser>(), cancellationToken); return StatusCode(code, res); }
        default: return BadRequest("Discriminator not found");
        }
 }


    /// <summary>
    /// Use UserPut instead
    /// 200 -> User was updated
    ///</summary>
    [HttpPatch("users/{userId}")]
    public async Task<ActionResult<ASPNUserWithId>> UserPatchAsync([FromRoute] string userId, [FromBody] JToken payload, CancellationToken cancellationToken = default) { return StatusCode(200, await GetService().UserPatchAsync(userId, payload, cancellationToken)); }


    /// <summary>
    /// get information about the users
    /// 200 -> return user object
    ///</summary>
    [HttpGet("users/{userId}")]
    public async Task<ActionResult<ASPNUserWithId>> UserGetAsync([FromRoute] string userId, CancellationToken cancellationToken = default) { return StatusCode(200, await GetService().UserGetAsync(userId, cancellationToken)); }


    /// <summary>
    /// 201 -> Image was created
    ///</summary>
    [HttpPost("users/{userId}/uploadImage")]
    public async Task<IActionResult> UploadImageAsync([FromRoute] string userId, [FromBody] Stream stream, CancellationToken cancellationToken = default) { await GetService().UploadImageAsync(userId, stream, cancellationToken); return StatusCode(201); }


    /// <summary>
    /// 201 -> Image was created
    ///</summary>
    [HttpPut("users/{userId}/uploadImage")]
    public async Task<IActionResult> UploadImage2Async([FromRoute] string userId, [FromBody] Stream stream, CancellationToken cancellationToken = default) { await GetService().UploadImage2Async(userId, stream, cancellationToken); return StatusCode(201); }


    /// <summary>
    /// get
    /// 200 -> return user object
    /// 400 -> Error
    ///</summary>
    [HttpGet("users/born-before/{date}")]
    public async Task<ActionResult<IEnumerable<ASPNUser>>> UsersGetByBirthdateAsync([FromRoute] DateOnly date, CancellationToken cancellationToken = default) { return StatusCode(200, await GetService().UsersGetByBirthdateAsync(date, cancellationToken)); }


    /// <summary>
    /// get
    /// 200 -> return user object
    /// 400 -> Error
    ///</summary>
    [HttpGet("users/filter/byAge")]
    public async Task<ActionResult<IEnumerable<ASPNUser>>> UsersSearchByDateAsync([FromQuery] DateOnly before, [FromQuery] DateOnly after, [FromQuery] int? maxResults = null, CancellationToken cancellationToken = default) { return StatusCode(200, await GetService().UsersSearchByDateAsync(before, after, maxResults, cancellationToken)); }


    /// <summary>
    /// 200 -> list of elements that have the requested tag
    ///</summary>
    [HttpGet("tags")]
    public async Task<ActionResult<ASPNTagInfos>> GetTagsAsync(CancellationToken cancellationToken = default) { return StatusCode(200, await GetService().GetTagsAsync(cancellationToken)); }


    /// <summary>
    /// 200 -> tags for the user
    ///</summary>
    [HttpGet("tags/users")]
    public async Task<ActionResult<IEnumerable<KeyValuePair<string, IEnumerable<Guid>>>>> GetUserTagsAsync(CancellationToken cancellationToken = default) { return StatusCode(200, await GetService().GetUserTagsAsync(cancellationToken)); }


    /// <summary>
    /// 200 -> a list of neum
    ///</summary>
    [HttpGet("enums/list")]
    public async Task<ActionResult<IEnumerable<ASPNMyEnumType>>> ListEnumsAsync([FromQuery] ASPNMyEnumType? filter = null, [FromQuery] ICollection<ASPNMyEnumType> include = null, [FromQuery] ICollection<string> flags = null, [FromQuery] ICollection<ASPNMyEnumType> exclude = null, CancellationToken cancellationToken = default) { return StatusCode(200, await GetService().ListEnumsAsync(filter, include, flags, exclude, cancellationToken)); }


    /// <summary>
    /// 200 -> a list of neum
    ///</summary>
    [HttpGet("enums/list/filter/{filter}")]
    public async Task<ActionResult<IEnumerable<ASPNMyEnumType>>> ListEnums2Async([FromRoute] ASPNMyEnumType filter, CancellationToken cancellationToken = default) { return StatusCode(200, await GetService().ListEnums2Async(filter, cancellationToken)); }


    /// <summary>
    /// 200 -> a list of neum
    ///</summary>
    [HttpGet("echo/oneOfTest")]
    public async Task<ActionResult<ASPNGroupedOneOf>> EchoOneOfAsync([FromBody] ASPNGroupedOneOf payload, CancellationToken cancellationToken = default) { return StatusCode(200, await GetService().EchoOneOfAsync(payload, cancellationToken)); }


    /// <summary>
    /// 200 -> a list of neum
    ///</summary>
    [HttpGet("echo/oneOfTestArray")]
    public async Task<ActionResult<IEnumerable<ASPNAnyUser>>> EchoOneOfArrayAsync([FromBody] IEnumerable<ASPNAnyUser> payload, CancellationToken cancellationToken = default) { return StatusCode(200, await GetService().EchoOneOfArrayAsync(payload, cancellationToken)); }


}