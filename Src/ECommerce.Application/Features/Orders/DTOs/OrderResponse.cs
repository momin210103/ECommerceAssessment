using ECommerce.Domain.Enums;

namespace ECommerce.Application.Features.Orders.DTOs;

public class OrderResponse
{
    public Guid Id { get; set; }

    public string OrderNumber { get; set; } = string.Empty;

    public Guid UserId { get; set; }

    public decimal TotalAmount { get; set; }

    public OrderStatus Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public List<OrderItemResponse> OrderItems { get; set; } = new();
}