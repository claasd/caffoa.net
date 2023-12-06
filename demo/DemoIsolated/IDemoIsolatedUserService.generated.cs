using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using DemoIsolated.Model.Base;
using DemoIsolated.Model;

namespace DemoIsolated
{
    /// AUTOGENERATED BY caffoa
    /// <summary>
    /// Interface for services to be implemented to serve the Function implementation
    /// </summary>
    public interface IDemoIsolatedUserService
    {
        /// <summary>
        /// get information about the users
        /// 200 -> return user object
        /// 400 -> Error
        /// </summary>
        Task<IEnumerable<IsoAnyCompleteUser>> UsersGetAsync(int offset = 0, int limit = 1000, CancellationToken cancellationToken = default);

        /// <summary>
        /// create or update a user without return test
        /// 201 -> User was created
        /// </summary>
        Task<IEnumerable<IsoAnyCompleteUser>> UserPostAsync(IsoUser payload, CancellationToken cancellationToken = default);

        /// <summary>
        /// create or update a user without return test
        /// 201 -> User was created
        /// </summary>
        Task<IEnumerable<IsoAnyCompleteUser>> UserPostAsync(IsoGuestUser payload, CancellationToken cancellationToken = default);

        /// <summary>
        /// create or update a user
        /// 200 -> User was updated
        /// 201 -> User was created
        /// </summary>
        Task<(IsoAnyCompleteUser, int)> UserPutAsync(string userId, IsoUser payload, CancellationToken cancellationToken = default);

        /// <summary>
        /// create or update a user
        /// 200 -> User was updated
        /// 201 -> User was created
        /// </summary>
        Task<(IsoAnyCompleteUser, int)> UserPutAsync(string userId, IsoGuestUser payload, CancellationToken cancellationToken = default);

        /// <summary>
        /// update a user
        /// 200 -> User was updated
        /// </summary>
        Task<IsoUserWithId> UserPatchAsync(string userId, JObject payload, CancellationToken cancellationToken = default);

        /// <summary>
        /// get information about the users
        /// 200 -> return user object
        /// </summary>
        Task<IsoUserWithId> UserGetAsync(string userId, CancellationToken cancellationToken = default);

        /// <summary>
        /// 201 -> Image was created
        /// </summary>
        Task UploadImageAsync(string userId, Stream stream, CancellationToken cancellationToken = default);

        /// <summary>
        /// get
        /// 200 -> return user object
        /// 400 -> Error
        /// </summary>
        Task<IEnumerable<IsoUser>> UsersGetByBirthdateAsync(DateOnly date, CancellationToken cancellationToken = default);

        /// <summary>
        /// get
        /// 200 -> return user object
        /// 400 -> Error
        /// </summary>
        Task<IEnumerable<IsoUser>> UsersSearchByDateAsync(DateOnly before, DateOnly after, int? maxResults = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// 200 -> list of elements that have the requested tag
        /// </summary>
        Task<IsoTagInfos> GetTagsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// 200 -> tags for the user
        /// </summary>
        Task<IEnumerable<KeyValuePair<string, IEnumerable<Guid>>>> GetUserTagsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// 200 -> a list of neum
        /// </summary>
        Task<IEnumerable<IsoMyEnumType>> ListEnumsAsync(IsoMyEnumType? filter = null, ICollection<IsoMyEnumType> include = null, ICollection<string> flags = null, ICollection<IsoMyEnumType> exclude = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// 200 -> a list of neum
        /// </summary>
        Task<IEnumerable<IsoMyEnumType>> ListEnums2Async(IsoMyEnumType filter, CancellationToken cancellationToken = default);

        /// <summary>
        /// 200 -> a list of neum
        /// </summary>
        Task<IsoGroupedOneOf> EchoOneOfAsync(IsoGroupedOneOf payload, CancellationToken cancellationToken = default);

        /// <summary>
        /// 200 -> a list of neum
        /// </summary>
        Task<IEnumerable<IsoAnyUser>> EchoOneOfArrayAsync(IEnumerable<IsoAnyUser> payload, CancellationToken cancellationToken = default);

    }
}