using ExampleMediatR.Api.Persistence.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ExampleMediatR.Api.Repositories;

public interface IOrdersRepository
{
    Task<Order> GetOrderByIdAsync(Guid Id);
    Task<IEnumerable<Order>> GetOrdersAsync();
    Task CreateOrderAsync(Order order);
    Task UpdateOrderAsync(Order order);
    Task DeleteOrderAsync(Guid Id);
    Task SaveAsync();
}

