using ECommerce.Application.Features.Payments.DTOs;
using ECommerce.Domain.Enums;
using MediatR;

namespace ECommerce.Application.Features.Payments.Commands.UpdatePaymentStatus;

public class UpdatePaymentStatusCommand : IRequest<PaymentResponse>
{
    public Guid Id { get; set; }

    public PaymentStatus Status { get; set; }

    public string? TransactionId { get; set; }
}