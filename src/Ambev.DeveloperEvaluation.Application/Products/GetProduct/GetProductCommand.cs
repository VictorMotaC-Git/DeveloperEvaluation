using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct
{
    public class GetProductCommand : IRequest<GetProductResult>
    {
        public Guid id;

        public GetProductCommand(Guid id)
        {
            this.id = id;
        }
    }
}
