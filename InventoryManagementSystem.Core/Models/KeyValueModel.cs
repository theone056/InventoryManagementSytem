using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Core.Models
{
    public class KeyValueModel
    {
        public Guid Id { get; set; }
        public string Val { get; set; }
        public double StockQty { get; set; }
    }
}
