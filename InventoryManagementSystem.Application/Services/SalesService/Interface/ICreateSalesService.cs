using InventoryManagementSystem.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.Services.SalesService.Interface
{
    public interface ICreateSalesService
    {
        Task AddSales(List<SalesModel> sales);
    }
}
