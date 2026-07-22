using ECommerce.Application.Features.Orders.DTOs;
using MediatR;

namespace ECommerce.Application.Features.Orders.Commands.CreateOrder;

public class CreateOrderCommand : IRequest<OrderResponse>
{
    public Guid UserId { get; set; }

    public List<CreateOrderItemRequest> Items { get; set; } = new();
}