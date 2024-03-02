using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagementSystem.Core.Domain.Entities
{
    public class ReceivedProduct
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateReceived { get; set; }
        public double SellingPrice { get; set; }
        public double Qty { get; set; }
        [StringLength(50)]
        public string EncodedBy { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateUpdated { get; set; }
        [ForeignKey("ProductCode")]
        public Guid ProductCode { get; set; }
        public Product? Product { get; set; }
    }
}
