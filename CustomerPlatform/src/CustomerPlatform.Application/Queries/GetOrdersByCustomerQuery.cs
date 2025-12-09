using CustomerPlatform.Application.Orders;
using MediatR;

namespace CustomerPlatform.Application.Orders.Queries.GetOrdersByCustomer;

public record GetOrdersByCustomerQuery(Guid CustomerId) : IRequest<IList<OrderDto>>;
