using InventoryManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.Interface.Repository
{
    public interface IProductRepository
    {
        Task<Product> Get(Guid code, CancellationToken cancellationToken);
        Task<List<Product>> GetAll(CancellationToken cancellationToken);
    }
}
