using ECommerce.Application.Features.Categories.DTOs;
using MediatR;

namespace ECommerce.Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommand : IRequest<CategoryResponse>
{
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }
}