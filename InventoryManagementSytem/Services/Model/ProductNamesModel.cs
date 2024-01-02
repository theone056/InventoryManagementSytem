using System.Text.Json.Serialization;

namespace InventoryManagementSytem.Services.Model
{
    public class ProductNamesModel
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        [JsonPropertyName("val")]
        public string Val { get; set; }
    }
}
