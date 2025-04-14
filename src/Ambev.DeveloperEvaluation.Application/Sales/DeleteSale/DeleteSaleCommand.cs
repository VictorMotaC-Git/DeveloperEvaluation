using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale
{
    public class DeleteSaleCommand : IRequest<DeleteSaleResult>
    {
        public Guid Id;

        public DeleteSaleCommand(Guid id) => Id = id;
    }
}
