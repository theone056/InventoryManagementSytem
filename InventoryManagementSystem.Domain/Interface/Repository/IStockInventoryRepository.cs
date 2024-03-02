using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Domain.Models;

namespace InventoryManagementSystem.Domain.Interface.Repository
{
    public interface IStockInventoryRepository:IBaseRepository<StockInventory>
    {
        Task<StockInventory> Get(Guid code, CancellationToken cancellationToken);
        Task<List<GetAllStockInventoryResponse>> GetAll(CancellationToken cancellationToken);
        Task<bool> UpdateStocksByReceivedQty(UpdateReceivedQtyModel qtyModel);
        Task<bool> UpdateStocksBySalesQty(UpdateSaleQtyModel qtyModel);
        Task<bool> DeleteById(Guid id);
    }
}
