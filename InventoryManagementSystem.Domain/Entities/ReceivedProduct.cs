using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Domain.Entities
{
    public class ReceivedProduct
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateReceived { get; set; }
        public Guid ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Unit { get; set; }
        public double Qty { get; set; }
        public double Cost { get; set; }
        public string EncodedBy { get; set; }
    }
}
