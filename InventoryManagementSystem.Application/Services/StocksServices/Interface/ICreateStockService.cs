using InventoryManagementSystem.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.Services.StocksServices.Interface
{
    public interface ICreateStockService
    {
        void Create(StockInventoryModel model);
    }
}
