using CustomerPlatform.Application.Customers;
using MediatR;

namespace CustomerPlatform.Application.Customers.Commands.CreateCustomer;

public record CreateCustomerCommand(
    string FirstName,
    string LastName,
    string Email,
    string? AccountNumber
) : IRequest<CustomerDto>;
