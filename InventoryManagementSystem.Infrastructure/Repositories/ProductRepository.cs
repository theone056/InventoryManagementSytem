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
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly IMSDbContext _context;
        public ProductRepository(IMSDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<Product> Get(Guid code, CancellationToken cancellationToken)
        {
            return _context.Products.FirstOrDefaultAsync(x => x.Code == code, cancellationToken);
        }

        public Task<List<Product>> GetAll(CancellationToken cancellationToken)
        {
            return _context.Products.ToListAsync(cancellationToken);
        }
    }
}
