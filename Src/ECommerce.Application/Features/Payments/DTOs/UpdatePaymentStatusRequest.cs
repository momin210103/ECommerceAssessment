using ECommerce.Domain.Enums;

namespace ECommerce.Application.Features.Payments.DTOs;

public class UpdatePaymentStatusRequest
{
    public PaymentStatus Status { get; set; }

    public string? TransactionId { get; set; }
}