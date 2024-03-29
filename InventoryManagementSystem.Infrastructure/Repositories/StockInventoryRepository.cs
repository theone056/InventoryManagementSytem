﻿using InventoryManagementSystem.Core.Domain.Entities;
using InventoryManagementSystem.Core.Domain.Interface.Repository;
using InventoryManagementSystem.Core.Models;
using InventoryManagementSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Infrastructure.Repositories
{
    public class StockInventoryRepository : BaseRepository<StockInventory>, IStockInventoryRepository
    {
        private readonly IMSDbContext _context;
        public StockInventoryRepository(IMSDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> DeleteById(Guid id)
        {
            var result = await _context.Stocks.FirstOrDefaultAsync(x=>x.ProductCode == id);
            if(result != null)
            {
                _context.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<StockInventory> Get(Guid code, CancellationToken cancellationToken)
        {
            return await _context.Stocks.FirstOrDefaultAsync(x=>x.ProductCode == code, cancellationToken);
        }

        public async Task<List<GetAllStockInventoryResponse>> GetAll(CancellationToken cancellationToken)
        {
            var result =  await _context
                                        .Stocks
                                        .Include(x=>x.Product)
                                        .Select(x=> new GetAllStockInventoryResponse
                                                    { 
                                                       ProductName = x.Product.ProductName, 
                                                        Unit = x.Product.Unit, 
                                                        ReceivedQty = x.ReceivedQty, 
                                                        SalesQty = x.SalesQty, 
                                                        StockQty = x.StockQty, 
                                                         SellingPrice = x.Product.Price,
                                                        TotalSales = x.TotalSales  
                                        }).ToListAsync(cancellationToken);

            return result;

        }

        public async Task<bool> UpdateStocksByReceivedQty(UpdateReceivedQtyModel qtyModel)
        {
            try
            {
                var result = _context.Stocks.FirstOrDefault(x=>x.ProductCode == qtyModel.ProductCode);

                if (result != null)
                {
                    result.ReceivedQty += qtyModel.ReceivedQty;
                    result.StockQty = result.ReceivedQty - result.SalesQty;
                    result.DateUpdated = DateTime.UtcNow;
                    await _context.SaveChangesAsync();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
          
        }

        public async Task<bool> UpdateStocksBySalesQty(UpdateSaleQtyModel qtyModel)
        {
            var result = await _context.Stocks.FirstOrDefaultAsync(x => x.ProductCode == qtyModel.ProductCode);
            if (result != null)
            {
                result.SalesQty += qtyModel.SalesQty;
                result.StockQty = result.ReceivedQty - result.SalesQty;
                result.DateUpdated = DateTime.UtcNow;
                _context.SaveChanges();
                return true;
            }
            else 
            { 
                return false; 
            }
        }
    }
}
