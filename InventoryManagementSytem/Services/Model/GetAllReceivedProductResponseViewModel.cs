﻿using System.ComponentModel;
using System.Text.Json.Serialization;

namespace InventoryManagementSytem.Services.Model
{
    public class GetAllReceivedProductResponseViewModel
    {
        [JsonPropertyName("id")]
        [DisplayName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("dateReceived")]
        [DisplayName("Date")]
        public DateTime DateReceived { get; set; }

        [DisplayName("Quantity")]
        [JsonPropertyName("qty")]
        public double Qty { get; set; }

        [DisplayName("Product Code")]
        [JsonPropertyName("productCode")]
        public Guid ProductCode { get; set; }

        [DisplayName("Encoded By")]
        [JsonPropertyName("encodedBy")]
        public string EncodedBy { get; set; }
        [JsonPropertyName("dateCreated")]
        public DateTimeOffset DateCreated { get; set; }
        [JsonPropertyName("dateUpdated")]
        public DateTimeOffset? DateUpdated { get; set; } = DateTimeOffset.Now;
        [JsonPropertyName("productName")]
        public string ProductName { get; set; }
        [JsonPropertyName("unit")]
        public string Unit { get; set; }
        [JsonPropertyName("price")]
        public double Price { get; set; }
    }
}
