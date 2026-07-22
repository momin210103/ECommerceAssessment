using FluentValidation;

namespace ECommerce.Application.Features.Payments.Commands.UpdatePaymentStatus;

public class UpdatePaymentStatusCommandValidator
    : AbstractValidator<UpdatePaymentStatusCommand>
{
    public UpdatePaymentStatusCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.Status)
            .IsInEnum();
    }
}