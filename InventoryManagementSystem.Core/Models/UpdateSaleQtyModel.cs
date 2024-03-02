using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Core.Models
{
    public class UpdateSaleQtyModel
    {
        public Guid ProductCode { get; set; }
        public int SalesQty { get; set; }
    }
}
