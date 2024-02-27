using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.Services.StocksServices.Interface
{
    public interface IDeleteStockService
    {
        Task<bool> DeleteById(Guid id);
    }
}
