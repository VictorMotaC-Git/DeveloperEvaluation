using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsCommand, IEnumerable<GetProductResult>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductsHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetProductResult>> Handle(GetAllProductsCommand request, CancellationToken cancellationToken)
        {
            var sales = await _productRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<IEnumerable<GetProductResult>>(sales);
        }
    }
}
