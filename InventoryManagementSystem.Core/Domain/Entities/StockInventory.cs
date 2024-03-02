using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Core.Domain.Entities
{
    public class StockInventory
    {
        [Key]
        public int Id { get; set; }
        public double ReceivedQty { get; set; }
        public double SalesQty { get; set; }
        public double StockQty { get; set; }
        public double TotalSales { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateUpdated { get; set; }
        [ForeignKey("ProductCode")]
        public Guid ProductCode { get; set; }
        public Product? Product { get; set; }
    }
}
