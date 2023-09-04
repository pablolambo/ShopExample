namespace ExampleMediatR.Api.Persistence.Entities;
// TO-DO: new project 'data'
public class Customer
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<Order> Orders { get; set; }
}

