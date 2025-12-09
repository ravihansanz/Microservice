using CustomerPlatform.Application.Plans;
using MediatR;

namespace CustomerPlatform.Application.Plans.Queries.GetPlans;

public record GetPlansQuery() : IRequest<IList<PlanDto>>;
