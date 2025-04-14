using Ambev.DeveloperEvaluation.Domain.Entities;

public class SaleItemFactory : ISaleItemFactory
{
    public SaleItem Create(Guid productId, int quantity, decimal unitPrice)
    {
        if (quantity > 20)
            throw new ArgumentException("Não é permitido vender mais de 20 unidades.");

        var discount = CalculateDiscount(quantity, unitPrice);
        return new SaleItem(productId, quantity, unitPrice, discount = 0);
    }

    private decimal CalculateDiscount(int quantity, decimal unitPrice)
    {
        var total = quantity * unitPrice;

        if (quantity >= 10 && quantity <= 20)
            return total * 0.20m;

        if (quantity >= 4 && quantity < 10)
            return total * 0.10m;

        return 0m;
    }
}
