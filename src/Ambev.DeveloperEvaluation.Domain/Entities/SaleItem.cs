using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class SaleItem : BaseEntity, ISaleItem
    {
        public Guid Id { get; private set; }
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal Discount { get; private set; }
        public decimal TotalPrice => (UnitPrice * Quantity) - Discount;
        public bool IsCancelled { get; private set; }

        public SaleItem(Guid productId, int quantity, decimal unitPrice)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.");

            if (quantity > 20)
                throw new ArgumentException("Quantity must not exceed 20 items.");

            if (unitPrice <= 0)
                throw new ArgumentException("Unit price must be greater than zero.");

            Id = Guid.NewGuid();
            ProductId = productId;
            Quantity = quantity;
            UnitPrice = unitPrice;
            Discount = 0;
            IsCancelled = false;

            ApplyDiscount();
        }

        public void ApplyDiscount()
        {
            if (Quantity >= 4 && Quantity < 10)
            {
                Discount = (UnitPrice * Quantity) * 0.10m; // 10% de desconto
            }
            else if (Quantity >= 10 && Quantity <= 20)
            {
                Discount = (UnitPrice * Quantity) * 0.20m; // 20% de desconto
            }
            else
            {
                Discount = 0; // Sem desconto
            }
        }

        public void CancelItem()
        {
            IsCancelled = true;
        }
    }
}
