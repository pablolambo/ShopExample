namespace ExampleMediatR.Api.Controllers;

using ExampleMediatR.Api.Persistence.Entities;
using ExampleMediatR.Api.Persistence.Requests;
using ExampleMediatR.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
    private readonly ILogger<OrdersController> _logger;
    private readonly IOrdersRepository _ordersRepository;
    //private readonly IMapper _mapper;

    public OrdersController(ILogger<OrdersController> logger, IOrdersRepository ordersRepository/*, IMapper mapper*/)
    {
        _logger = logger;
        _ordersRepository = ordersRepository;
        //_mapper = mapper;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrder(Guid id)
    {
        var order = await _ordersRepository.GetOrderByIdAsync(id);

        if (order == null) 
        {
            return NotFound();
        
        }
        //var orderResponse = _mapper.MapOrderDtoToOrderResponse(order);
        _logger.LogInformation($"Getting order with ID: {id}");

        return Ok(order);
    }

    [HttpGet]
    public async Task<IActionResult> GetOrders()
    {
        var orders = await _ordersRepository.GetOrdersAsync();
        //var orderResponses = _mapper.MapOrdersDtosToOrderResponses(orders);
        _logger.LogInformation($"Getting all orders...");

        return Ok(orders);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] CreateCustomerOrderRequest request)
    {
        var orderToAdd = new Order
        {
            Id = Guid.NewGuid(),
            ProductName = request.ProductName,
            Price = request.Price,
            Customer = request.Customer
        };
        //var orderResponse = _mapper.MapOrderDtoToCustomerResponse(order);

        await _ordersRepository.CreateOrderAsync(orderToAdd);
        _logger.LogInformation($"Create order for customer id: {orderToAdd.CustomerId} for product with ID: {orderToAdd.Id}");

        return Ok(orderToAdd);
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
        _logger.LogInformation($"Delete order with ID: {id}");

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
      
        order.Customer = request.Customer;
        order.ProductName = request.ProductName;
        order.Price = request.Price;

        //var updatedOrderResponse = _mapper.MapOrderDtoToOrderResponse(order);

        await _ordersRepository.UpdateOrderAsync(order);
        _logger.LogInformation($"Update order with ID: {id}");

        return Ok(order);
    }
}
