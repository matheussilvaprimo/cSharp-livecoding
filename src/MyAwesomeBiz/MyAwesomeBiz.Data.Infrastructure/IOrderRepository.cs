using System.Collections.Generic;
using System.Threading.Tasks;
using MyAwesomeBiz.Domain;

namespace MyAwesomeBiz.Data.Infrastructure
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<List<Order>>FindOrdersByUserName(string userName);
    }
}