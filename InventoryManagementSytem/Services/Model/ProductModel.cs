using InventoryManagementSytem.Services.Model;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace InventoryManagementSytem.Services.Models
{
    public class ProductModel
    {
        [JsonPropertyName("code")]
        public Guid Code { get; set; }

        [Required]
        [DisplayName("Product Name")]
        [JsonPropertyName("productName")]
        public string ProductName { get; set; }

        [Required]
        [DisplayName("Unit")]
        [JsonPropertyName("unit")]
        public string Unit { get; set; }

        [Required]
        [DisplayName("Price")]
        [JsonPropertyName("price")]
        public double Price { get; set; }

        [DisplayName("Remarks")]
        [JsonPropertyName("remarks")]
        public string? Remarks { get; set; }
        [DisplayName("Stock")]
        [JsonPropertyName("maxStock")]
        public double MaxStock { get; set; }
    }
}
