using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Caffoa.Extensions;
using DemoV2.Errors;
using DemoV2.Model;
using Newtonsoft.Json.Linq;

#pragma warning disable CS0612

namespace DemoV2.Services
{
    public class DemoV2UserService : IDemoV2UserService
    {
        private static readonly UserRepository<UserWithId> Users = new UserRepository<UserWithId>();
        private static readonly UserRepository<GuestUser> Guests = new UserRepository<GuestUser>();
        private static readonly Dictionary<string, List<Guid>> Tags = new();


        public async Task<IEnumerable<AnyCompleteUser>> UsersGetAsync(int offset = 0, int limit = 1000,
            CancellationToken cancellationToken = default)
        {
            var result = new List<AnyCompleteUser>();
            result.AddRange(await Users.List());
            result.AddRange(await Guests.List());
            return result.Skip(offset).Take(limit);
        }

        public Task UploadImageAsync(string userId, Stream stream, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<User>> UsersGetByBirthdateAsync(DateOnly date,
            CancellationToken cancellationToken = default)
        {
            var users = await Users.List();
            return users.Where(u => u.Birthdate >= date).Select(u => u.ToUser());
        }

        public async Task<IEnumerable<User>> UsersSearchByDateAsync(DateOnly before, DateOnly after,
            int? maxResults = null, CancellationToken cancellationToken = default)
        {
            var users = await Users.List();
            var results = users.Where(u => u.Birthdate < before && u.Birthdate > after);
            if (maxResults is > 0)
                results = results.Take(maxResults.Value);
            return results.Select(u => u.ToUser());
        }

        public async Task<TagInfos> GetTagsAsync(CancellationToken cancellationToken = default)
        {
            await Task.Yield();
            return new TagInfos()
            {
                User = Tags
            };
        }

        public async Task<IEnumerable<KeyValuePair<string, IEnumerable<Guid>>>> GetUserTagsAsync(
            CancellationToken cancellationToken = default)
        {
            await Task.Yield();
            return Tags.ToDictionary(i => i.Key, i => i.Value.Select(v => v));
        }

        public Task<IEnumerable<MyEnumType>> ListEnumsAsync(MyEnumType? filter = null, ICollection<MyEnumType> include = null, ICollection<string> flags = null, ICollection<MyEnumType> exclude = null,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult<IEnumerable<MyEnumType>>(new List<MyEnumType>() { MyEnumType.Enum1 });
        }

        public Task<IEnumerable<MyEnumType>> ListEnums2Async(MyEnumType filter,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult<IEnumerable<MyEnumType>>(new List<MyEnumType>() { MyEnumType.Enum1 });
        }

        public Task<GroupedOneOf> EchoOneOfAsync(GroupedOneOf payload, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(payload);
        }

        public Task<IEnumerable<AnyUser>> EchoOneOfArrayAsync(IEnumerable<AnyUser> payload, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(payload);
        }

        public async Task<IEnumerable<AnyCompleteUser>> UserPostAsync(User payload,
            CancellationToken cancellationToken = default)
        {
            var (user, _) = await UserPutAsync(Guid.NewGuid().ToString(), payload);
            return new[] { user };
        }

        public async Task<IEnumerable<AnyCompleteUser>> UserPostAsync(GuestUser payload,
            CancellationToken cancellationToken = default)
        {
            var (user, _) = await UserPutAsync(payload.Email, payload);
            return new[] { user };
        }

        public async Task<(AnyCompleteUser, int)> UserPutAsync(string userId, User payload,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var user = await Users.GetById(userId);
                user = user.MergedWith(payload);
                await Users.Edit(user.Id, user);
                return (user, 200);
            }
            catch (UserNotFoundClientException)
            {
                var newUser = new UserWithId()
                {
                    Id = userId,
                    RegistrationDate = DateTime.Now,
                    Name = ""
                };
                newUser = newUser.MergedWith(payload);
                await Users.Add(newUser.Id, newUser);
                return (newUser, 201);
            }
        }

        public async Task<(AnyCompleteUser, int)> UserPutAsync(string userId, GuestUser payload,
            CancellationToken cancellationToken = default)
        {
            if (payload.Email != userId)
            {
                throw new GuestUserNotValidClientException();
            }

            try
            {
                await Guests.GetById(userId);
                await Guests.Edit(payload.Email, payload);
                return (payload, 200);
            }
            catch (UserNotFoundClientException)
            {
                await Guests.Add(payload.Email, payload);
                return (payload, 201);
            }
        }

        public async Task<UserWithId> UserPatchAsync(string userId, JObject payload,
            CancellationToken cancellationToken = default)
        {
            var user = await Users.GetById(userId);
            user = user.MergedWith<User, UserWithId>(payload);
            await Users.Edit(user.Id, user);
            return user;
        }

        public async Task<UserWithId> UserGetAsync(string userId, CancellationToken cancellationToken = default)
        {
            return await Users.GetById(userId);
        }

        public async ValueTask DisposeAsync()
        {
            await Task.Yield();
            GC.SuppressFinalize(this);
        }
    }
}