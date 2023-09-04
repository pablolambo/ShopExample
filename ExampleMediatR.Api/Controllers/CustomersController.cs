namespace ExampleMediatR.Api.Controllers;

using ExampleMediatR.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class CustomersController : ControllerBase
{
    private readonly ILogger<CustomersController> _logger;
    private readonly ICustomersRepository _customersRepository;
    private readonly IMapper _mapper;

    public CustomersController(ILogger<CustomersController> logger, ICustomersRepository customersRepository, IMapper mapper)
    {
        _logger = logger;
        _customersRepository = customersRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetCustomer(Guid customerId)
    {
           
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerRequest request)
    {
        var customer = await _customersRepository.CreateCustomerAsync(request.Id, request.Name);
        _logger.LogInformation($"Create customer: {customer.Name} with ID: {customer.Id}");

        var customerResponse = _mapper.MapCustomerDtoToCustomerResponse(customer);
        return CreatedAtAction("GetCustomer", new { Id = customer.Id }, customerResponse);
    }
}
