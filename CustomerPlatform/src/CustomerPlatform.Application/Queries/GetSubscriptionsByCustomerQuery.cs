using CustomerPlatform.Application.Subscriptions;
using MediatR;

namespace CustomerPlatform.Application.Subscriptions.Queries.GetSubscriptionsByCustomer;

public record GetSubscriptionsByCustomerQuery(Guid CustomerId) : IRequest<IList<SubscriptionDto>>;
