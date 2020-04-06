using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MyAwesomeBiz.Data.Infrastructure
{
     public class MyDbContextFactory : IDesignTimeDbContextFactory<MyDbContext>
    {
        public MyDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
            optionsBuilder.UseSqlServer("Server=192.168.0.13;Database=myDataBase;User Id=appUser;password=0123456;Trusted_Connection=False;MultipleActiveResultSets=true;");

            return new MyDbContext(optionsBuilder.Options);
        }
    }
}