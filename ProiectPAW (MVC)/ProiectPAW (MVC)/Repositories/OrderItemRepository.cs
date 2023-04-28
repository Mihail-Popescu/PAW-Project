using Microsoft.EntityFrameworkCore;
using ProiectPAW__MVC_.Data;
using ProiectPAW__MVC_.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProiectPAW__MVC_.Repositories
{
    public class OrderItemRepository
    {
        private readonly ProiectPAWDbContext _dbContext;

        public OrderItemRepository(ProiectPAWDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OrderItem> GetOrderItemByIdAsync(int orderItemId)
        {
            return await _dbContext.OrderItem
                .Include(oi => oi.Product)
                .FirstOrDefaultAsync(oi => oi.OrderItemId == orderItemId);
        }

        public async Task AddOrderItemAsync(OrderItem orderItem)
        {
            _dbContext.OrderItem.Add(orderItem);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveOrderItemAsync(int orderItemId)
        {
            Console.WriteLine($"Removing order item with id {orderItemId}...");
            var orderItem = await GetOrderItemByIdAsync(orderItemId);
            _dbContext.OrderItem.Remove(orderItem);
            await _dbContext.SaveChangesAsync();
            Console.WriteLine($"Order item with id {orderItemId} removed successfully.");
        }


        public async Task<List<OrderItem>> GetOrderItemsByOrderIdAsync(int orderId)
        {
            return await _dbContext.OrderItem
                .Include(oi => oi.Product)
                .Where(oi => oi.OrderId == orderId)
                .ToListAsync();
        }



    }
}
