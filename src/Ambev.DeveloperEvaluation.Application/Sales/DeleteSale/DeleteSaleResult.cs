
namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale
{
    public class DeleteSaleResult
    {
        public Guid Id { get; set; }
        public bool IsCancelled { get; set; }
        public DateTime CancelledAt { get; set; }
    }
}
