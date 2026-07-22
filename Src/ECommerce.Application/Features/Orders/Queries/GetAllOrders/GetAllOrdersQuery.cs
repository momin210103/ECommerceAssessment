using ECommerce.Application.Features.Orders.DTOs;
using MediatR;

namespace ECommerce.Application.Features.Orders.Queries.GetAllOrders;

public class GetAllOrdersQuery : IRequest<List<OrderResponse>>
{
}