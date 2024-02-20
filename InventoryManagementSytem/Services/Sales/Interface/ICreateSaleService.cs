using InventoryManagementSytem.Services.Model;

namespace InventoryManagementSytem.Services.Sales.Interface
{
    public interface ICreateSaleService
    {
        Task<bool> Create(List<SalesModel> product);
    }
}
