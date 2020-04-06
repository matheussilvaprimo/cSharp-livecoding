using System.Collections.Generic;
using System.Threading.Tasks;
using MyAwesomeBiz.Domain;

namespace MyAwesomeBiz.Application
{
    public interface IOrderApplication
    {
        Task<List<Order>>FindOrdersByUserName(string userName);
        Task<Order>Save(Order entity);
        Task<Order>Update(Order entity);
        Task<List<Order>>ReadAll();
    }
}