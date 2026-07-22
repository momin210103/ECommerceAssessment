using AutoMapper;
using ECommerce.Application.Features.Orders.DTOs;
using ECommerce.Application.Features.Orders.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Orders.Queries.GetAllOrders;

public class GetAllOrdersQueryHandler
    : IRequestHandler<GetAllOrdersQuery, List<OrderResponse>>
{
    private readonly IOrderRepository _repository;
    private readonly IMapper _mapper;

    public GetAllOrdersQueryHandler(
        IOrderRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<OrderResponse>> Handle(
        GetAllOrdersQuery request,
        CancellationToken cancellationToken)
    {
        var orders = await _repository.GetAllAsync();

        return _mapper.Map<List<OrderResponse>>(orders);
    }
}