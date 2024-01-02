using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Domain.Entities
{
    public class Product
    {
        [Key]
        public Guid Code { get; set; }
        public string ProductName { get; set; }
        public string Unit { get; set; }
        public double Cost { get; set; }
        public double SellingPrice { get; set; }
        public string? Remarks { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateUpdated { get; set; }
    }
}
