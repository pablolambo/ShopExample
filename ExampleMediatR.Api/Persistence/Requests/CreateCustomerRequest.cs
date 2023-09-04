using ExampleMediatR.Api.Persistence.Entities;

namespace ExampleMediatR.Api.Persistence.Requests
{
    public class CreateCustomerRequest
    {
        public string Name { get; set; }
    }
}