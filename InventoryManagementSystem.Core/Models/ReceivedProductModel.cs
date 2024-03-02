using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Core.Models
{
    public class ReceivedProductModel
    {
        public int Id { get; set; }
        public DateTime DateReceived { get; set; }
        public double Qty { get; set; }
        public string EncodedBy { get; set; }
        public DateTimeOffset DateCreated { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset? DateUpdated { get; set; } = DateTimeOffset.Now;
        public Guid ProductCode { get; set; }
    }
}
