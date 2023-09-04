using ExampleMediatR.Api.Configuration;
using ExampleMediatR.Api.Persistence;
using ExampleMediatR.Api.Persistence.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

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
        }

        public async Task<IActionResult> DeleteOrderAsync(Guid Id)
        {
            var order = await _dbContext.FindAsync(Id);
            if (order == null)
            {
                return NotFound();
            }
        }

        public Task<Order> GetOrderByIdAsync(Guid Id)
        {

        }

        public Task<IEnumerable<Order>> GetOrdersAsync()
        {

        }

        public void Save()
        {

        }

        public Task UpdateOrderAsync()
        {

        }
    }
}
