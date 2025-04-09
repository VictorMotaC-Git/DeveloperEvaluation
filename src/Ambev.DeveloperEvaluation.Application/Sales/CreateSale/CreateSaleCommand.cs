using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleCommand : IRequest<CreateSaleResult>
    {
        public Guid Id { get; private set; }

        public int SaleNumber { get; private set; }

        public DateTime SaleDate { get; private set; }

        public Guid CustomerId { get; private set; }

        public Guid BranchId { get; private set; }

        public bool IsCancelled { get; private set; }

        public List<CreateSaleItemModel> Items { get; set; } = new();

        public ValidationResultDetail Validate()
        {
            var validator = new CreateSaleCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }

    public class CreateSaleItemModel
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
