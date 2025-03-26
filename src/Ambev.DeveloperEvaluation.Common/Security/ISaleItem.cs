using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Common.Security
{
    public interface ISaleItem
    {
        Guid Id { get; }
        Guid ProductId { get; }
        int Quantity { get; }
        decimal UnitPrice { get; }
        decimal Discount { get; }
        decimal TotalPrice { get; }
        bool IsCancelled { get; }

        void ApplyDiscount();
        void CancelItem();
    }
}
