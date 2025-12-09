using CustomerPlatform.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerPlatform.Application.Commands
{
    public record UpgradeSubscriptionCommand(Guid CustomerId, int NewPlanId)
    : IRequest<UpgradeSubscriptionResponseDto>;
}
