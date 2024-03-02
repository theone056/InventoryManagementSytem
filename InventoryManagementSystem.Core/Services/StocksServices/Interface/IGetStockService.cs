using InventoryManagementSystem.Core.Models;

namespace InventoryManagementSystem.Core.Services.StocksServices.Interface
{
    public interface IGetStockService
    {
        Task<GetStockInventoryResponse> Get(Guid code, CancellationToken cancellationToken);
        Task<List<GetAllStockInventoryResponse>> GetAll(CancellationToken cancellationToken);
    }
}
