using AutoMapper;
using ECommerce.Application.Features.Products.Commands.CreateProduct;
using ECommerce.Application.Features.Products.Commands.UpdateProduct;
using ECommerce.Application.Features.Products.DTOs;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Common.Mappings;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductResponse>()
            .ForMember(
                dest => dest.CategoryName,
                opt => opt.MapFrom(src => src.Category.Name));

        CreateMap<CreateProductCommand, Product>();
        CreateMap<UpdateProductCommand, Product>();
    }
}