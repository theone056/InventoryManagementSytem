using InventoryManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Core.Services.ReceivedProductServices.Interface
{
    public interface IGetReceivedProductService
    {
        Task<GetReceivedProductResponse> Get(Guid code, CancellationToken cancellationToken);
        Task<List<GetAllReceivedProductResponse>> GetAll(CancellationToken cancellationToken);
    }
}
