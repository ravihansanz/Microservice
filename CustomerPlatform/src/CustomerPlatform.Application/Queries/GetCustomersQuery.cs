using CustomerPlatform.Application.Customers;
using MediatR;

namespace CustomerPlatform.Application.Customers.Queries.GetCustomers;

public record GetCustomersQuery() : IRequest<IList<CustomerDto>>;
