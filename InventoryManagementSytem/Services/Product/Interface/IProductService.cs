using InventoryManagementSytem.Services.Model;
using InventoryManagementSytem.Services.Models;

namespace InventoryManagementSytem.Services.Product.Interface
{
    public interface IProductService
    {

        Task<bool> Create(ProductModel product);

        Task<bool> Upsert(ProductModel product);
        Task<bool> Update(ProductModel product);

        Task<bool> Delete(string productName);

    }
}
