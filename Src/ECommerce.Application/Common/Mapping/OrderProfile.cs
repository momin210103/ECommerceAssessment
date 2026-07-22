using AutoMapper;
using ECommerce.Application.Features.Orders.DTOs;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Common.Mappings;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<Order, OrderResponse>();

        CreateMap<OrderItem, OrderItemResponse>()
            .ForMember(dest => dest.ProductName,
                opt => opt.MapFrom(src => src.Product.Name))
            .ForMember(dest => dest.ProductSKU,
                opt => opt.MapFrom(src => src.Product.SKU));
    }
}