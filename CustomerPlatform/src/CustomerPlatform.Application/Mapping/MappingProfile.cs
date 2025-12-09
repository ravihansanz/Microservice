using AutoMapper;
using CustomerPlatform.Application.Customers;
using CustomerPlatform.Application.Orders;
using CustomerPlatform.Application.Plans;
using CustomerPlatform.Application.Subscriptions;
using CustomerPlatform.Domain.Entities;

namespace CustomerPlatform.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Customer, CustomerDto>()
            .ForMember(d => d.Status, opt => opt.MapFrom(s => s.Status.ToString()));

        CreateMap<CustomerDto, Customer>()
            .ForMember(d => d.Status, opt => opt.Ignore()); // set in handler

        CreateMap<Subscription, SubscriptionDto>()
            .ForMember(d => d.Type, opt => opt.MapFrom(s => s.Type.ToString()))
            .ForMember(d => d.Status, opt => opt.MapFrom(s => s.Status.ToString()));

        CreateMap<Order, OrderDto>()
            .ForMember(d => d.OrderType, opt => opt.MapFrom(s => s.OrderType.ToString()))
            .ForMember(d => d.Status, opt => opt.MapFrom(s => s.Status.ToString()));

        CreateMap<Plan, PlanDto>()
            .ForMember(d => d.PlanType, opt => opt.MapFrom(s => s.PlanType.ToString()));
    }
}
