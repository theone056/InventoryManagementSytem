using System.Text.Json.Serialization;

namespace InventoryManagementSytem.Models
{
    public class IndexViewModel
    {
        [JsonPropertyName("productCount")]
        public int ProductCount { get; set; }
        [JsonPropertyName("stockCount")]
        public int StockCount { get; set; }
        [JsonPropertyName("salesCount")]
        public int SalesCount { get; set; }
        [JsonPropertyName("receivedProductCount")]
        public int ReceivedProductCount { get; set; }
    }
}
