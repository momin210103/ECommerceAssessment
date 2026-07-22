using ECommerce.Application.Features.Orders.DTOs;
using ECommerce.Domain.Enums;
using MediatR;

namespace ECommerce.Application.Features.Orders.Commands.UpdateOrderStatus;

public class UpdateOrderStatusCommand : IRequest<OrderResponse>
{
    public Guid Id { get; set; }

    public OrderStatus Status { get; set; }
}