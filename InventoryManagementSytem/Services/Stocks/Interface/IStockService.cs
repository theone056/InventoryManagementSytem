using InventoryManagementSytem.Services.Model;

namespace InventoryManagementSytem.Services.Stocks.Interface
{
    public interface IStockService
    {
        Task<List<StockModel>> GetAllStock();
    }
}
