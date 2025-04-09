using Ambev.DeveloperEvaluation.Common.Security;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class CreateSaleRequest
    {
        public Guid Id { get; set; }

        public int SaleNumber { get; set; }

        public DateTime SaleDate { get; set; }

        public Guid CustomerId { get; set; }

        public Guid BranchId { get; set; }

        public bool IsCancelled { get; set; }

        public List<CreateSaleItemRequest> Items { get; set; } = new();
    }

    public class CreateSaleItemRequest
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
