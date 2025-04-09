using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Common.Security
{
    public interface ISale
    {
        Guid Id { get; }
        int SaleNumber { get; }
        DateTime SaleDate { get; }
        Guid CustomerId { get; }
        //decimal TotalAmount { get; }
        Guid BranchId { get; }
        bool IsCancelled { get; }
        ICollection<ISaleItem> Items { get; }

        void AddItem(ISaleItem item);
        void RemoveItem(Guid itemId);
        void CancelSale();
    }
}
