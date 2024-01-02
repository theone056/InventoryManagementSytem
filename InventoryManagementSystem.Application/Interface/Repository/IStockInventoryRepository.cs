using InventoryManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.Interface.Repository
{
    public interface IStockInventoryRepository:IBaseRepository<StockInventory>
    {
        Task<StockInventory> Get(Guid code, CancellationToken cancellationToken);
        Task<List<StockInventory>> GetAll(CancellationToken cancellationToken);
    }
}
