using ExampleMediatR.Api.Persistence;
using ExampleMediatR.Api.Persistence.Entities;
using Microsoft.AspNetCore.Mvc;

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
        if (customer == null)
            return ;

        _dbContext.Customers.Remove(customer);
        await _dbContext.SaveChangesAsync();
        
    }

    public async Task<Customer> GetCustomerByIdAsync(Guid Id)
    {

    }

    public async Task<IEnumerable<Customer>> GetCustomersAsync()
    {

    }

    public async Task SaveAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateCustomerAsync()
    {

    }
}
