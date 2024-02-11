using InventoryManagementSystem.Application.Models;
using InventoryManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.Services.Interface
{
    public interface IReceivedProductService:IBaseService<ReceivedProductModel>
    {
        Task<ReceivedProductModel> Get(Guid code, CancellationToken cancellationToken);
        Task<List<ReceivedProductModel>> GetAll(CancellationToken cancellationToken);
        void Upsert(ReceivedProductModel product, CancellationToken cancellationToken);
        void UpdateQuantity(ReceivedProductModel product, CancellationToken cancellationToken);
    }
}
