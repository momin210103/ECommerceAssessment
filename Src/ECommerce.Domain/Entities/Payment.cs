using ECommerce.Domain.Common;
using ECommerce.Domain.Enums;

namespace ECommerce.Domain.Entities;

public class Payment : BaseEntity
{
    public Guid OrderId { get; set; }

    public PaymentProvider Provider { get; set; }

    public PaymentStatus Status { get; set; }

    public decimal Amount { get; set; }

    public string TransactionId { get; set; } = string.Empty;

    public DateTime? PaidAt { get; set; }

    public Order Order { get; set; } = null!;
}