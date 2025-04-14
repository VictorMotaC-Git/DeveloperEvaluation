using Ambev.DeveloperEvaluation.Domain.Entities;

public interface ISaleItemFactory
{
    SaleItem Create(Guid productId, int quantity, decimal unitPrice);
}
