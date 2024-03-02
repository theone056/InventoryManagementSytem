using InventoryManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Core.Services.StocksServices.Interface
{
    public interface ICreateStockService
    {
        void Create(StockInventoryModel model);
    }
}
