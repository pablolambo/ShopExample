using ExampleMediatR.Api.Configuration;
using ExampleMediatR.Api.Persistence;
using ExampleMediatR.Api.Persistence.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExampleMediatR.Api.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly ShopDbContext _dbContext;

        public OrdersRepository(ShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateOrderAsync(Order order)
        {
            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(Guid id)
        {
            var order = await _dbContext.Orders.FindAsync(id);
            _dbContext.Orders.Remove(order);
            await _dbContext.SaveChangesAsync();

        }

        public async Task<Order> GetOrderByIdAsync(Guid id)
        {
            var order = await _dbContext.Orders.FindAsync(id);
            return order;
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            var orders = await _dbContext.Orders.ToListAsync();
            return orders;
        }

        public async Task UpdateOrderAsync(Order order)
        {
            _dbContext.Orders.Update(order);
            await _dbContext.SaveChangesAsync();
        }
    }
}
