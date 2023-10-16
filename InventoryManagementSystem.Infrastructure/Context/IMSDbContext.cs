using InventoryManagementSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Infrastructure.Context
{
    public class IMSDbContext : IdentityDbContext<User>
    {
        public IMSDbContext(DbContextOptions option) :base(option)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public virtual DbSet<UserRefreshTokens> UserRefreshTokens { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<StockInventory> Stocks { get; set; }
        public virtual DbSet<ReceivedProduct> ReceivedProducts { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
    }
}
