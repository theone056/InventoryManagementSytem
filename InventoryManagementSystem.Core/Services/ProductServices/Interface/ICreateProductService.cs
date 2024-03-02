using InventoryManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Core.Services.ProductServices.Interface
{
    public interface ICreateProductService
    {
        void Create(ProductModel product, CancellationToken cancellationToken);
    }
}
