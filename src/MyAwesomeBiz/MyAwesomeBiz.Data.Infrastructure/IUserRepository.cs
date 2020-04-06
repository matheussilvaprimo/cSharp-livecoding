using System.Threading.Tasks;
using MyAwesomeBiz.Domain;

namespace MyAwesomeBiz.Data.Infrastructure
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserByFullName(string fullName);
    }
}