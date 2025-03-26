using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale
{
    public class GetSaleCommand
    {
        public Guid id;

        public GetSaleCommand(Guid id)
        {
            this.id = id;
        }
    }
}
