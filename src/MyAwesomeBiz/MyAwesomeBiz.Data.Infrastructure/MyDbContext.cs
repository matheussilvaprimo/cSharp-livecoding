using Microsoft.EntityFrameworkCore;
using MyAwesomeBiz.Domain;

namespace MyAwesomeBiz.Data.Infrastructure
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options){}

        public MyDbContext()
        {
        }

        public DbSet<User> Users {get;set;}
        public DbSet<Order> Orders {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Buyer);
            modelBuilder.Entity<User>()
                .HasMany(o => o.Orders);      
        }
    }
}
