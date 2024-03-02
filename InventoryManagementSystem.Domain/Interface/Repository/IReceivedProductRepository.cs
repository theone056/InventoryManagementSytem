using InventoryManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Domain.Interface.Repository
{
    public interface IReceivedProductRepository : IBaseRepository<ReceivedProduct>
    {
        Task<ReceivedProduct> Get(Guid code, CancellationToken cancellationToken);
        Task<List<ReceivedProduct>> GetAll(CancellationToken cancellationToken);
        void Upsert(ReceivedProduct product, CancellationToken cancellationToken);
        void UpdateQuantity(ReceivedProduct product, CancellationToken cancellationToken);
        void CreateReceivedProductWithUpdateStock(ReceivedProduct product);
    }
}
