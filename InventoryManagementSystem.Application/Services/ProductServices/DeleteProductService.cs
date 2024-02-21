using InventoryManagementSystem.Application.Interface.Repository;
using InventoryManagementSystem.Application.Services.ProductServices.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.Services.ProductServices
{
    public class DeleteProductService : IDeleteProductService
    {
        private readonly IProductRepository _productRepository;
        public DeleteProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> Delete(string ProductName, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _productRepository.Delete(ProductName, cancellationToken);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
