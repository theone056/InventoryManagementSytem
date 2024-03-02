using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Core.Domain.Entities
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public double SellingPrice { get; set; }
        public double Qty { get; set; }
        public double TotalSales { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateUpdated { get; set; }
        [ForeignKey("ProductCode")]
        public Guid ProductCode { get; set; }
        public Product? Product { get; set; }
    }
}
