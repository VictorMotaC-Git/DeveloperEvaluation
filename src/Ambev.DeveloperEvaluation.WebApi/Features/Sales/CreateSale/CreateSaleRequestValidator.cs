using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
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

            RuleFor(x => x.Items)
                .NotEmpty().WithMessage("A venda deve conter pelo menos um item.")
                .Must(items => items.All(i => i.Quantity <= 20))
                .WithMessage("Cada item da venda pode ter no máximo 20 unidades.");

            RuleForEach(x => x.Items).ChildRules(item =>
            {
                item.RuleFor(i => i.Quantity).GreaterThan(0).WithMessage("A quantidade deve ser maior que zero.");
                item.RuleFor(i => i.UnitPrice).GreaterThan(0).WithMessage("O preço unitário deve ser maior que zero.");
            });
        }
    }

    public class CreateSaleItemRequestValidator : AbstractValidator<CreateSaleItemRequest>
    {
        public CreateSaleItemRequestValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("O produto é obrigatório.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantidade deve ser maior que zero.")
                .LessThanOrEqualTo(20).WithMessage("Quantidade não pode ultrapassar 20 unidades por item.");

            RuleFor(x => x.UnitPrice)
                .GreaterThan(0).WithMessage("O preço unitário deve ser maior que zero.");
        }
    }
}
