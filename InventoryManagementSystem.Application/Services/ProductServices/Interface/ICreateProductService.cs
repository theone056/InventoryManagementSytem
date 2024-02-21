using InventoryManagementSystem.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.Services.ProductServices.Interface
{
    public interface ICreateProductService
    {
        void Create(ProductModel product, CancellationToken cancellationToken);
    }
}
