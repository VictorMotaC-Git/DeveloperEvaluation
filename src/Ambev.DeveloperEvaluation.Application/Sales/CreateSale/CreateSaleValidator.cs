using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
    {

        public CreateSaleCommandValidator()
        {
            RuleFor(sale => sale.Id).NotEmpty().WithMessage("O Id da venda é obrigatório.");
            RuleFor(sale => sale.SaleNumber).GreaterThan(0).WithMessage("O número da venda deve ser maior que zero.");
            RuleFor(sale => sale.SaleDate).LessThanOrEqualTo(DateTime.UtcNow).WithMessage("A data da venda não pode ser no futuro.");
            RuleFor(sale => sale.CustomerId).NotEmpty().WithMessage("O Id do cliente é obrigatório.");
            RuleFor(sale => sale.BranchId).NotEmpty().WithMessage("O Id da filial é obrigatório.");
        }
    }
}
