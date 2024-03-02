using InventoryManagementSystem.Core.Models;
using InventoryManagementSystem.Core.Services.StocksServices.Interface;

namespace InventoryManagementSystem.Core.Services.StocksServices
{
    public class UpdateStockService : IUpdateStockService
    {
        public Task<bool> UpdateStocksByReceivedQty(UpdateReceivedQtyModel qtyModel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateStocksBySalesQty(UpdateSaleQtyModel qtyModel)
        {
            throw new NotImplementedException();
        }
    }
}
