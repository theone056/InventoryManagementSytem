using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.Models
{
    public class GetReceivedProductResponse
    {
        public int Id { get; set; }
        public DateTime DateReceived { get; set; }
        public string ProductName { get; set; }
        public string Unit { get; set; }
        public double Price { get; set; }
        public double Qty { get; set; }
        public string EncodedBy { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateUpdated { get; set; } = DateTimeOffset.Now;
        public Guid ProductCode { get; set; }
    }
}
