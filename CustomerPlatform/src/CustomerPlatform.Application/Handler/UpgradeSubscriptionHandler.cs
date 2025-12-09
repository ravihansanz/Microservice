using CustomerPlatform.Application.Commands;
using CustomerPlatform.Application.Common.Interfaces;
using CustomerPlatform.Domain.Entities;
using CustomerPlatform.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerPlatform.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace CustomerPlatform.Application.Handler
{
    public class UpgradeSubscriptionHandler: IRequestHandler<UpgradeSubscriptionCommand, UpgradeSubscriptionResponseDto>
    {
        private readonly IApplicationDbContext _ctx;

        public UpgradeSubscriptionHandler(IApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<UpgradeSubscriptionResponseDto> Handle(
            UpgradeSubscriptionCommand request,
            CancellationToken cancellationToken)
        {
            var customer = await _ctx.Customers
                .Include(c => c.Subscriptions)
                .ThenInclude(s => s.Plan)
                .FirstOrDefaultAsync(c => c.Id == request.CustomerId);

            if (customer == null)
                throw new KeyNotFoundException("Customer not found.");

            var oldPlan = customer.Subscriptions.Plan;

            var newPlan = await _ctx.Plans.FindAsync(request.NewPlanId);
            if (newPlan == null)
                throw new KeyNotFoundException("Plan not found.");

            if (newPlan.TierLevel <= oldPlan.TierLevel)
                throw new InvalidOperationException("Cannot downgrade or same tier.");

            // update subscription
            customer.Subscriptions.PlanId = newPlan.Id;

            // create order
            var order = new Order
            {
                CustomerId = customer.Id,
                OrderType = OrderType.PlanChange,
            };

            _ctx.Orders.Add(order);
            await _ctx.SaveChangesAsync(cancellationToken);

            return new UpgradeSubscriptionResponseDto
            {
                CustomerId = customer.Id,
                OldPlanId = oldPlan.Id,
                NewPlanId = newPlan.Id,
                OrderId = order.Id,
                Status = "Upgraded"
            };
        }
    }

}
