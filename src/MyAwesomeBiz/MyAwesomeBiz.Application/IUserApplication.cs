using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyAwesomeBiz.Domain;

namespace MyAwesomeBiz.Application
{
    public interface IUserApplication
    {
        Task<User>Save(User entity);
        Task<User>Update(User entity);
        Task<List<User>>ReadAll();
        Task<User> GetUserByFullName(string fullName);
    }
}
