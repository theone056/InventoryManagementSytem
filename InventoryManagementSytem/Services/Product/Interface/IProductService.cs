using InventoryManagementSytem.Services.Model;
using InventoryManagementSytem.Services.Models;

namespace InventoryManagementSytem.Services.Product.Interface
{
    public interface IProductService
    {
        Task<List<ProductModel>> GetAll();

        Task<ProductModel> GetProduct(Guid guid);

        Task<bool> Create(ProductModel product);

        Task<bool> Upsert(ProductModel product);

        Task<bool> Delete(string productName);

        Task<List<ProductNamesModel>> GetAllNames();
    }
}
