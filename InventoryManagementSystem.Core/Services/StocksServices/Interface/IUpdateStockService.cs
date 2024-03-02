using InventoryManagementSystem.Core.Models;

namespace InventoryManagementSystem.Core.Services.StocksServices.Interface
{
    public interface IUpdateStockService
    {
        Task<bool> UpdateStocksByReceivedQty(UpdateReceivedQtyModel qtyModel);
        Task<bool> UpdateStocksBySalesQty(UpdateSaleQtyModel qtyModel);
    }
}
