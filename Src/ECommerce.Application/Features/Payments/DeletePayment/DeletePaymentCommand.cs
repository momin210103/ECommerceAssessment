using MediatR;

namespace ECommerce.Application.Features.Payments.Commands.DeletePayment;

public class DeletePaymentCommand : IRequest<bool>
{
    public Guid Id { get; set; }

    public DeletePaymentCommand(Guid id)
    {
        Id = id;
    }
}