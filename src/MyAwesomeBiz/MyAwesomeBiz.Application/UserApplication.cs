using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyAwesomeBiz.Data.Infrastructure;
using MyAwesomeBiz.Domain;

namespace MyAwesomeBiz.Application
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserRepository _repo;

        public UserApplication(IUserRepository userRepo)
        {
            _repo = userRepo;
        }

        public async Task<User> GetUserByFullName(string fullName)
        {
            return !string.IsNullOrWhiteSpace(fullName) ? await _repo.GetUserByFullName(fullName)
                                                        : default;
        }

        public async Task<List<User>> ReadAll()
        {
            return await _repo.ReadAll();
        }

        public async Task<User> Save(User entity)
        {
            entity.CreationDate = DateTime.Now;
            return !string.IsNullOrWhiteSpace(entity.UserName) ?
                    await _repo.Save(entity) : default;
        }

        public async Task<User> Update(User entity)
        {
            return entity != default ? await _repo.Update(entity) 
                                     : default;
        }
    }
}