using ECommerce.Application.Features.Categories.DTOs;
using MediatR;

namespace ECommerce.Application.Features.Categories.Commands.CreateCategory;

public record CreateCategoryCommand(
    string Name,
    string? Description,
    Guid? ParentCategoryId
) : IRequest<CategoryResponse>;