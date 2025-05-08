using DemoV2.AspNetNewtonSoft.Errors;
using DemoV2.AspNetNewtonSoft.Model;
using Newtonsoft.Json.Linq;

#pragma warning disable CS0612

namespace DemoV2.AspNetNewtonSoft.Services
{
    public class DemoV2UserService : IDemoV2AspNetNewtonSoftUserService
    {
        private static readonly UserRepository<ASPNUserWithId> Users = new UserRepository<ASPNUserWithId>();
        private static readonly UserRepository<ASPNGuestUser> Guests = new UserRepository<ASPNGuestUser>();
        private static readonly Dictionary<string, List<Guid>> Tags = new();


        public async Task<IEnumerable<ASPNAnyCompleteUser>> UsersGetAsync(int offset = 0, int limit = 1000,
            CancellationToken cancellationToken = default)
        {
            var result = new List<ASPNAnyCompleteUser>();
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

        public async Task<IEnumerable<ASPNUser>> UsersGetByBirthdateAsync(DateOnly date,
            CancellationToken cancellationToken = default)
        {
            var users = await Users.List();
            return users.Where(u => u.Birthdate >= date).Select(u => u.ToASPNUser());
        }

        public async Task<IEnumerable<ASPNUser>> UsersSearchByDateAsync(DateOnly before, DateOnly after,
            int? maxResults = null, CancellationToken cancellationToken = default)
        {
            var users = await Users.List();
            var results = users.Where(u => u.Birthdate < before && u.Birthdate > after);
            if (maxResults is > 0)
                results = results.Take(maxResults.Value);
            return results.Select(u => u.ToASPNUser());
        }

        public async Task<ASPNTagInfos> GetTagsAsync(CancellationToken cancellationToken = default)
        {
            await Task.Yield();
            return new ASPNTagInfos()
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

        public Task<IEnumerable<ASPNMyEnumType>> ListEnumsAsync(ASPNMyEnumType? filter = null, ICollection<ASPNMyEnumType>? include = null, ICollection<string>? flags = null, ICollection<ASPNMyEnumType>? exclude = null,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult<IEnumerable<ASPNMyEnumType>>(new List<ASPNMyEnumType>() { ASPNMyEnumType.Enum1 });
        }

        public Task<IEnumerable<ASPNMyEnumType>> ListEnums2Async(ASPNMyEnumType filter,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult<IEnumerable<ASPNMyEnumType>>(new List<ASPNMyEnumType>() { ASPNMyEnumType.Enum2 });
        }

        public Task<ASPNGroupedOneOf> EchoOneOfAsync(ASPNGroupedOneOf payload, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(payload);
        }

        public Task<IEnumerable<ASPNAnyUser>> EchoOneOfArrayAsync(IEnumerable<ASPNAnyUser> payload, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(payload);
        }

        public async Task<IEnumerable<ASPNAnyCompleteUser>> UserPostAsync(ASPNUser payload,
            CancellationToken cancellationToken = default)
        {
            var (user, _) = await UserPutAsync(Guid.NewGuid().ToString(), payload);
            return new[] { user };
        }

        public async Task<IEnumerable<ASPNAnyCompleteUser>> UserPostAsync(ASPNGuestUser payload,
            CancellationToken cancellationToken = default)
        {
            var (user, _) = await UserPutAsync(payload.Email, payload);
            return new[] { user };
        }

        public async Task<(ASPNAnyCompleteUser, int)> UserPutAsync(string userId, ASPNUser payload,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var user = await Users.GetById(userId);
                user.UpdateWithASPNUser(payload);
                await Users.Edit(user.Id, user);
                return (user, 200);
            }
            catch (UserNotFoundClientException)
            {
                var newUser = new ASPNUserWithId()
                {
                    Id = userId,
                    RegistrationDate = DateTime.Now,
                    Name = ""
                };
                newUser.UpdateWithASPNUser(payload);
                await Users.Add(newUser.Id, newUser);
                return (newUser, 201);
            }
        }

        public async Task<(ASPNAnyCompleteUser, int)> UserPutAsync(string userId, ASPNGuestUser payload,
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

        public async Task<ASPNUserWithId> UserPatchAsync(string userId, JToken payload,
            CancellationToken cancellationToken = default)
        {
            var user = await Users.GetById(userId);
//            user = user.MergedWith<ASPNUser, ASPNUserWithId>(payload);
            await Users.Edit(user.Id, user);
            return user;
        }

        public async Task<ASPNUserWithId> UserGetAsync(string userId, CancellationToken cancellationToken = default)
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