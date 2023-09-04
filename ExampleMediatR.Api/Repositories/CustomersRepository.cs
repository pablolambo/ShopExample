using ExampleMediatR.Api.Persistence;
using ExampleMediatR.Api.Persistence.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExampleMediatR.Api.Repositories;

public class CustomersRepository : ICustomersRepository
{
    private readonly ShopDbContext _dbContext;

    public CustomersRepository(ShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateCustomerAsync(Customer customer)
    {
        _dbContext.Customers.Add(customer);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteCustomerAsync(Guid id)
    {
        var customer = await _dbContext.Customers.FindAsync(id);
        _dbContext.Customers.Remove(customer);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Customer> GetCustomerByIdAsync(Guid id)
    {
        var customer = await _dbContext.Customers.FindAsync(id);
        return customer;
    }

    public async Task<IEnumerable<Customer>> GetCustomersAsync()
    {
        var customers = await _dbContext.Customers.ToListAsync();
        return customers;
    }

    public async Task UpdateCustomerAsync(Customer customer)
    {
        _dbContext.Customers.Update(customer);
        await _dbContext.SaveChangesAsync();
    }
}
