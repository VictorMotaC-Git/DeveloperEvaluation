using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale
{
    public class GetSaleValidator : AbstractValidator<GetSaleCommand>
    {
        public GetSaleValidator()
        {
            RuleFor(x => x.id)
            .NotEmpty()
            .WithMessage("User ID is required");
        }
    }
}
