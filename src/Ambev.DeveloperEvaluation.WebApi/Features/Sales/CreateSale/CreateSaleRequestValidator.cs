using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
    {
        public CreateSaleRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("O Id da venda é obrigatório.");
            RuleFor(x => x.SaleNumber).GreaterThan(0).WithMessage("O número da venda deve ser maior que zero.");
            RuleFor(x => x.SaleDate).LessThanOrEqualTo(DateTime.UtcNow).WithMessage("A data da venda não pode ser no futuro.");
            RuleFor(x => x.CustomerId).NotEmpty().WithMessage("O Id do cliente é obrigatório.");
            RuleFor(x => x.BranchId).NotEmpty().WithMessage("O Id da filial é obrigatório.");
        }
    }
}
