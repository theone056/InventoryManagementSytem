using InventoryManagementSystem.Application.Models;
using InventoryManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.Services.Interface
{
    public interface ISalesService:IBaseService<SalesModel>
    {
        Task<SalesModel> Get(Guid code, CancellationToken cancellationToken);
        Task<List<SalesModel>> GetAll(CancellationToken cancellationToken);
    }
}
