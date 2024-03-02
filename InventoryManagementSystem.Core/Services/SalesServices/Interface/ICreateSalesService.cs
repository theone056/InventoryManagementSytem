using InventoryManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Core.Services.SalesServices.Interface
{
    public interface ICreateSalesService
    {
        Task AddSales(List<SalesModel> sales);
        void Create(SalesModel sales);
    }
}
