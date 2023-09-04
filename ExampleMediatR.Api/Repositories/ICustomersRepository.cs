namespace ExampleMediatR.Api.Repositories;

public interface ICustomersRepository
{
    Task<Customer> GetCustomerByIdAsync(Guid Id);
    Task<IEnumerable<Customer>> GetCustomersAsync();
    Task CreateCustomerAsync(Customer customer);
    Task UpdateCustomerAsync();
    Task DeleteCustomerAsync(Guid Id);
    void Save();
}

