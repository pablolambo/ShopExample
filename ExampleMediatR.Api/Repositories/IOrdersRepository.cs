using ExampleMediatR.Api.Persistence.Entities;

namespace ExampleMediatR.Api.Repositories;

public interface IOrdersRepository
{
    Task<Order> GetOrderByIdAsync(Guid Id);
    Task<IEnumerable<Order>> GetOrdersAsync();
    Task CreateOrderAsync(Order order);
    Task UpdateOrderAsync(Order order);
    Task DeleteOrderAsync(Guid Id);
    void Save();
}

