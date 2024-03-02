using InventoryManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Core.Services.ReceivedProductServices.Interface
{
    public interface IUpdateReceivedProductService
    {
        void Upsert(ReceivedProductModel product, CancellationToken cancellationToken);
        void UpdateQuantity(ReceivedProductModel product, CancellationToken cancellationToken);
        void Update(ReceivedProductModel receivedProduct, CancellationToken cancellationToken);
    }
}
