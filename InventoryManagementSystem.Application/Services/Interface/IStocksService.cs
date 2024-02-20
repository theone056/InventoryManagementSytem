﻿using InventoryManagementSystem.Application.Models;
using InventoryManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.Services.Interface
{
    public interface IStocksService:IBaseService<StockInventoryModel>
    {
        Task<StockInventoryModel> Get(Guid code, CancellationToken cancellationToken);
        Task<object> GetAll(CancellationToken cancellationToken);
        Task<bool> UpdateStocksByReceivedQty(UpdateReceivedQtyModel qtyModel);
        Task<bool> UpdateStocksBySalesQty(UpdateSaleQtyModel qtyModel);
        Task<bool> DeleteById(Guid id);
    }
}
