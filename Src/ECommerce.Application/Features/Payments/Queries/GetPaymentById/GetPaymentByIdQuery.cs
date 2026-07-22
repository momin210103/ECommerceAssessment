using ECommerce.Application.Features.Payments.DTOs;
using MediatR;

namespace ECommerce.Application.Features.Payments.Queries.GetPaymentById;

public class GetPaymentByIdQuery : IRequest<PaymentResponse?>
{
    public Guid Id { get; set; }

    public GetPaymentByIdQuery(Guid id)
    {
        Id = id;
    }
}