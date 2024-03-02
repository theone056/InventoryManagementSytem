using InventoryManagementSystem.Core.Services.ProductServices.Interface;
using InventoryManagementSystem.Core.Domain.Interface.Repository;

namespace InventoryManagementSystem.Core.Services.ProductServices
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
