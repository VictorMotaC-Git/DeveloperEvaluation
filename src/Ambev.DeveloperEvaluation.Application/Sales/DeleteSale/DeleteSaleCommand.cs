using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale
{
    public class DeleteSaleCommand
    {
        private Guid id;

        public DeleteSaleCommand(Guid id)
        {
            this.id = id;
        }
    }
}
