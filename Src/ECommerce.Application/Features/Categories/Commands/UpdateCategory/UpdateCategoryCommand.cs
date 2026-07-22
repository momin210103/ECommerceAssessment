using ECommerce.Application.Features.Categories.DTOs;
using MediatR;

namespace ECommerce.Application.Features.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommand : IRequest<CategoryResponse>
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }
}