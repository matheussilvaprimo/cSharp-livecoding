using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyAwesomeBiz.Data.Infrastructure;
using MyAwesomeBiz.Domain;

namespace MyAwesomeBiz.Application
{
    public class OrderApplication : IOrderApplication
    {
        private readonly IOrderRepository _repo;

        public OrderApplication(IOrderRepository orderRepo)
        {
            _repo = orderRepo;
        }
        public async Task<List<Order>> FindOrdersByUserName(string userName)
        {
            return !string.IsNullOrWhiteSpace(userName) ? 
                    await _repo.FindOrdersByUserName(userName) :
                    default;
        }

        public async Task<List<Order>> ReadAll()
        {
            return await _repo.ReadAll();
        }

        public async Task<Order> Save(Order entity)
        {
            entity.PurchaseDate = DateTime.Now;
            return entity.Buyer != default ? await _repo.Save(entity) : default;
        }

        public async Task<Order> Update(Order entity)
        {
            return entity != default ? await _repo.Update(entity) : default;
        }
    }
}