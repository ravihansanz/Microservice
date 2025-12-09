using CustomerPlatform.Application.Common.Interfaces;
using CustomerPlatform.Domain.Entities;
using CustomerPlatform.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace CustomerPlatform.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Subscription> Subscriptions => Set<Subscription>();
    public DbSet<Plan> Plans => Set<Plan>();
    public DbSet<Order> Orders => Set<Order>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Customer>()
            .HasMany(c => c.Subscriptions)
            .WithOne(s => s.Customer!)
            .HasForeignKey(s => s.CustomerId);

        modelBuilder.Entity<Customer>()
            .HasMany(c => c.Orders)
            .WithOne(o => o.Customer!)
            .HasForeignKey(o => o.CustomerId);

        modelBuilder.Entity<Plan>()
            .HasMany(p => p.Subscriptions)
            .WithOne(s => s.Plan!)
            .HasForeignKey(s => s.PlanId);

        SeedData(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        var customerId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");
        var planId = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb");
        var subId = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc");
        var orderId = Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd");

        modelBuilder.Entity<Customer>().HasData(new Customer
        {
            Id = customerId,
            AccountNumber = "CST-100045",
            FirstName = "Jane",
            LastName = "Doe",
            Email = "jane.doe@example.com",
            CreatedAtUtc = new DateTime(2021, 6, 10, 9, 15, 0, DateTimeKind.Utc),
            Status = CustomerStatus.Active
        });

        modelBuilder.Entity<Plan>().HasData(new Plan
        {
            Id = planId,
            Code = "MOB-ENDLESS-40GB",
            Name = "Endless Mobile 40GB",
            PlanType = PlanType.Mobile,
            BasePrice = 55m
        });

        modelBuilder.Entity<Subscription>().HasData(new Subscription
        {
            Id = subId,
            CustomerId = customerId,
            PlanId = planId,
            Type = SubscriptionType.Mobile,
            Status = SubscriptionStatus.Active,
            StartDateUtc = new DateTime(2022, 1, 5, 10, 0, 0, DateTimeKind.Utc),
            EndDateUtc = null,
            MonthlyPrice = 55m
        });

        modelBuilder.Entity<Order>().HasData(new Order
        {
            Id = orderId,
            CustomerId = customerId,
            OrderDateUtc = new DateTime(2024, 11, 20, 2, 15, 0, DateTimeKind.Utc),
            OrderType = OrderType.NewConnection,
            Status = OrderStatus.Completed,
            TotalAmount = 89m
        });
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => base.SaveChangesAsync(cancellationToken);
}
