using AutoMapper;
using AutoMapper.QueryableExtensions;
using CustomerPlatform.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CustomerPlatform.Application.Subscriptions.Queries.GetSubscriptionsByCustomer;

public class GetSubscriptionsByCustomerQueryHandler
    : IRequestHandler<GetSubscriptionsByCustomerQuery, IList<SubscriptionDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetSubscriptionsByCustomerQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IList<SubscriptionDto>> Handle(GetSubscriptionsByCustomerQuery request, CancellationToken cancellationToken)
    {
        return await _context.Subscriptions
            .Where(s => s.CustomerId == request.CustomerId)
            .Include(s => s.Plan)
            .AsNoTracking()
            .ProjectTo<SubscriptionDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}
