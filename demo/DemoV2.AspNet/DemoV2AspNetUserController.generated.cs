using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Caffoa;
using System.Text.Json;
using DemoV2.AspNet.Model.Base;
using DemoV2.AspNet.Model;

namespace DemoV2.AspNet;

/// AUTOGENERATED BY caffoa
/// <summary>
/// Controller to be implemented to serve the api
/// </summary>
[ApiController]
[Route("api")]
public class DemoV2AspNetUserController : ControllerBase
{
    private readonly ICaffoaFactory<IDemoV2AspNetUserService> _factory;
    
    public DemoV2AspNetUserController(ICaffoaFactory<IDemoV2AspNetUserService> factory)
    {
        _factory = factory;
    }
    public IDemoV2AspNetUserService GetService() => _factory.Instance(Request);

    /// <summary>
    /// get information about the users
    /// 200 -> return user object
    /// 400 -> Error
    ///</summary>
    [HttpGet("users")]
    public async Task<ActionResult<IEnumerable<ASPAnyCompleteUser>>> UsersGetAsync([FromQuery] int offset = 0, [FromQuery] int limit = 1000, CancellationToken cancellationToken = default) => StatusCode(200, await GetService().UsersGetAsync(offset, limit, cancellationToken));


    /// <summary>
    /// create or update a user without return test
    /// 201 -> User was created
    ///</summary>
    [HttpPost("users")]
    public async Task<ActionResult<IEnumerable<ASPAnyCompleteUser>>> UserPostAsync([FromBody] ASPUser payload, CancellationToken cancellationToken = default) => StatusCode(201, await GetService().UserPostAsync(payload, cancellationToken));


    /// <summary>
    /// create or update a user without return test
    /// 201 -> User was created
    ///</summary>
    [HttpPost("users")]
    public async Task<ActionResult<IEnumerable<ASPAnyCompleteUser>>> UserPostAsync([FromBody] ASPGuestUser payload, CancellationToken cancellationToken = default) => StatusCode(201, await GetService().UserPostAsync(payload, cancellationToken));


    /// <summary>
    /// create or update a user
    /// 200 -> User was updated
    /// 201 -> User was created
    ///</summary>
    [HttpPut("users/{userId}")]
    public async Task<ActionResult<ASPAnyCompleteUser>> UserPutAsync([FromRoute] string userId, [FromBody] ASPUser payload, CancellationToken cancellationToken = default) { var (res, code) = await GetService().UserPutAsync(userId, payload, cancellationToken); return StatusCode(code, res); }


    /// <summary>
    /// create or update a user
    /// 200 -> User was updated
    /// 201 -> User was created
    ///</summary>
    [HttpPut("users/{userId}")]
    public async Task<ActionResult<ASPAnyCompleteUser>> UserPutAsync([FromRoute] string userId, [FromBody] ASPGuestUser payload, CancellationToken cancellationToken = default) { var (res, code) = await GetService().UserPutAsync(userId, payload, cancellationToken); return StatusCode(code, res); }


    /// <summary>
    /// update a user
    /// 200 -> User was updated
    ///</summary>
    [HttpPatch("users/{userId}")]
    public async Task<ActionResult<ASPUserWithId>> UserPatchAsync([FromRoute] string userId, [FromBody] JsonElement payload, CancellationToken cancellationToken = default) => StatusCode(200, await GetService().UserPatchAsync(userId, payload, cancellationToken));


    /// <summary>
    /// get information about the users
    /// 200 -> return user object
    ///</summary>
    [HttpGet("users/{userId}")]
    public async Task<ActionResult<ASPUserWithId>> UserGetAsync([FromRoute] string userId, CancellationToken cancellationToken = default) => StatusCode(200, await GetService().UserGetAsync(userId, cancellationToken));


    /// <summary>
    /// 201 -> Image was created
    ///</summary>
    [HttpPost("users/{userId}/uploadImage")]
    public async Task<IActionResult> UploadImageAsync([FromRoute] string userId, [FromBody] Stream stream, CancellationToken cancellationToken = default) { await GetService().UploadImageAsync(userId, stream, cancellationToken); return StatusCode(201); }


    /// <summary>
    /// get
    /// 200 -> return user object
    /// 400 -> Error
    ///</summary>
    [HttpGet("users/born-before/{date}")]
    public async Task<ActionResult<IEnumerable<ASPUser>>> UsersGetByBirthdateAsync([FromRoute] DateOnly date, CancellationToken cancellationToken = default) => StatusCode(200, await GetService().UsersGetByBirthdateAsync(date, cancellationToken));


    /// <summary>
    /// get
    /// 200 -> return user object
    /// 400 -> Error
    ///</summary>
    [HttpGet("users/filter/byAge")]
    public async Task<ActionResult<IEnumerable<ASPUser>>> UsersSearchByDateAsync([FromQuery] DateOnly before, [FromQuery] DateOnly after, [FromQuery] int? maxResults = null, CancellationToken cancellationToken = default) => StatusCode(200, await GetService().UsersSearchByDateAsync(before, after, maxResults, cancellationToken));


    /// <summary>
    /// 200 -> list of elements that have the requested tag
    ///</summary>
    [HttpGet("tags")]
    public async Task<ActionResult<ASPTagInfos>> GetTagsAsync(CancellationToken cancellationToken = default) => StatusCode(200, await GetService().GetTagsAsync(cancellationToken));


    /// <summary>
    /// 200 -> tags for the user
    ///</summary>
    [HttpGet("tags/users")]
    public async Task<ActionResult<IEnumerable<KeyValuePair<string, IEnumerable<Guid>>>>> GetUserTagsAsync(CancellationToken cancellationToken = default) => StatusCode(200, await GetService().GetUserTagsAsync(cancellationToken));


    /// <summary>
    /// 200 -> a list of neum
    ///</summary>
    [HttpGet("enums/list")]
    public async Task<ActionResult<IEnumerable<ASPMyEnumType>>> ListEnumsAsync([FromQuery] ASPMyEnumType? filter = null, [FromQuery] ICollection<ASPMyEnumType> include = null, [FromQuery] ICollection<string> flags = null, [FromQuery] ICollection<ASPMyEnumType> exclude = null, CancellationToken cancellationToken = default) => StatusCode(200, await GetService().ListEnumsAsync(filter, include, flags, exclude, cancellationToken));


    /// <summary>
    /// 200 -> a list of neum
    ///</summary>
    [HttpGet("enums/list/filter/{filter}")]
    public async Task<ActionResult<IEnumerable<ASPMyEnumType>>> ListEnums2Async([FromRoute] ASPMyEnumType filter, CancellationToken cancellationToken = default) => StatusCode(200, await GetService().ListEnums2Async(filter, cancellationToken));


}