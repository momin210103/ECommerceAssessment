using ECommerce.Domain.Enums;

namespace ECommerce.Application.Features.Orders.DTOs;

public class UpdateOrderStatusRequest
{
    public Guid Id { get; set; }

    public OrderStatus Status { get; set; }
}