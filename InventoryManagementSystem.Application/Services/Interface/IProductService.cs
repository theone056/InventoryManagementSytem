using InventoryManagementSystem.Application.Models;
using InventoryManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.Services.Interface
{
    public interface IProductService: IBaseService<ProductModel>
    {
        Task<ProductModel> Get(Guid code, CancellationToken cancellationToken);
        Task<List<ProductModel>> GetAll(CancellationToken cancellationToken);
        Task<bool> IsProductNameExist(string ProductName, CancellationToken cancellationToken);
        Task<bool> Delete(string ProductName, CancellationToken cancellationToken);
        ItemCountModel GetCount();
        List<KeyValueModel> GetProductNames();
        bool Upsert(ProductModel productModel, CancellationToken cancellationToken);
    }
}
