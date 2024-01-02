using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSytem.Services.Models
{
    public class ProductModel
    {
        public Guid code { get; set; }

        [Required]
        [DisplayName("Product Name")]
        public string productName { get; set; }

        [Required]
        [DisplayName("Unit")]
        public string unit { get; set; }

        [Required]
        [DisplayName("Cost")]
        public double cost { get; set; }

        [Required]
        [DisplayName("Selling Price")]
        public double sellingPrice { get; set; }

        [DisplayName("Remarks")]
        public string? remarks { get; set; }

        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateUpdated { get; set; } = DateTimeOffset.Now;
    }
}
