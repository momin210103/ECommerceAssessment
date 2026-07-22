using ECommerce.Application.Features.Payments.Interfaces;
using ECommerce.Domain.Enums;
using MediatR;

namespace ECommerce.Application.Features.Payments.Commands.DeletePayment;

public class DeletePaymentCommandHandler
    : IRequestHandler<DeletePaymentCommand, bool>
{
    private readonly IPaymentRepository _repository;

    public DeletePaymentCommandHandler(IPaymentRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(
        DeletePaymentCommand request,
        CancellationToken cancellationToken)
    {
        var payment = await _repository.GetByIdAsync(request.Id);

        if (payment is null)
            return false;

        // Production Rule:
        // Successful payments should not be deleted.
        if (payment.Status == PaymentStatus.Success)
            throw new InvalidOperationException(
                "Successful payments cannot be deleted.");

        await _repository.DeleteAsync(payment);
        await _repository.SaveChangesAsync();

        return true;
    }
}