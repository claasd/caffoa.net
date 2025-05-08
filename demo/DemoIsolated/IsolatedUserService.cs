using Caffoa;
using Caffoa.Extensions;
using DemoIsolated.Model;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;

#pragma warning disable CS0612

namespace DemoIsolated
{
    public class IsolatedUserService : ICaffoaFactory<IDemoIsolatedUserService>, IDemoIsolatedUserService
    {
        private static readonly UserRepository<IsoUserWithId> Users = new();
        private static readonly UserRepository<IsoGuestUser> Guests = new();
        private static readonly Dictionary<string, List<Guid>> Tags = new();

        public IDemoIsolatedUserService Instance(HttpRequest request) => this;

        public async Task<IEnumerable<IsoAnyCompleteUser>> UsersGetAsync(int offset = 0, int limit = 1000,
            CancellationToken cancellationToken = default)
        {
            var result = new List<IsoAnyCompleteUser>();
            result.AddRange(await Users.List());
            result.AddRange(await Guests.List());
            return result.Skip(offset).Take(limit);
        }

        public Task UploadImageAsync(string userId, Stream stream, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        public Task UploadImage2Async(string userId, Stream stream, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<IsoUser>> UsersGetByBirthdateAsync(DateOnly date,
            CancellationToken cancellationToken = default)
        {
            var users = await Users.List();
            return users.Where(u => u.Birthdate >= date).Select(u => u.ToIsoUser());
        }

        public async Task<IEnumerable<IsoUser>> UsersSearchByDateAsync(DateOnly before, DateOnly after,
            int? maxResults = null, CancellationToken cancellationToken = default)
        {
            var users = await Users.List();
            var results = users.Where(u => u.Birthdate < before && u.Birthdate > after);
            if (maxResults is > 0)
                results = results.Take(maxResults.Value);
            return results.Select(u => u.ToIsoUser());
        }

        public async Task<IsoTagInfos> GetTagsAsync(CancellationToken cancellationToken = default)
        {
            await Task.Yield();
            return new IsoTagInfos()
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

        public Task<IEnumerable<IsoMyEnumType>> ListEnumsAsync(IsoMyEnumType? filter = null, ICollection<IsoMyEnumType>? include = null, ICollection<string>? flags = null, ICollection<IsoMyEnumType>? exclude = null,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult<IEnumerable<IsoMyEnumType>>(new List<IsoMyEnumType>() { IsoMyEnumType.Enum1 });
        }

        public Task<IEnumerable<IsoMyEnumType>> ListEnums2Async(IsoMyEnumType filter,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult<IEnumerable<IsoMyEnumType>>(new List<IsoMyEnumType>() { IsoMyEnumType.Enum1 });
        }

        public Task<IsoGroupedOneOf> EchoOneOfAsync(IsoGroupedOneOf payload, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(payload);
        }

        public Task<IEnumerable<IsoAnyUser>> EchoOneOfArrayAsync(IEnumerable<IsoAnyUser> payload, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(payload);
        }

        public async Task<IEnumerable<IsoAnyCompleteUser>> UserPostAsync(IsoUser payload,
            CancellationToken cancellationToken = default)
        {
            var (IsoUser, _) = await UserPutAsync(Guid.NewGuid().ToString(), payload);
            return new[] { IsoUser };
        }

        public async Task<IEnumerable<IsoAnyCompleteUser>> UserPostAsync(IsoGuestUser payload,
            CancellationToken cancellationToken = default)
        {
            var (IsoUser, _) = await UserPutAsync(payload.Email, payload);
            return new[] { IsoUser };
        }

        public async Task<(IsoAnyCompleteUser, int)> UserPutAsync(string userId, IsoUser payload,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var IsoUser = await Users.GetById(userId);
                IsoUser.UpdateWithIsoUser(payload);
                await Users.Edit(IsoUser.Id, IsoUser);
                return (IsoUser, 200);
            }
            catch (UserNotFoundClientException)
            {
                var newUser = new IsoUserWithId()
                {
                    Id = userId,
                    RegistrationDate = DateTime.Now,
                    Name = ""
                };
                newUser.UpdateWithIsoUser(payload);
                await Users.Add(newUser.Id, newUser);
                return (newUser, 201);
            }
        }

        public async Task<(IsoAnyCompleteUser, int)> UserPutAsync(string userId, IsoGuestUser payload,
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

        public async Task<IsoUserWithId> UserPatchAsync(string userId, JObject payload,
            CancellationToken cancellationToken = default)
        {
            var IsoUser = await Users.GetById(userId);
            IsoUser = IsoUser.MergedWith<IsoUser, IsoUserWithId>(payload);
            await Users.Edit(IsoUser.Id, IsoUser);
            return IsoUser;
        }

        public async Task<IsoUserWithId> UserGetAsync(string userId, CancellationToken cancellationToken = default)
        {
            return await Users.GetById(userId);
        }
    }
}