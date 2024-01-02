using InventoryManagementSytem.Services.Model;

namespace InventoryManagementSytem.Services.ReceivedProduct.Interface
{
    public interface IReceivedProductService
    {
        Task<bool> Create(ReceivedProductModel product);
        Task<List<ReceivedProductModel>> GetAll();

        Task<ReceivedProductModel> GetProduct(Guid guid);

        Task<bool> Upsert(ReceivedProductModel product);

        Task<bool> Delete(string productName);
    }
}
