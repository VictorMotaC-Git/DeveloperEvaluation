using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;

        public CreateSaleHandler(ISaleRepository saleRepository, IMapper mapper, IPasswordHasher passwordHasher)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }

        public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateSaleCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var existingSale = await _saleRepository.GetByIdAsync(command.Id, cancellationToken);
            if (existingSale != null)
                throw new InvalidOperationException($"Sale with ID {command.Id} already exists");

            var sale = new Sale(
                command.SaleNumber,
                command.CustomerId,
                command.BranchId
            );

            foreach (var item in command.Items)
            {
                if (item.Quantity > 20)
                    throw new ArgumentException("Não é permitido vender mais de 20 unidades de um mesmo item.");

                var saleItem = new SaleItem(item.ProductId, item.Quantity, item.UnitPrice);
                sale.AddItem(saleItem);
            }

            var savedSale = await _saleRepository.AddAsync(sale, cancellationToken);

            // Mapear para o resultado final
            var result = _mapper.Map<CreateSaleResult>(savedSale);
            return result;
        }

    }
}
