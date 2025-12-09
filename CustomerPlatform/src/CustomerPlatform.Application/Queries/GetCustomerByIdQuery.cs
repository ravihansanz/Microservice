using CustomerPlatform.Application.Customers;
using MediatR;

namespace CustomerPlatform.Application.Customers.Queries.GetCustomerById;

public record GetCustomerByIdQuery(Guid Id) : IRequest<CustomerDto?>;
