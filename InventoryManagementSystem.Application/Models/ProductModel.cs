using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.Models
{
    public class ProductModel
    {
        public Guid Code { get; set; }
        public string ProductName { get; set; }
        public string Unit { get; set; }
        public double Cost { get; set; }
        public double Price { get; set; }
        public string? Remarks { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateUpdated { get; set; } = DateTimeOffset.Now;
    }
}
