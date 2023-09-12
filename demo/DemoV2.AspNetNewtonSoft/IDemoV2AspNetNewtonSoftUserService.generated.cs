using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using DemoV2.AspNetNewtonSoft.Model.Base;
using DemoV2.AspNetNewtonSoft.Model;

namespace DemoV2.AspNetNewtonSoft
{
    /// AUTOGENERATED BY caffoa
    /// <summary>
    /// Interface for services to be implemented to serve the Function implementation
    /// </summary>
    public interface IDemoV2AspNetNewtonSoftUserService
    {
        /// <summary>
        /// get information about the users
        /// 200 -> return user object
        /// 400 -> Error
        /// </summary>
        Task<IEnumerable<ASPNAnyCompleteUser>> UsersGetAsync(int offset = 0, int limit = 1000, CancellationToken cancellationToken = default);

        /// <summary>
        /// create or update a user without return test
        /// 201 -> User was created
        /// </summary>
        Task<IEnumerable<ASPNAnyCompleteUser>> UserPostAsync(ASPNUser payload, CancellationToken cancellationToken = default);

        /// <summary>
        /// create or update a user without return test
        /// 201 -> User was created
        /// </summary>
        Task<IEnumerable<ASPNAnyCompleteUser>> UserPostAsync(ASPNGuestUser payload, CancellationToken cancellationToken = default);

        /// <summary>
        /// create or update a user
        /// 200 -> User was updated
        /// 201 -> User was created
        /// </summary>
        Task<(ASPNAnyCompleteUser, int)> UserPutAsync(string userId, ASPNUser payload, CancellationToken cancellationToken = default);

        /// <summary>
        /// create or update a user
        /// 200 -> User was updated
        /// 201 -> User was created
        /// </summary>
        Task<(ASPNAnyCompleteUser, int)> UserPutAsync(string userId, ASPNGuestUser payload, CancellationToken cancellationToken = default);

        /// <summary>
        /// update a user
        /// 200 -> User was updated
        /// </summary>
        Task<ASPNUserWithId> UserPatchAsync(string userId, JToken payload, CancellationToken cancellationToken = default);

        /// <summary>
        /// get information about the users
        /// 200 -> return user object
        /// </summary>
        Task<ASPNUserWithId> UserGetAsync(string userId, CancellationToken cancellationToken = default);

        /// <summary>
        /// 201 -> Image was created
        /// </summary>
        Task UploadImageAsync(string userId, Stream stream, CancellationToken cancellationToken = default);

        /// <summary>
        /// get
        /// 200 -> return user object
        /// 400 -> Error
        /// </summary>
        Task<IEnumerable<ASPNUser>> UsersGetByBirthdateAsync(DateOnly date, CancellationToken cancellationToken = default);

        /// <summary>
        /// get
        /// 200 -> return user object
        /// 400 -> Error
        /// </summary>
        Task<IEnumerable<ASPNUser>> UsersSearchByDateAsync(DateOnly before, DateOnly after, int? maxResults = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// 200 -> list of elements that have the requested tag
        /// </summary>
        Task<ASPNTagInfos> GetTagsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// 200 -> tags for the user
        /// </summary>
        Task<IEnumerable<KeyValuePair<string, IEnumerable<Guid>>>> GetUserTagsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// 200 -> a list of neum
        /// </summary>
        Task<IEnumerable<ASPNMyEnumType>> ListEnumsAsync(ASPNMyEnumType? filter = null, ICollection<ASPNMyEnumType> include = null, ICollection<string> flags = null, ICollection<ASPNMyEnumType> exclude = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// 200 -> a list of neum
        /// </summary>
        Task<IEnumerable<ASPNMyEnumType>> ListEnums2Async(ASPNMyEnumType filter, CancellationToken cancellationToken = default);

    }
}