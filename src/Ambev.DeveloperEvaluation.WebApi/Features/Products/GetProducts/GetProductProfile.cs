using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProducts
{
    public class GetProductProfile : Profile
    {
        public GetProductProfile() 
        {
            CreateMap<Guid, Application.Products.GetProduct.GetProductCommand>().
                ConstructUsing(id => new Application.Products.GetProduct.GetProductCommand(id));

            CreateMap<GetProductResult, GetProductsResponse>();
        }
    }
}
