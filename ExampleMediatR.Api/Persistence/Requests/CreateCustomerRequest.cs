namespace ExampleMediatR.Api.Persistence.Requests
{
    public class CreateCustomerRequest
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
    }
}
