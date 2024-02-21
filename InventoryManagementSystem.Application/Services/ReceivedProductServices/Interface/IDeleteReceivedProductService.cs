using InventoryManagementSystem.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.Services.ReceivedProductServices.Interface
{
    public interface IDeleteReceivedProductService
    {
        void Delete(ReceivedProductModel receivedProduct, CancellationToken cancellationToken);
    }
}
