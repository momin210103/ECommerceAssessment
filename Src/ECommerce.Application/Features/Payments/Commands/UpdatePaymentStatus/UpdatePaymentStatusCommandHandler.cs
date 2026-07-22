using AutoMapper;
using ECommerce.Application.Features.Payments.DTOs;
using ECommerce.Application.Features.Payments.Interfaces;
using ECommerce.Domain.Enums;
using MediatR;

namespace ECommerce.Application.Features.Payments.Commands.UpdatePaymentStatus;

public class UpdatePaymentStatusCommandHandler
    : IRequestHandler<UpdatePaymentStatusCommand, PaymentResponse>
{
    private readonly IPaymentRepository _repository;
    private readonly IMapper _mapper;

    public UpdatePaymentStatusCommandHandler(
        IPaymentRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PaymentResponse> Handle(
        UpdatePaymentStatusCommand request,
        CancellationToken cancellationToken)
    {
        var payment = await _repository.GetByIdAsync(request.Id);

        if (payment is null)
            throw new KeyNotFoundException("Payment not found.");

        // Already completed payment cannot be updated
        if (payment.Status == PaymentStatus.Success)
            throw new InvalidOperationException("Completed payment cannot be updated.");

        payment.Status = request.Status;

        if (!string.IsNullOrWhiteSpace(request.TransactionId))
        {
            payment.TransactionId = request.TransactionId;
        }

        if (request.Status == PaymentStatus.Success)
        {
            payment.PaidAt = DateTime.UtcNow;
        }
        else
        {
            payment.PaidAt = null;
        }

        await _repository.UpdateAsync(payment);
        await _repository.SaveChangesAsync();

        return _mapper.Map<PaymentResponse>(payment);
    }
}