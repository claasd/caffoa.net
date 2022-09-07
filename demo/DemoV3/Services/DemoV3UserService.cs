using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Caffoa.Extensions;
using DemoV3.Errors;
using DemoV3.Model;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Newtonsoft.Json.Linq;

#pragma warning disable CS0612

namespace DemoV3.Services
{
    
    public class DemoV3UserService : IDemoV3UserService
    {
        private static readonly UserRepository<UserWithId> Users = new UserRepository<UserWithId>();
        private static readonly UserRepository<GuestUser> Guests = new UserRepository<GuestUser>();
        

        public async Task<IEnumerable<AnyCompleteUser>> UsersGetAsync(int offset = 0, int limit = 1000)
        {
            var result = new List<AnyCompleteUser>();
            result.AddRange(await Users.List());
            result.AddRange(await Guests.List());
            return result.Skip(offset).Take(limit);
        }

        public Task UploadImageAsync(string userId, Stream stream)
        {
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<User>> UsersGetByBirthdateAsync(DateTime date)
        {
            var users = await Users.List();
            return users.Where(u => u.Birthdate >= date).Select(u=>u.ToUser());
        }

        public async Task<IEnumerable<User>> UsersSearchByDateAsync(DateTime before, DateTime after, int? maxResults = null)
        {
            var users = await Users.List();
            var results = users.Where(u => u.Birthdate < before && u.Birthdate > after);
            if (maxResults is > 0)
                results = results.Take(maxResults.Value);
            return results.Select(u=>u.ToUser());
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
                    Name=""
                };
                newUser = newUser.MergedWith(payload);
                await Users.Add(newUser.Id, newUser);
                return (newUser, 201);
            }
        }

        public async Task<(AnyCompleteUser, int)> UserPutAsync(string userId, GuestUser payload)
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

        public async Task<UserWithId> UserPatchAsync(string userId, JObject payload)
        {
            var user = await Users.GetById(userId);
            user = user.MergedWith<User, UserWithId>(payload);
            await Users.Edit(user.Id, user);
            return user;
        }

        public async Task<UserWithId> UserGetAsync(string userId)
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