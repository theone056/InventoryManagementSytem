using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Core.Models
{
    public class GetProductResponse
    {
        public Guid Code { get; set; }
        public string ProductName { get; set; }
        public string Unit { get; set; }
        public double Price { get; set; }
        public int MaxStock { get; set; }
        public string? Remarks { get; set; }
    }
}
