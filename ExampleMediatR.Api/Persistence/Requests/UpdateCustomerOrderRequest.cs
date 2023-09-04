namespace ExampleMediatR.Api.Persistence.Requests
{
    public class UpdateCustomerOrderRequest
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
    }
}
