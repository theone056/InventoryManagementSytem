using InventoryManagementSystem.Core.Domain.Interface.Repository;
using InventoryManagementSystem.Core.Domain.Entities;
using InventoryManagementSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Infrastructure.Repositories
{
    public class SalesRepository : BaseRepository<Sale>, ISalesRepository
    {
        private readonly IMSDbContext _context;
        public SalesRepository(IMSDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddSales(List<Sale> sales)
        {
            await _context.Sales.AddRangeAsync(sales);

            foreach (var sale in sales)
            {
                var product = _context.Stocks.FirstOrDefault(x => x.ProductCode == sale.ProductCode);
                product.SalesQty += sale.Qty;
                product.StockQty -= sale.Qty;
                product.TotalSales += sale.TotalSales;
            }

            await _context.SaveChangesAsync();
        }

        public Task<Sale> Get(Guid code, CancellationToken cancellationToken)
        {
            return _context.Sales.FirstOrDefaultAsync(x => x.ProductCode == code, cancellationToken);
        }

        public Task<List<Sale>> GetAll(CancellationToken cancellationToken)
        {
           return _context.Sales.Include(x=>x.Product).ToListAsync(cancellationToken);
        }
    }
}
