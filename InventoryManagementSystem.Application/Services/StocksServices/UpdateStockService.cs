using InventoryManagementSystem.Application.Models;
using InventoryManagementSystem.Application.Services.StocksServices.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.Services.StocksServices
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
