using ExampleMediatR.Api.Configuration;

namespace ExampleMediatR.Api.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly OrdersConfiguration _dbContext;

        public OrdersRepository(OrdersConfiguration dbContext)
        {
            _dbContext = dbContext;
        }

        public Task CreateOrderAsync(Order order)
        {

        }

        public Task DeleteOrderAsync(Guid Id)
        {

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
