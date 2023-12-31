﻿using ExampleMediatR.Api.Persistence.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ExampleMediatR.Api.Repositories;

public interface ICustomersRepository
{
    Task<Customer> GetCustomerByIdAsync(Guid Id);
    Task<IEnumerable<Customer>> GetCustomersAsync();
    Task CreateCustomerAsync(Customer customer);
    Task UpdateCustomerAsync(Customer customer);
    Task DeleteCustomerAsync(Guid Id);
}

