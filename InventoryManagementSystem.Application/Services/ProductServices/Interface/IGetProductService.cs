using InventoryManagementSystem.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.Services.ProductServices.Interface
{
    public interface IGetProductService
    {
        Task<GetProductResponse> Get(Guid code, CancellationToken cancellationToken);
        Task<List<GetAllProductResponse>> GetAll(CancellationToken cancellationToken);
        Task<bool> IsProductNameExist(string ProductName, CancellationToken cancellationToken);
        ItemCountModel GetCount();
        List<KeyValueModel> GetProductNames();
        List<KeyValueModel> GetAvailableProducts();
    }
}
