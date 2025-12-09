using AutoMapper;
using AutoMapper.QueryableExtensions;
using CustomerPlatform.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CustomerPlatform.Application.Plans.Queries.GetPlans;

public class GetPlansQueryHandler : IRequestHandler<GetPlansQuery, IList<PlanDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPlansQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IList<PlanDto>> Handle(GetPlansQuery request, CancellationToken cancellationToken)
    {
        return await _context.Plans
            .AsNoTracking()
            .ProjectTo<PlanDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}
