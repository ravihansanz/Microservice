using CustomerPlatform.Application.Orders;
using MediatR;

namespace CustomerPlatform.Application.Orders.Queries.GetOrderById;

public record GetOrderByIdQuery(Guid Id) : IRequest<OrderDto?>;
