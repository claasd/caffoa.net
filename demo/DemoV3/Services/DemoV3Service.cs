using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caffoa;
using DemoV3.Errors;
using DemoV3.Model;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace DemoV3.Services
{
    
    public class DemoV3Service : IDemoV3Service, ICaffoaFactory<IDemoV3Service>
    {
        private readonly UserRepository<UserWithId> _users = new UserRepository<UserWithId>();
        private readonly UserRepository<GuestUser> _guests = new UserRepository<GuestUser>();
        private readonly IContractResolver _responseContractResolver = new RemoveRequiredContractResolver();
        public IDemoV3Service Instance(HttpRequest request)
        {
            return this;
        }

        public JsonSerializerSettings ResponseSerializerSettings
        {
            get
            {
                return new JsonSerializerSettings()
                {
                    ContractResolver = _responseContractResolver,
                    DateTimeZoneHandling = DateTimeZoneHandling.Utc
                };
            }
        }

        public async Task<IEnumerable<AnyCompleteUser>> UsersGetAsync(int offset = 0, int limit = 1000)
        {
            var result = new List<AnyCompleteUser>();
            result.AddRange(await _users.List());
            result.AddRange(await _guests.List());
            return result.Skip(offset).Take(limit);
        }

        public async Task<IEnumerable<User>> UsersGetByBirthdateAsync(DateOnly date)
        {
            var users = await _users.List();
            return users.Where(u => u.Birthdate >= date);
        }

        public async Task<IEnumerable<User>> UsersSearchByDateAsync(DateOnly before, DateOnly after, int? maxResults = null)
        {
            var users = await _users.List();
            var results = users.Where(u => u.Birthdate < before && u.Birthdate > after);
            if (maxResults is > 0)
                results = results.Take(maxResults.Value);
            return results;
        }

        public async Task<AnyCompleteUser> UserPostAsync(User payload)
        {
            var (user, _) = await UserPutAsync(Guid.NewGuid().ToString(), payload);
            return user;
        }

        public async Task<AnyCompleteUser> UserPostAsync(GuestUser payload)
        {
            var (user,_) = await UserPutAsync(payload.Email, payload);
            return user;
        }

        public async Task<(AnyCompleteUser, int)> UserPutAsync(string userId, User payload)
        {
            try
            {
                var user = await _users.GetById(userId);
                user.UpdateWithUser(payload);
                await _users.Edit(user.Id, user);
                return (user, 200);
            }
            catch (UserNotFoundClientError)
            {
                var newUser = new UserWithId()
                {
                    Id = userId,
                    RegistrationDate = DateTime.Now
                };
                newUser.UpdateWithUser(payload);
                await _users.Add(newUser.Id, newUser);
                return (newUser, 201);
            }
        }

        public async Task<(AnyCompleteUser, int)> UserPutAsync(string userId, GuestUser payload)
        {
            if (payload.Email != userId)
            {
                throw new GuestUserNotValidClientError();
            }
            try
            {
                await _guests.GetById(userId);
                await _guests.Edit(payload.Email, payload);
                return (payload, 200);
            }
            catch (UserNotFoundClientError)
            {
                await _guests.Add(payload.Email, payload);
                return (payload, 201);
            }

            
            
            
        }

        public async Task<UserWithId> UserPatchAsync(string userId, JObject payload)
        {
            var user = await _users.GetById(userId);
            user.MergeWithUser(payload);
            await _users.Edit(user.Id, user);
            return user;
        }

        public async Task<UserWithId> UserGetAsync(string userId)
        {
            return await _users.GetById(userId);
        }
    }
}