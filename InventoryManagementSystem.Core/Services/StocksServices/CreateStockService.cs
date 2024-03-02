using AutoMapper;
using InventoryManagementSystem.Core.Domain.Entities;
using InventoryManagementSystem.Core.Domain.Interface.Repository;
using InventoryManagementSystem.Core.Models;
using InventoryManagementSystem.Core.Services.StocksServices.Interface;

namespace InventoryManagementSystem.Core.Services.StocksServices
{
    public class CreateStockService : ICreateStockService
    {
        private readonly IStockInventoryRepository _stockInventoryRepository;
        private readonly IMapper _mapper;
        public CreateStockService(IStockInventoryRepository stockInventoryRepository, IMapper mapper)
        {
            _stockInventoryRepository = stockInventoryRepository;
            _mapper = mapper;   
        }

        public void Create(StockInventoryModel entity)
        {
            try
            {
                StockInventory mappedProduct = MappedStockInventory(entity);
                _stockInventoryRepository.Create(mappedProduct);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private StockInventory MappedStockInventory(StockInventoryModel entity)
        {
            return _mapper.Map<StockInventory>(entity);
        }
    }
}
