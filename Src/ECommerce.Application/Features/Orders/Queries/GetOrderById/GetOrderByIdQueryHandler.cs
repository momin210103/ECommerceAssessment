using AutoMapper;
using ECommerce.Application.Features.Orders.DTOs;
using ECommerce.Application.Features.Orders.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Orders.Queries.GetOrderById;

public class GetOrderByIdQueryHandler
    : IRequestHandler<GetOrderByIdQuery, OrderResponse?>
{
    private readonly IOrderRepository _repository;
    private readonly IMapper _mapper;

    public GetOrderByIdQueryHandler(
        IOrderRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<OrderResponse?> Handle(
        GetOrderByIdQuery request,
        CancellationToken cancellationToken)
    {
        var order = await _repository.GetByIdAsync(request.Id);

        if (order is null)
            return null;

        return _mapper.Map<OrderResponse>(order);
    }
}