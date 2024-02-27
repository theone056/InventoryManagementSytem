using InventoryManagementSystem.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.Services.SalesServices.Interface
{
    public interface IDeleteSalesService
    {
        void Delete(SalesModel sales, CancellationToken cancellationToken);
    }
}
