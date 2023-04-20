using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using DemoV2.Model.Base;
using DemoV2.Model;

namespace DemoV2
{
    /// AUTOGENERATED BY caffoa
    /// <summary>
    /// Interface for services to be implemented to serve the Function implementation
    /// </summary>
    public interface IDemoV2UserService : IAsyncDisposable
    {
        /// <summary>
        /// get information about the users
        /// 200 -> return user object
        /// 400 -> Error
        /// </summary>
        Task<IEnumerable<AnyCompleteUser>> UsersGetAsync(int offset = 0, int limit = 1000, CancellationToken cancellationToken = default);

        /// <summary>
        /// create or update a user without return test
        /// 201 -> User was created
        /// </summary>
        Task<IEnumerable<AnyCompleteUser>> UserPostAsync(User payload, CancellationToken cancellationToken = default);

        /// <summary>
        /// create or update a user without return test
        /// 201 -> User was created
        /// </summary>
        Task<IEnumerable<AnyCompleteUser>> UserPostAsync(GuestUser payload, CancellationToken cancellationToken = default);

        /// <summary>
        /// create or update a user
        /// 200 -> User was updated
        /// 201 -> User was created
        /// </summary>
        Task<(AnyCompleteUser, int)> UserPutAsync(string userId, User payload, CancellationToken cancellationToken = default);

        /// <summary>
        /// create or update a user
        /// 200 -> User was updated
        /// 201 -> User was created
        /// </summary>
        Task<(AnyCompleteUser, int)> UserPutAsync(string userId, GuestUser payload, CancellationToken cancellationToken = default);

        /// <summary>
        /// update a user
        /// 200 -> User was updated
        /// </summary>
        Task<UserWithId> UserPatchAsync(string userId, JObject payload, CancellationToken cancellationToken = default);

        /// <summary>
        /// get information about the users
        /// 200 -> return user object
        /// </summary>
        Task<UserWithId> UserGetAsync(string userId, CancellationToken cancellationToken = default);

        /// <summary>
        /// 201 -> Image was created
        /// </summary>
        Task UploadImageAsync(string userId, Stream stream, CancellationToken cancellationToken = default);

        /// <summary>
        /// get
        /// 200 -> return user object
        /// 400 -> Error
        /// </summary>
        Task<IEnumerable<User>> UsersGetByBirthdateAsync(DateOnly date, CancellationToken cancellationToken = default);

        /// <summary>
        /// get
        /// 200 -> return user object
        /// 400 -> Error
        /// </summary>
        Task<IEnumerable<User>> UsersSearchByDateAsync(DateOnly before, DateOnly after, int? maxResults = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// 200 -> list of elements that have the requested tag
        /// </summary>
        Task<TagInfos> GetTagsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// 200 -> tags for the user
        /// </summary>
        Task<IEnumerable<KeyValuePair<string, IEnumerable<Guid>>>> GetUserTagsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// 200 -> a list of neum
        /// </summary>
        Task<IEnumerable<MyEnumType>> ListEnumsAsync(MyEnumType? filter = null, ICollection<MyEnumType> include = null, ICollection<string> flags = null, ICollection<MyEnumType> exclude = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// 200 -> a list of neum
        /// </summary>
        Task<IEnumerable<MyEnumType>> ListEnums2Async(MyEnumType filter, CancellationToken cancellationToken = default);

    }
}
