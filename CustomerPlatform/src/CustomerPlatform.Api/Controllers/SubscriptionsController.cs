using CustomerPlatform.Application.Commands;
using CustomerPlatform.Application.DTOs;
using CustomerPlatform.Application.Subscriptions;
using CustomerPlatform.Application.Subscriptions.Queries.GetSubscriptionsByCustomer;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomerPlatform.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubscriptionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public SubscriptionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("customer/{customerId:guid}")]
    public async Task<ActionResult<IEnumerable<SubscriptionDto>>> GetByCustomer(Guid customerId, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetSubscriptionsByCustomerQuery(customerId), cancellationToken);
        return Ok(result);
    }

    [HttpPost("{customerId}/upgrade")]
    public async Task<IActionResult> Upgrade(Guid customerId, UpgradeSubscriptionRequestDto req)
    {
        var result = await _mediator.Send(
            new UpgradeSubscriptionCommand(customerId, req.NewPlanId));

        return Ok(result);
    }
}
