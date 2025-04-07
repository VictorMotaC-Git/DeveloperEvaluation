using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sale : BaseEntity, ISale
    {
        public Guid Id { get; private set; }
        public int SaleNumber { get; private set; }
        public DateTime SaleDate { get; private set; }
        public Guid CustomerId { get; private set; }
        //public decimal TotalAmount => Items.Sum(item => item.TotalPrice);
        public Guid BranchId { get; private set; }
        public bool IsCancelled { get; private set; }
        //public IReadOnlyCollection<ISaleItem> Items => _items.AsReadOnly();
        //public ICollection<SaleItem> Items { get; set; } = new List<SaleItem>();


        public readonly List<ISaleItem> _items = new();

        public Sale(int saleNumber, Guid customerId, Guid branchId)
        {
            Id = Guid.NewGuid();
            SaleNumber = saleNumber;
            SaleDate = DateTime.UtcNow;
            CustomerId = customerId;
            BranchId = branchId;
            IsCancelled = false;
        }

        public void AddItem(ISaleItem item)
        {
            if (IsCancelled)
                throw new InvalidOperationException("Cannot add item to a cancelled sale.");

            _items.Add(item);
        }

        public void RemoveItem(Guid itemId)
        {
            var item = _items.FirstOrDefault(i => i.Id == itemId);
            if (item != null)
            {
                _items.Remove(item);
            }
        }

        public void CancelSale()
        {
            IsCancelled = true;
            foreach (var item in _items)
            {
                item.CancelItem();
            }
        }
    }
}
