using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.Models
{
    public class GetStockInventoryResponse
    {
        public int Id { get; set; }
        public Guid ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Unit { get; set; }
        public double ReceivedQty { get; set; }
        public double SalesQty { get; set; }
        public double StockQty { get; set; }
        public double SellingPrice { get; set; }
        public double TotalSales { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateUpdated { get; set; } = DateTimeOffset.Now;
    }
}
