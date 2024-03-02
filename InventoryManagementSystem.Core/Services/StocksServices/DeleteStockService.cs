using InventoryManagementSystem.Core.Services.StocksServices.Interface;
using InventoryManagementSystem.Core.Domain.Interface.Repository;

namespace InventoryManagementSystem.Core.Services.StocksServices
{
    public class DeleteStockService : IDeleteStockService
    {
        private readonly IStockInventoryRepository _stockInventoryRepository;
        public DeleteStockService(IStockInventoryRepository stockInventoryRepository)
        {
            _stockInventoryRepository = stockInventoryRepository;
        }

        public async Task<bool> DeleteById(Guid id)
        {
            try
            {
                var result = await _stockInventoryRepository.DeleteById(id);
                return result;
            }
            catch (Exception ex) { 
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
