using AutoMapper;
using ECommerce.Application.Features.Categories.Commands.CreateCategory;
using ECommerce.Application.Features.Categories.DTOs;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Common.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateCategoryRequest, CreateCategoryCommand>();

        CreateMap<Category, CategoryResponse>();
    }
}