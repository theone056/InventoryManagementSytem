using InventoryManagementSystem.Domain.Models;

namespace InventoryManagementSystem.Application.Services.StocksServices.Interface
{
    public interface IUpdateStockService
    {
        Task<bool> UpdateStocksByReceivedQty(UpdateReceivedQtyModel qtyModel);
        Task<bool> UpdateStocksBySalesQty(UpdateSaleQtyModel qtyModel);
    }
}
