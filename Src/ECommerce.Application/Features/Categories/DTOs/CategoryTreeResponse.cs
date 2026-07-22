namespace ECommerce.Application.Features.Categories.DTOs;

public class CategoryTreeResponse
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public List<CategoryTreeResponse> Children { get; set; } = [];
}