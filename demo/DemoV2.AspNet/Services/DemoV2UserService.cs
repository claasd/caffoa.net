using System.Text.Json;
using DemoV2.AspNet.Errors;
using DemoV2.AspNet.Model;

#pragma warning disable CS0612

namespace DemoV2.AspNet.Services
{
    public class DemoV2UserService : IDemoV2AspNetUserService
    {
        private static readonly UserRepository<ASPUserWithId> Users = new UserRepository<ASPUserWithId>();
        private static readonly UserRepository<ASPGuestUser> Guests = new UserRepository<ASPGuestUser>();
        private static readonly Dictionary<string, List<Guid>> Tags = new();


        public async Task<IEnumerable<ASPAnyCompleteUser>> UsersGetAsync(int offset = 0, int limit = 1000,
            CancellationToken cancellationToken = default)
        {
            var result = new List<ASPAnyCompleteUser>();
            result.AddRange(await Users.List());
            result.AddRange(await Guests.List());
            return result.Skip(offset).Take(limit);
        }

        public Task UploadImageAsync(string userId, Stream stream, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<ASPUser>> UsersGetByBirthdateAsync(DateOnly date,
            CancellationToken cancellationToken = default)
        {
            var users = await Users.List();
            return users.Where(u => u.Birthdate >= date).Select(u => u.ToASPUser());
        }

        public async Task<IEnumerable<ASPUser>> UsersSearchByDateAsync(DateOnly before, DateOnly after,
            int? maxResults = null, CancellationToken cancellationToken = default)
        {
            var users = await Users.List();
            var results = users.Where(u => u.Birthdate < before && u.Birthdate > after);
            if (maxResults is > 0)
                results = results.Take(maxResults.Value);
            return results.Select(u => u.ToASPUser());
        }

        public async Task<ASPTagInfos> GetTagsAsync(CancellationToken cancellationToken = default)
        {
            await Task.Yield();
            return new ASPTagInfos()
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

        public Task<IEnumerable<ASPMyEnumType>> ListEnumsAsync(ASPMyEnumType? filter = null, ICollection<ASPMyEnumType>? include = null, ICollection<string>? flags = null, ICollection<ASPMyEnumType>? exclude = null,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult<IEnumerable<ASPMyEnumType>>(new List<ASPMyEnumType>() { ASPMyEnumType.Enum1 });
        }

        public Task<IEnumerable<ASPMyEnumType>> ListEnums2Async(ASPMyEnumType filter,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult<IEnumerable<ASPMyEnumType>>(new List<ASPMyEnumType>() { ASPMyEnumType.Enum2 });
        }

        public Task<ASPGroupedOneOf> EchoOneOfAsync(ASPGroupedOneOf payload, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(payload);
        }

        public Task<IEnumerable<ASPAnyUser>> EchoOneOfArrayAsync(IEnumerable<ASPAnyUser> payload, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(payload);
        }

        public async Task<IEnumerable<ASPAnyCompleteUser>> UserPostAsync(ASPUser payload,
            CancellationToken cancellationToken = default)
        {
            var (user, _) = await UserPutAsync(Guid.NewGuid().ToString(), payload);
            return new[] { user };
        }

        public async Task<IEnumerable<ASPAnyCompleteUser>> UserPostAsync(ASPGuestUser payload,
            CancellationToken cancellationToken = default)
        {
            var (user, _) = await UserPutAsync(payload.Email, payload);
            return new[] { user };
        }

        public async Task<(ASPAnyCompleteUser, int)> UserPutAsync(string userId, ASPUser payload,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var user = await Users.GetById(userId);
                user.UpdateWithASPUser(payload);
                await Users.Edit(user.Id, user);
                return (user, 200);
            }
            catch (UserNotFoundClientException)
            {
                var newUser = new ASPUserWithId()
                {
                    Id = userId,
                    RegistrationDate = DateTime.Now,
                    Name = ""
                };
                newUser.UpdateWithASPUser(payload);
                await Users.Add(newUser.Id, newUser);
                return (newUser, 201);
            }
        }

        public async Task<(ASPAnyCompleteUser, int)> UserPutAsync(string userId, ASPGuestUser payload,
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

        public async Task<ASPUserWithId> UserPatchAsync(string userId, JsonElement payload,
            CancellationToken cancellationToken = default)
        {
            var user = await Users.GetById(userId);
//            user = user.MergedWith<ASPUser, ASPUserWithId>(payload);
            await Users.Edit(user.Id, user);
            return user;
        }

        public async Task<ASPUserWithId> UserGetAsync(string userId, CancellationToken cancellationToken = default)
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