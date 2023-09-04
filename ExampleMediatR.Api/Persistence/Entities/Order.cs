namespace ExampleMediatR.Api.Persistence.Entities;
// TO-DO: new project 'data'
public class Order
{
    public Guid Id { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
}
