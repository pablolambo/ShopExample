﻿using ExampleMediatR.Api.Persistence.Entities;

namespace ExampleMediatR.Api.Persistence.Requests
{
    public class CreateCustomerOrderRequest
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public Customer Customer { get; set; }

    }
}
