using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyAwesomeBiz.Domain;

namespace MyAwesomeBiz.Data.Infrastructure
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(MyDbContext context) : base(context){}        
        public async Task<List<Order>> FindOrdersByUserName(string userName)
        {
            return await _dbContext.Orders
                                   .Include(o => o.Buyer)
                                   .Where(x => x.Buyer.UserName == userName)
                                   .ToListAsync();
        }

        public override async Task<Order>Save(Order order)
        {
            _dbContext.Entry(order.Buyer).State = EntityState.Unchanged;
            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();

           return order;
        }
    }
}