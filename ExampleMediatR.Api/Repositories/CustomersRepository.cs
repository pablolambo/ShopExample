namespace ExampleMediatR.Api.Repositories;

public class CustomersRepository : ICustomersRepository
{
    private readonly ExampleDbContext _dbContext;

    public CustomersRepository(ExampleDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task CreateCustomerAsync(Customer customer)
    {

    }

    public Task DeleteCustomerAsync(Guid Id)
    {

    }

    public Task<Customer> GetCustomerByIdAsync(Guid Id)
    {

    }

    public Task<IEnumerable<Customer>> GetCustomersAsync()
    {

    }

    public void Save()
    {

    }

    public Task UpdateCustomerAsync()
    {

    }
}
