using AutoMapper;
using ECommerce.Application.Features.Payments.DTOs;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Common.Mappings;

public class PaymentProfile : Profile
{
    public PaymentProfile()
    {
        CreateMap<Payment, PaymentResponse>()
            .ForMember(dest => dest.OrderNumber,
                opt => opt.MapFrom(src => src.Order.OrderNumber));
    }
}