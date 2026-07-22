using AutoMapper;
using ECommerce.Application.Features.Orders.DTOs;
using ECommerce.Application.Features.Orders.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Orders.Commands.UpdateOrderStatus;

public class UpdateOrderStatusCommandHandler
    : IRequestHandler<UpdateOrderStatusCommand, OrderResponse>
{
    private readonly IOrderRepository _repository;
    private readonly IMapper _mapper;

    public UpdateOrderStatusCommandHandler(
        IOrderRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<OrderResponse> Handle(
        UpdateOrderStatusCommand request,
        CancellationToken cancellationToken)
    {
        var order = await _repository.GetByIdAsync(request.Id);

        if (order is null)
            throw new Exception("Order not found.");

        order.Status = request.Status;
        order.UpdatedAt = DateTime.UtcNow;

        await _repository.UpdateAsync(order);
        await _repository.SaveChangesAsync();

        order = await _repository.GetByIdAsync(order.Id);

        return _mapper.Map<OrderResponse>(order);
    }
}