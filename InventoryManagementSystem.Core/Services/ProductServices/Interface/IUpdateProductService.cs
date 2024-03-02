using InventoryManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Core.Services.ProductServices.Interface
{
    public interface IUpdateProductService
    {
        bool Upsert(ProductModel productModel, CancellationToken cancellationToken);
        void Update(ProductModel productModel, CancellationToken cancellationToken);
    }
}
