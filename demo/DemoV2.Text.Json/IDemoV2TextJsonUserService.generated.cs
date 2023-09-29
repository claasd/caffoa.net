using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using DemoV2.Text.Json.Model.Base;
using DemoV2.Text.Json.Model;

namespace DemoV2.Text.Json
{
    /// AUTOGENERATED BY caffoa
    /// <summary>
    /// Interface for services to be implemented to serve the Function implementation
    /// </summary>
    public interface IDemoV2TextJsonUserService
    {
        /// <summary>
        /// get information about the users
        /// 200 -> return user object
        /// 400 -> Error
        /// </summary>
        Task<IEnumerable<STJAnyCompleteUser>> UsersGetAsync(int offset = 0, int limit = 1000, CancellationToken cancellationToken = default);

        /// <summary>
        /// create or update a user without return test
        /// 201 -> User was created
        /// </summary>
        Task<IEnumerable<STJAnyCompleteUser>> UserPostAsync(STJUser payload, CancellationToken cancellationToken = default);

        /// <summary>
        /// create or update a user without return test
        /// 201 -> User was created
        /// </summary>
        Task<IEnumerable<STJAnyCompleteUser>> UserPostAsync(STJGuestUser payload, CancellationToken cancellationToken = default);

        /// <summary>
        /// create or update a user
        /// 200 -> User was updated
        /// 201 -> User was created
        /// </summary>
        Task<(STJAnyCompleteUser, int)> UserPutAsync(string userId, STJUser payload, CancellationToken cancellationToken = default);

        /// <summary>
        /// create or update a user
        /// 200 -> User was updated
        /// 201 -> User was created
        /// </summary>
        Task<(STJAnyCompleteUser, int)> UserPutAsync(string userId, STJGuestUser payload, CancellationToken cancellationToken = default);

        /// <summary>
        /// update a user
        /// 200 -> User was updated
        /// </summary>
        Task<STJUserWithId> UserPatchAsync(string userId, JsonElement payload, CancellationToken cancellationToken = default);

        /// <summary>
        /// get information about the users
        /// 200 -> return user object
        /// </summary>
        Task<STJUserWithId> UserGetAsync(string userId, CancellationToken cancellationToken = default);

        /// <summary>
        /// 201 -> Image was created
        /// </summary>
        Task UploadImageAsync(string userId, Stream stream, CancellationToken cancellationToken = default);

        /// <summary>
        /// get
        /// 200 -> return user object
        /// 400 -> Error
        /// </summary>
        Task<IEnumerable<STJUser>> UsersGetByBirthdateAsync(DateOnly date, CancellationToken cancellationToken = default);

        /// <summary>
        /// get
        /// 200 -> return user object
        /// 400 -> Error
        /// </summary>
        Task<IEnumerable<STJUser>> UsersSearchByDateAsync(DateOnly before, DateOnly after, int? maxResults = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// 200 -> list of elements that have the requested tag
        /// </summary>
        Task<STJTagInfos> GetTagsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// 200 -> tags for the user
        /// </summary>
        Task<IEnumerable<KeyValuePair<string, IEnumerable<Guid>>>> GetUserTagsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// 200 -> a list of neum
        /// </summary>
        Task<IEnumerable<STJMyEnumType>> ListEnumsAsync(STJMyEnumType? filter = null, ICollection<STJMyEnumType> include = null, ICollection<string> flags = null, ICollection<STJMyEnumType> exclude = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// 200 -> a list of neum
        /// </summary>
        Task<IEnumerable<STJMyEnumType>> ListEnums2Async(STJMyEnumType filter, CancellationToken cancellationToken = default);

        /// <summary>
        /// 200 -> a list of neum
        /// </summary>
        Task<STJGroupedOneOf> EchoOneOfAsync(STJGroupedOneOf payload, CancellationToken cancellationToken = default);

        /// <summary>
        /// 200 -> a list of neum
        /// </summary>
        Task<IEnumerable<STJAnyUser>> EchoOneOfArrayAsync(IEnumerable<STJAnyUser> payload, CancellationToken cancellationToken = default);

    }
}
