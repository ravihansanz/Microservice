using AutoMapper;
using CustomerPlatform.Application.Common.Interfaces;
using CustomerPlatform.Application.Customers;
using CustomerPlatform.Domain.Entities;
using CustomerPlatform.Domain.Enums;
using MediatR;

namespace CustomerPlatform.Application.Customers.Commands.CreateCustomer;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreateCustomerCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var entity = new Customer
        {
            Id = Guid.NewGuid(),
            AccountNumber = string.IsNullOrWhiteSpace(request.AccountNumber)
                ? $"CST-{Random.Shared.Next(100000, 999999)}"
                : request.AccountNumber,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            CreatedAtUtc = DateTime.UtcNow,
            Status = CustomerStatus.Active
        };

        _context.Customers.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<CustomerDto>(entity);
    }
}
