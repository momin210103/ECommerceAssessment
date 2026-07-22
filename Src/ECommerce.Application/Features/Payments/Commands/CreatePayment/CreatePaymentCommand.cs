using ECommerce.Application.Features.Payments.DTOs;
using ECommerce.Domain.Enums;
using MediatR;

namespace ECommerce.Application.Features.Payments.Commands.CreatePayment;

public class CreatePaymentCommand : IRequest<PaymentResponse>
{
    public Guid OrderId { get; set; }

    public PaymentProvider Provider { get; set; }
}