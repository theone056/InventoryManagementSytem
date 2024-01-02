using InventoryManagementSystem.Application.Models;
using InventoryManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.Interface.Repository
{
    public interface IProductRepository: IBaseRepository<Product>
    {
        Task<Product> Get(Guid code, CancellationToken cancellationToken);
        Task<List<Product>> GetAll(CancellationToken cancellationToken);
        Task<bool> IsProductNameExist(string ProductName,CancellationToken cancellationToken);
        Task<bool> Delete(string ProductName, CancellationToken cancellationToken);
        ItemCount GetCount();
        List<KeyValue> GetProductNames();
    }
}
