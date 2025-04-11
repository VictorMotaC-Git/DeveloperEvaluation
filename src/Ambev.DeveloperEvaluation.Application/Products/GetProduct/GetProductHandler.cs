using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProducts;

public class GetProductsHandler : IRequestHandler<GetProductCommand, GetProductResult>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductsHandler(IProductRepository repository, IMapper mapper)
    {
        _productRepository = repository;
        _mapper = mapper;
    }

    public async Task<GetProductResult> Handle(GetProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.id ,cancellationToken);
        
        if (product == null)
            throw new KeyNotFoundException($"product with ID {request.id} not found");

        return _mapper.Map<GetProductResult>(product);
    }
}