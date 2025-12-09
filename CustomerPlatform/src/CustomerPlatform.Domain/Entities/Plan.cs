using System;

namespace CustomerPlatform.Domain.Entities;

public class Plan
{
    public Guid Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public Enums.PlanType PlanType { get; set; }
    public decimal BasePrice { get; set; }
    public int TierLevel { get; set; }

    public ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();
}
