using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

public class Sale : BaseEntity, ISale
{
    public Guid Id { get; private set; }
    public int SaleNumber { get; private set; }
    public DateTime SaleDate { get; private set; }
    public Guid CustomerId { get; private set; }
    public Guid BranchId { get; private set; }
    public bool IsCancelled { get; private set; }

    // Propriedade concreta mapeada pelo EF
    public ICollection<SaleItem> SaleItems { get; private set; } = new List<SaleItem>();

    [NotMapped]
    public ICollection<ISaleItem> Items => SaleItems.Cast<ISaleItem>().ToList();

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

        if (item is SaleItem saleItem)
            SaleItems.Add(saleItem);
    }

    public void CancelSale()
    {
        IsCancelled = true;
        foreach (var item in SaleItems)
        {
            item.CancelItem();
        }
    }

    public void RemoveItem(Guid itemId)
    {
        throw new NotImplementedException();
    }
}
