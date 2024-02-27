using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.Models
{
    public class GetAllStockInventoryResponse
    {
        public string ProductName { get; set; }
        public string Unit { get; set; }
        public double ReceivedQty { get; set; }
        public double SalesQty { get; set; }
        public double StockQty { get; set; }
        public double SellingPrice { get; set; }
        public double TotalSales { get; set; }
    }
}
