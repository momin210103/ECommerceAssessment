using ECommerce.Application.Features.Products.DTOs;
using ECommerce.Domain.Enums;
using MediatR;

namespace ECommerce.Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductCommand : IRequest<ProductResponse>
{
    public Guid Id { get; set; }

    public Guid CategoryId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string SKU { get; set; } = string.Empty;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public int Stock { get; set; }

    public ProductStatus Status { get; set; }
}