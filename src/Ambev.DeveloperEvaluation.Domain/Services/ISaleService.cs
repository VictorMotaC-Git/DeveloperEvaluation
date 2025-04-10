using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Services
{
    public interface ISaleService
    {
        Task<Sale> CreateSaleAsync(Sale sale);
        Task<Sale?> GetSaleByIdAsync(Guid id);
        Task<IEnumerable<Sale>> GetAllSalesAsync(CancellationToken cancellationToken = default);
        Task UpdateSaleAsync(Sale sale);
        Task CancelSaleAsync(Guid id);
        Task DeleteSaleAsync(Guid id);
    }
}