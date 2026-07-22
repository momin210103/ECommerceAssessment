using AutoMapper;
using ECommerce.Application.Features.Categories.Commands.CreateCategory;
using ECommerce.Application.Features.Categories.DTOs;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Common.Mapping;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, CategoryResponse>();

        CreateMap<CreateCategoryCommand, Category>();

        CreateMap<Category, CreateCategoryCommand>();
    }
}