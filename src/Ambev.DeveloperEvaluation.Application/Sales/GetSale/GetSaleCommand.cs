using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale
{
    public class GetSaleCommand : IRequest<GetSaleResult>
    {
        public Guid id;

        public GetSaleCommand(Guid id)
        {
            this.id = id;
        }
    }
}
