﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Domain.Models
{
    public class UpdateSaleQtyModel
    {
        public Guid ProductCode { get; set; }
        public int SalesQty { get; set; }
    }
}
