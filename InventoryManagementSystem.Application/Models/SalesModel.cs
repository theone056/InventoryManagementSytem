﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.Models
{
    public class SalesModel
    {
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public Guid ProductCode { get; set; }
        public double Qty { get; set; }
        public double TotalSales { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateUpdated { get; set; } = DateTimeOffset.Now;
    }
}
