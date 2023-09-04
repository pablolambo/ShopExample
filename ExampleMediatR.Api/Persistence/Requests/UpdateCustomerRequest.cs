namespace ExampleMediatR.Api.Persistence.Requests;

using ExampleMediatR.Api.Persistence.Entities;

public class UpdateCustomerRequest
{
    public string Name { get; set; }
    public IEnumerable<Order>? Orders { get; set; }
}

