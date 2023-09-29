using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Caffoa.Extensions;
using DemoV2.Text.Json.Errors;
using DemoV2.Text.Json.Model;

#pragma warning disable CS0612

namespace DemoV2.Text.Json.Services
{
    public class DemoV2UserService : IDemoV2TextJsonUserService
    {
        private static readonly UserRepository<STJUserWithId> Users = new UserRepository<STJUserWithId>();
        private static readonly UserRepository<STJGuestUser> Guests = new UserRepository<STJGuestUser>();
        private static readonly Dictionary<string, List<Guid>> Tags = new();


        public async Task<IEnumerable<STJAnyCompleteUser>> UsersGetAsync(int offset = 0, int limit = 1000,
            CancellationToken cancellationToken = default)
        {
            var result = new List<STJAnyCompleteUser>();
            result.AddRange(await Users.List());
            result.AddRange(await Guests.List());
            return result.Skip(offset).Take(limit);
        }

        public Task UploadImageAsync(string userId, Stream stream, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<STJUser>> UsersGetByBirthdateAsync(DateOnly date,
            CancellationToken cancellationToken = default)
        {
            var users = await Users.List();
            return users.Where(u => u.Birthdate >= date).Select(u => u.ToSTJUser());
        }

        public async Task<IEnumerable<STJUser>> UsersSearchByDateAsync(DateOnly before, DateOnly after,
            int? maxResults = null, CancellationToken cancellationToken = default)
        {
            var users = await Users.List();
            var results = users.Where(u => u.Birthdate < before && u.Birthdate > after);
            if (maxResults is > 0)
                results = results.Take(maxResults.Value);
            return results.Select(u => u.ToSTJUser());
        }

        public async Task<STJTagInfos> GetTagsAsync(CancellationToken cancellationToken = default)
        {
            await Task.Yield();
            return new STJTagInfos()
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

        public Task<IEnumerable<STJMyEnumType>> ListEnumsAsync(STJMyEnumType? filter = null, ICollection<STJMyEnumType> include = null, ICollection<string> flags = null, ICollection<STJMyEnumType> exclude = null,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult<IEnumerable<STJMyEnumType>>(new List<STJMyEnumType>() { STJMyEnumType.Enum1 });
        }

        public Task<IEnumerable<STJMyEnumType>> ListEnums2Async(STJMyEnumType filter,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult<IEnumerable<STJMyEnumType>>(new List<STJMyEnumType>() { STJMyEnumType.Enum2 });
        }

        public Task<STJGroupedOneOf> EchoOneOfAsync(STJGroupedOneOf payload, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(payload);
        }

        public Task<IEnumerable<STJAnyUser>> EchoOneOfArrayAsync(IEnumerable<STJAnyUser> payload, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(payload);
        }

        public async Task<IEnumerable<STJAnyCompleteUser>> UserPostAsync(STJUser payload,
            CancellationToken cancellationToken = default)
        {
            var (user, _) = await UserPutAsync(Guid.NewGuid().ToString(), payload);
            return new[] { user };
        }

        public async Task<IEnumerable<STJAnyCompleteUser>> UserPostAsync(STJGuestUser payload,
            CancellationToken cancellationToken = default)
        {
            var (user, _) = await UserPutAsync(payload.Email, payload);
            return new[] { user };
        }

        public async Task<(STJAnyCompleteUser, int)> UserPutAsync(string userId, STJUser payload,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var user = await Users.GetById(userId);
                user.UpdateWithSTJUser(payload);
                await Users.Edit(user.Id, user);
                return (user, 200);
            }
            catch (UserNotFoundClientException)
            {
                var newUser = new STJUserWithId()
                {
                    Id = userId,
                    RegistrationDate = DateTime.Now,
                    Name = ""
                };
                newUser.UpdateWithSTJUser(payload);
                await Users.Add(newUser.Id, newUser);
                return (newUser, 201);
            }
        }

        public async Task<(STJAnyCompleteUser, int)> UserPutAsync(string userId, STJGuestUser payload,
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

        public async Task<STJUserWithId> UserPatchAsync(string userId, JsonElement payload,
            CancellationToken cancellationToken = default)
        {
            var user = await Users.GetById(userId);
//            user = user.MergedWith<STJUser, STJUserWithId>(payload);
            await Users.Edit(user.Id, user);
            return user;
        }

        public async Task<STJUserWithId> UserGetAsync(string userId, CancellationToken cancellationToken = default)
        {
            return await Users.GetById(userId);
        }

        public async ValueTask DisposeAsync()
        {
            await Task.Yield();
            GC.SuppressFinalize(this);
        }
        
        public Task<IEnumerable<STJAnyUser>> EchoOneOfAsync(IEnumerable<STJAnyUser> payload, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(payload);
        }
    }
}