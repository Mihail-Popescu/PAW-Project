using Microsoft.EntityFrameworkCore;
using ProiectPAW__MVC_.Data;
using ProiectPAW__MVC_.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProiectPAW__MVC_.Repositories
{
    public class OrderRepository
    {
        private readonly ProiectPAWDbContext _dbContext;
        public OrderRepository(ProiectPAWDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<Order> GetCartByCustomerIdAsync(int customerId)
        {
            return await _dbContext.Order.FirstOrDefaultAsync(o => o.CustomerId == customerId && o.OrderDate == null);
        }

        public async Task AddOrderAsync(Order order)
        {
            _dbContext.Order.Add(order);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateOrderAsync(Order order)
        {
            _dbContext.Order.Update(order);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _dbContext.Order.FirstOrDefaultAsync(o => o.OrderId == id);
        }

        public async Task<Order> GetActiveOrderByCustomerIdAsync(int customerId)
        {
            return await _dbContext.Order.FirstOrDefaultAsync(o => o.CustomerId == customerId);
        }


    }
}
