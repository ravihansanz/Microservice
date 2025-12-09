using CustomerPlatform.Application.Plans;
using CustomerPlatform.Application.Plans.Queries.GetPlans;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomerPlatform.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlansController : ControllerBase
{
    private readonly IMediator _mediator;

    public PlansController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PlanDto>>> GetAll(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetPlansQuery(), cancellationToken);
        return Ok(result);
    }
}
