using System;
using System.Numerics;

namespace CustomerPlatform.Domain.Entities;

public class Subscription
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public Guid PlanId { get; set; }

    public Enums.SubscriptionType Type { get; set; }
    public Enums.SubscriptionStatus Status { get; set; }

    public DateTime StartDateUtc { get; set; }
    public DateTime? EndDateUtc { get; set; }
    public decimal MonthlyPrice { get; set; }

    public Customer? Customer { get; set; }
    public Plan? Plan { get; set; }
}
