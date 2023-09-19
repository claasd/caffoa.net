using System.Collections.Concurrent;
using DemoV2.AspNetNewtonSoft.Errors;
using DemoV2.AspNetNewtonSoft.Model;

namespace DemoV2.AspNetNewtonSoft.Services
{
    public class UserRepository<T> where T : ASPNAnyUser
    {
        private readonly ConcurrentDictionary<string, T> _fakeRepo = new ConcurrentDictionary<string, T>();

        public async Task<ICollection<T>> List()
        {
            await Task.Yield();
            return _fakeRepo.Values;
        }

        public async Task<T> GetById(string id)
        {
            await Task.Yield();
            if (_fakeRepo.TryGetValue(id, out var entity))
                return entity;
            throw new UserNotFoundClientException();
        }

        public async Task Add(string id, T entity)
        {
            await Task.Yield();
            _fakeRepo[id] = entity;
        }

        public async Task Delete(string id)
        {
            await Task.Yield();
            _fakeRepo.TryRemove(id, out _);
        }

        public async Task Edit(string id, T entity)
        {
            await Task.Yield();
            if (!_fakeRepo.TryGetValue(id, out _))
                throw new UserNotFoundClientException();

            _fakeRepo[id] = entity;
        }
    }
}