using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.Services.ProductServices.Interface
{
    public interface IDeleteProductService
    {
        Task<bool> Delete(string ProductName, CancellationToken cancellationToken);
    }
}
