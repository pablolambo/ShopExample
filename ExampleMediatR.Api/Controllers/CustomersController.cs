namespace ExampleMediatR.Api.Controllers;

using ExampleMediatR.Api.Persistence.Entities;
using ExampleMediatR.Api.Persistence.Requests;
using ExampleMediatR.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class CustomersController : ControllerBase
{
    private readonly ILogger<CustomersController> _logger;
    private readonly ICustomersRepository _customersRepository;
    //private readonly IMapper _mapper;

    public CustomersController(ILogger<CustomersController> logger, ICustomersRepository customersRepository/*, IMapper mapper*/)
    {
        _logger = logger;
        _customersRepository = customersRepository;
        //_mapper = mapper;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomer(Guid id)
    {
        var customer = await _customersRepository.GetCustomerByIdAsync(id);

        if (customer == null)
        {
            return NotFound();
        }

        //var customerResponse = _mapper.MapCustomerDtoToCustomerResponse(customer);
        _logger.LogInformation($"Get customer with ID: {id}");

        return Ok(customer);
    }

    [HttpGet]
    public async Task<IActionResult> GetCustomers()
    {
        var customers = await _customersRepository.GetCustomersAsync();
        //var customerResponses = _mapper.MapCustomerDtosToCustomerResponses(customers);
        _logger.LogInformation("Getting all customers...");

        return Ok(customers);
    }


    [HttpPost]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerRequest request)
    {
        var customerToAdd = new Customer
        {
            Id = new Guid(),
            Name = request.Name,
            Orders = new List<Order>()
        };

        //var customerResponse = _mapper.MapCustomerDtoToCustomerResponse(customerToAdd);

        await _customersRepository.CreateCustomerAsync(customerToAdd);
        _logger.LogInformation($"Create customer: {customerToAdd.Name} with ID: {customerToAdd.Id}");

        return Ok(customerToAdd);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomer(Guid id)
    {
        var customer = await _customersRepository.GetCustomerByIdAsync(id);

        if (customer == null)
        {
            return NotFound();
        }

        await _customersRepository.DeleteCustomerAsync(id);
        _logger.LogInformation($"Delete customer with ID: {id}");

        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCustomer(Guid id, [FromBody] UpdateCustomerRequest request)
    {
        var customer = await _customersRepository.GetCustomerByIdAsync(id);

        if (customer == null)
        {
            return NotFound();
        }

        customer.Name = request.Name;
        customer.Orders = request.Orders;

        await _customersRepository.UpdateCustomerAsync(customer);
        _logger.LogInformation($"Update customer with ID: {id}");

        //var updatedCustomerResponse = _mapper.MapCustomerDtoToCustomerResponse(customer);

        return Ok(customer);
    }


}
