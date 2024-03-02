using InventoryManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Core.Services.ReceivedProductServices.Interface
{
    public interface IDeleteReceivedProductService
    {
        void Delete(ReceivedProductModel receivedProduct, CancellationToken cancellationToken);
    }
}
