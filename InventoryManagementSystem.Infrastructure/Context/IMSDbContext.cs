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
            builder.Entity<ItemCount>().HasNoKey().ToView(null);
            builder.Entity<KeyValue>().HasNoKey().ToView(null);
            builder.Entity<ReceivedProductQuantity>().HasNoKey().ToView(null);
            builder.Entity<Product>()
                .HasMany(c => c.ReceivedProduct)
                .WithOne(c => c.Product)
                .HasForeignKey(c => c.ProductCode);
            base.OnModelCreating(builder);
        }

        public virtual DbSet<UserRefreshTokens> UserRefreshTokens { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<StockInventory> Stocks { get; set; }
        public virtual DbSet<ReceivedProduct> ReceivedProducts { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
    }
}
