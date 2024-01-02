﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Domain.Entities
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public Guid ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Unit { get; set; }
        public double Qty { get; set; }
        public double SellingPrice { get; set; }
        public double TotalSales { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateUpdated { get; set; }
    }
}
