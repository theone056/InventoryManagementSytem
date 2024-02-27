using InventoryManagementSytem.Services.Model;

namespace InventoryManagementSytem.Services.Sales.Interface
{
    public interface IGetSalesService
    {
        Task<List<GetAllSalesResponse>> GetAll();
    }
}
