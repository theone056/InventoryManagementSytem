using System.ComponentModel;
using System.Text.Json.Serialization;

namespace InventoryManagementSytem.Services.Model
{
    public class ReceivedProductModel
    {
        [JsonPropertyName("id")]
        [DisplayName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("dateReceived")]
        [DisplayName("Date")]
        public DateTime DateReceived { get; set; }

        [DisplayName("Product Code")]
        [JsonPropertyName("productCode")]
        public Guid ProductCode { get; set; }

        [DisplayName("Product Name")]
        [JsonPropertyName("productName")]
        public string ProductName { get; set; }

        [DisplayName("Unit")]
        [JsonPropertyName("unit")]
        public string Unit { get; set; }

        [DisplayName("Quantity")]
        [JsonPropertyName("qty")]
        public double Qty { get; set; }

        [DisplayName("Cost")]
        [JsonPropertyName("cost")]
        public double Cost { get; set; }

        [DisplayName("Encoded By")]
        [JsonPropertyName("encodedBy")]
        public string EncodedBy { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateUpdated { get; set; } = DateTimeOffset.Now;
    }
}
