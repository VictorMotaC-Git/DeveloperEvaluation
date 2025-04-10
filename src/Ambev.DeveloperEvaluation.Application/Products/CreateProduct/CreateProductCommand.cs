using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

public record CreateProductCommand(string Name, decimal Price) : IRequest<CreateProductResult>;

public record CreateProductResult(Guid Id);
