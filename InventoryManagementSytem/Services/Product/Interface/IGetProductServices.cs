using InventoryManagementSytem.Services.Model;
using InventoryManagementSytem.Services.Models;

namespace InventoryManagementSytem.Services.Product.Interface
{
    public interface IGetProductServices
    {
        Task<List<ProductModel>> GetAll();

        Task<ProductModel> GetProduct(Guid guid);

        Task<List<ProductNamesModel>> GetAllNames();
    }
}
