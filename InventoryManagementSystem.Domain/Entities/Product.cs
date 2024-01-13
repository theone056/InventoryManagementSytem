using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Domain.Entities
{
    public class Product
    {
        [Key]
        public Guid Code { get; set; }
        [StringLength(50)]
        public string ProductName { get; set; }
        [StringLength(10)]
        public string Unit { get; set; }
        public double Price { get; set; }
        public string? Remarks { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateUpdated { get; set; }
        public ICollection<ReceivedProduct>? ReceivedProduct { get; set; }
    }
}
