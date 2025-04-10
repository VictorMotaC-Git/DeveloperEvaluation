using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;

        public SaleService(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<Sale> CreateSaleAsync(Sale sale)
        {
            //sale.ApplyDiscount();
            await _saleRepository.AddAsync(sale);
            return sale;
        }

        public async Task<Sale?> GetSaleByIdAsync(Guid id)
        {
            return await _saleRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Sale>> GetAllSalesAsync(CancellationToken cancellationToken = default)

        {
            return await _saleRepository.GetAllAsync(cancellationToken);
        }

        public async Task UpdateSaleAsync(Sale sale)
        {
            var existingSale = await _saleRepository.GetByIdAsync(sale.Id);
            if (existingSale == null)
                throw new KeyNotFoundException("Sale not found.");

            await _saleRepository.UpdateAsync(existingSale);
        }

        public async Task CancelSaleAsync(Guid id)
        {
            var sale = await _saleRepository.GetByIdAsync(id);
            if (sale == null)
                throw new KeyNotFoundException("Sale not found.");

            sale.CancelSale();
            await _saleRepository.UpdateAsync(sale);
        }

        public async Task DeleteSaleAsync(Guid id)
        {
            await _saleRepository.DeleteAsync(id);
        }
    }
}
