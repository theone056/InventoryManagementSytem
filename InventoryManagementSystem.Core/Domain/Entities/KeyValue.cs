﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Core.Domain.Entities
{
    public class KeyValue
    {
        public Guid Id { get; set; }
        public string Val { get; set; }
        public double StockQty { get; set; }
    }
}
