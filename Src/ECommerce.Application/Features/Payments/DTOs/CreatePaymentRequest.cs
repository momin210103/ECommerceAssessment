using ECommerce.Domain.Enums;

namespace ECommerce.Application.Features.Payments.DTOs;

public class CreatePaymentRequest
{
    public Guid OrderId { get; set; }

    public PaymentProvider Provider { get; set; }
}