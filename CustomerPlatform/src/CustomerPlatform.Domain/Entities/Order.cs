using System;

namespace CustomerPlatform.Domain.Entities;

public class Order
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }

    public DateTime OrderDateUtc { get; set; }
    public Enums.OrderType OrderType { get; set; }
    public Enums.OrderStatus Status { get; set; }
    public decimal TotalAmount { get; set; }

    public Customer? Customer { get; set; }
}
