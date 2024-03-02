using InventoryManagementSystem.Application.Models;
using InventoryManagementSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.Services.StocksServices.Interface
{
    public interface IGetStockService
    {
        Task<GetStockInventoryResponse> Get(Guid code, CancellationToken cancellationToken);
        Task<List<GetAllStockInventoryResponse>> GetAll(CancellationToken cancellationToken);
    }
}
