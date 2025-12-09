using CustomerPlatform.Application.Orders;
using CustomerPlatform.Application.Orders.Queries.GetOrderById;
using CustomerPlatform.Application.Orders.Queries.GetOrdersByCustomer;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomerPlatform.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrdersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<OrderDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetOrderByIdQuery(id), cancellationToken);
        if (result is null)
        {
            return NotFound(new { error = "Order not found", orderId = id });
        }
        return Ok(result);
    }

    [HttpGet("customer/{customerId:guid}")]
    public async Task<ActionResult<IEnumerable<OrderDto>>> GetByCustomer(Guid customerId, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetOrdersByCustomerQuery(customerId), cancellationToken);
        return Ok(result);
    }
}
