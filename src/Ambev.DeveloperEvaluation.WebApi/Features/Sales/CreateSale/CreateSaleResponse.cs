using Ambev.DeveloperEvaluation.Common.Security;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class CreateSaleResponse
    {
        public Guid Id { get; private set; }

        public int SaleNumber { get; private set; }

        public DateTime SaleDate { get; private set; }

        public Guid CustomerId { get; private set; }

        public decimal TotalAmount => Items.Sum(item => item.TotalPrice);

        public Guid BranchId { get; private set; }

        public bool IsCancelled { get; private set; }

        public IReadOnlyCollection<ISaleItem> Items => _items.AsReadOnly();

        private readonly List<ISaleItem> _items = new();
    }
}
