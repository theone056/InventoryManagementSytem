using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Domain.Models
{
    public class UpdateReceivedQtyModel
    {
        public Guid ProductCode { get; set; }
        public double ReceivedQty { get; set; }
    }
}
