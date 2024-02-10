using System.Text.Json.Serialization;

namespace InventoryManagementSytem.Services.Model
{
    public class StockModel
    {
        [JsonPropertyName("productName")]
        public string ProductName { get; set; }
        [JsonPropertyName("unit")]
        public string Unit { get; set; }
        [JsonPropertyName("receivedQty")]
        public double ReceivedQty { get; set; }
        [JsonPropertyName("salesQty")]
        public double SalesQty { get; set; }
        [JsonPropertyName("stockQty")]
        public double StockQty { get; set; }
        [JsonPropertyName("sellingPrice")]
        public double SellingPrice { get; set; }
        [JsonPropertyName("totalSales")]
        public double TotalSales { get; set; }
    }
}
