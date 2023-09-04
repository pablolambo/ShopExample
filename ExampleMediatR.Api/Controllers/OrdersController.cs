namespace ExampleMediatR.Api.Controllers;

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

    [HttpGet]
    public async Task<IActionResult> GetOrder(Guid orderId)
    {
        var order = await _ordersRepository.GetOrderAsync(orderId);
        if (order == null) { return NotFound(); }
        var orderResponse = _mapper.MapOrderDtoToOrderResponse(order);
        return Ok(orderResponse);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllOrders()
    {
        var orders = await _ordersRepository.GetOrdersAsync();
        var orderResponses = _mapper.MapOrdersDtosToOrderResponses(orders);
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
}
