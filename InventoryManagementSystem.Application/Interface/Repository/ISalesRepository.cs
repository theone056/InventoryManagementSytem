using InventoryManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.Interface.Repository
{
    public interface ISalesRepository:IBaseRepository<Sale>
    {
        Task<Sale> Get(Guid code, CancellationToken cancellationToken);
        Task<List<Sale>> GetAll(CancellationToken cancellationToken);
    }
}
