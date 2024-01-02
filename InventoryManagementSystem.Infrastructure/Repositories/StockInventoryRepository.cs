using InventoryManagementSystem.Application.Interface.Repository;
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

        public Task<StockInventory> Get(Guid code, CancellationToken cancellationToken)
        {
            return _context.Stocks.FirstOrDefaultAsync(x=>x.ProductCode == code, cancellationToken);
        }

        public Task<List<StockInventory>> GetAll(CancellationToken cancellationToken)
        {
            return _context.Stocks.ToListAsync(cancellationToken);
        }
    }
}
