using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem.Core.Domain.Entities
{
    public class Product
    {
        [Key]
        public Guid Code { get; set; }
        [StringLength(50)]
        public string ProductName { get; set; }
        [StringLength(10)]
        public string Unit { get; set; }
        public double Price { get; set; }
        public string? Remarks { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateUpdated { get; set; }
        public ICollection<ReceivedProduct>? ReceivedProduct { get; set; }
        public ICollection<Sale> Sales { get; set; }
        public StockInventory Stocks { get; set; }
    }
}
