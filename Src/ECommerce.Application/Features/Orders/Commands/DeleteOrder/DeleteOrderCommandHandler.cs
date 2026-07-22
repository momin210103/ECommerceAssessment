using ECommerce.Application.Features.Orders.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Orders.Commands.DeleteOrder;

public class DeleteOrderCommandHandler
    : IRequestHandler<DeleteOrderCommand, bool>
{
    private readonly IOrderRepository _repository;

    public DeleteOrderCommandHandler(IOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(
        DeleteOrderCommand request,
        CancellationToken cancellationToken)
    {
        var order = await _repository.GetByIdAsync(request.Id);

        if (order is null)
            return false;

        await _repository.DeleteAsync(order);
        await _repository.SaveChangesAsync();

        return true;
    }
}