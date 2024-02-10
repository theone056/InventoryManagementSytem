using InventoryManagementSystem.Application.Interface.Repository;
using InventoryManagementSystem.Application.Models;
using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var result = await _context.Stocks.FindAsync(id);
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

        public async Task<object> GetAll(CancellationToken cancellationToken)
        {
            var result =  await _context
                                        .Stocks
                                        .Include(x=>x.Product)
                                        .Select(x=> new 
                                                    { 
                                                        x.Product.ProductName, 
                                                        x.Product.Unit, 
                                                        x.ReceivedQty, 
                                                        x.SalesQty, 
                                                        x.StockQty, 
                                                        x.Product.Price,
                                                        x.TotalSales  
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
