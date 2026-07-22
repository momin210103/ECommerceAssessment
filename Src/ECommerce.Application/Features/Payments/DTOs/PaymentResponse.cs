using ECommerce.Domain.Enums;

namespace ECommerce.Application.Features.Payments.DTOs;

public class PaymentResponse
{
    public Guid Id { get; set; }

    public Guid OrderId { get; set; }

    public string OrderNumber { get; set; } = string.Empty;

    public PaymentProvider Provider { get; set; }

    public PaymentStatus Status { get; set; }

    public decimal Amount { get; set; }

    public string TransactionId { get; set; } = string.Empty;

    public DateTime? PaidAt { get; set; }

    public DateTime CreatedAt { get; set; }
}