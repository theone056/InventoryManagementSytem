using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.Models
{
    public class ItemCountModel
    {
        public int ProductCount { get; set; }
        public int SalesCount { get; set; }
        public int ReceivedProductCount { get; set; }
        public int StockCount { get; set; }
    }
}
