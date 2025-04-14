using Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

public class CancelSaleHandler : IRequestHandler<DeleteSaleCommand, DeleteSaleResult>
{
    private readonly ISaleRepository _saleRepository;

    public CancelSaleHandler(ISaleRepository saleRepository)
    {
        _saleRepository = saleRepository;
    }

    public async Task<DeleteSaleResult> Handle(DeleteSaleCommand request, CancellationToken cancellationToken)
    {
        var sale = await _saleRepository.GetByIdAsync(request.Id, cancellationToken);
        if (sale == null)
            throw new KeyNotFoundException("Venda não encontrada.");

        sale.CancelSale();
        await _saleRepository.UpdateAsync(sale, cancellationToken);

        return new DeleteSaleResult
        {
            Id = sale.Id,
            IsCancelled = sale.IsCancelled,
            CancelledAt = DateTime.UtcNow
        };
    }
}
