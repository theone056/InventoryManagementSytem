using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Domain.Entities
{
    public class ItemCount
    {
        public int ProductCount { get; set; }
        public int SalesCount { get; set; }
        public int ReceivedProductCount { get; set; }
        public int StockCount { get; set; }
    }
}
