using System;

namespace CustomerPlatform.Domain.Entities;

public class Customer
{
    public Guid Id { get; set; }
    public string AccountNumber { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime CreatedAtUtc { get; set; }

    public Enums.CustomerStatus Status { get; set; }

    public ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}
