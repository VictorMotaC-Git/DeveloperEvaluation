using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProducts;

public class GetProductsHandler : IRequest<IEnumerable<GetProductResult>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductsHandler(IProductRepository repository)
    {
        _productRepository = repository;
    }

    public async Task<IEnumerable<GetProductResult>> Handle(GetProductCommand request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAllAsync(cancellationToken);
        return products.Select(p => new GetProductResult
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price
        });
    }
}