using System.ComponentModel;
using System.Text.Json.Serialization;

namespace InventoryManagementSytem.Services.Model
{
    public class GetAllSalesResponse
    {
        [JsonPropertyName("id")]
        [DisplayName("Id")]
        public int Id { get; set; }
        [JsonPropertyName("productCode")]
        [DisplayName("Product Code")]
        public Guid ProductCode { get; set; }
        [JsonPropertyName("transactionDate")]
        [DisplayName("Transaction Date")]
        public DateTime TransactionDate { get; set; }
        [JsonPropertyName("productName")]
        [DisplayName("Product Name")]
        public string ProductName { get; set; }
        [JsonPropertyName("price")]
        [DisplayName("Price")]
        public double Price { get; set; }
        [JsonPropertyName("unit")]
        [DisplayName("Unit")]
        public string Unit { get; set; }

        [JsonPropertyName("qty")]
        [DisplayName("Quantity")]
        public double Qty { get; set; }
        [JsonPropertyName("totalSales")]
        [DisplayName("Total Sales")]
        public double TotalSales { get; set; }
        [JsonPropertyName("dateCreated")]
        [DisplayName("Date Created")]
        public DateTimeOffset DateCreated { get; set; }
        [JsonPropertyName("dateUpdated")]
        [DisplayName("Date Updated")]
        public DateTimeOffset? DateUpdated { get; set; }
    }
}
