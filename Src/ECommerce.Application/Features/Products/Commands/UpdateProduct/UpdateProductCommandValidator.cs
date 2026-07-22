using FluentValidation;

namespace ECommerce.Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.CategoryId)
            .NotEmpty();

        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.SKU)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Price)
            .GreaterThan(0);

        RuleFor(x => x.Stock)
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.Description)
            .MaximumLength(1000);
    }
}