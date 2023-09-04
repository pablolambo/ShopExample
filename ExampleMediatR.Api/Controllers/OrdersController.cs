namespace ExampleMediatR.Api.Controllers;

using ExampleMediatR.Api.Persistence.Requests;
using ExampleMediatR.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
    private readonly ILogger<OrdersController> _logger;
    private readonly IOrdersRepository _ordersRepository;
    private readonly IMapper _mapper;

    public OrdersController(ILogger<OrdersController> logger, IOrdersRepository ordersRepository, IMapper mapper)
    {
        _logger = logger;
        _ordersRepository = ordersRepository;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrder(Guid id)
    {
        var order = await _ordersRepository.GetOrderByIdAsync(id);

        if (order == null) 
        {
            return NotFound();
        
        }
        var orderResponse = _mapper.MapOrderDtoToOrderResponse(order);
        _logger.LogInformation($"Getting order with ID: {id}");

        return Ok(orderResponse);
    }

    [HttpGet]
    public async Task<IActionResult> GetOrders()
    {
        var orders = await _ordersRepository.GetOrdersAsync();
        var orderResponses = _mapper.MapOrdersDtosToOrderResponses(orders);
        _logger.LogInformation($"Getting all orders...");

        return Ok(orderResponses);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] CreateCustomerOrderRequest request)
    {
        var order = await _ordersRepository.CreateOrderAsync(request.Id, request.Name);
        _logger.LogInformation($"Create order for customer id: {order.CustomerId} for product with ID: {order.Id}");

        var orderResponse = _mapper.MapOrderDtoToCustomerResponse(order);
        return CreatedAtAction("GetCustomer", new { Id = order.Id }, orderResponse);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrder(Guid id)
    {
        var order = await _ordersRepository.GetOrderByIdAsync(id);

        if (order == null)
        {
            return NotFound();
        }

        await _ordersRepository.DeleteOrderAsync(id);
        _logger.LogInformation($"Deleted order with ID: {id}");

        return NoContent();

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateOrder(Guid id, [FromBody] UpdateCustomerOrderRequest request)
    {
        var order = await _ordersRepository.GetOrderByIdAsync(id);
        if(order == null)
        {
            return NotFound();
        }

        order.ProductName = request.ProductName;
        order.Price = request.Price;

        await _ordersRepository.UpdateOrderAsync(order);
        _logger.LogInformation($"Updated order with ID: {id}");

        var updatedOrderResponse = _mapper.MapOrderDtoToOrderResponse(order);
        return Ok(updatedOrderResponse);
    }
}
