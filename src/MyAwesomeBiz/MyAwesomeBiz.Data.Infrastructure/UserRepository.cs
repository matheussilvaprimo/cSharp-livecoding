using System.Threading.Tasks;
using System.Linq;
using MyAwesomeBiz.Domain;
using Microsoft.EntityFrameworkCore;

namespace MyAwesomeBiz.Data.Infrastructure
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(MyDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<User> GetUserByFullName(string fullName)
        {
            return await (from user in _dbContext.Users
                          where user.FullName == fullName
                          select user).FirstOrDefaultAsync();
        }
    }
}