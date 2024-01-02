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
    public class ReceivedProductRepository : BaseRepository<ReceivedProduct>, IReceivedProductRepository
    {
        private readonly IMSDbContext _context;
        public ReceivedProductRepository(IMSDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<ReceivedProduct> Get(Guid code, CancellationToken cancellationToken)
        {
            return _context.ReceivedProducts.FirstOrDefaultAsync(x=>x.ProductCode == code,cancellationToken);
        }

        public Task<List<ReceivedProduct>> GetAll(CancellationToken cancellationToken)
        {
            return _context.ReceivedProducts.ToListAsync(cancellationToken);
        }
    }
}
