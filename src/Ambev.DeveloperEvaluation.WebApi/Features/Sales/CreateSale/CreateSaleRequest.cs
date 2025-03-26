using Ambev.DeveloperEvaluation.Common.Security;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class CreateSaleRequest
    {
        public Guid Id { get; private set; }

        public int SaleNumber { get; private set; }

        public DateTime SaleDate { get; private set; }

        public Guid CustomerId { get; private set; }

        public Guid BranchId { get; private set; }

        public bool IsCancelled { get; private set; }
    }
}
