using AutoMapper;
using InventoryManagementSystem.Application.Interface.Repository;
using InventoryManagementSystem.Application.Models;
using InventoryManagementSystem.Application.Services.Interface;
using InventoryManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.Services
{
    public class StocksService : IStocksService
    {
        private readonly IStockInventoryRepository _stockInventoryRepository;
        private readonly IMapper _mapper;
        public StocksService(IStockInventoryRepository stockInventoryRepository, IMapper mapper)
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

        public void Delete(StockInventoryModel entity)
        {
            try
            {
                var StockInventory = MappedStockInventory(entity);
                _stockInventoryRepository.Delete(StockInventory);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public Task<bool> DeleteById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<StockInventoryModel> Get(Guid code, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<object> GetAll(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Update(StockInventoryModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateStocksByReceivedQty(UpdateReceivedQtyModel qtyModel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateStocksBySalesQty(UpdateSaleQtyModel qtyModel)
        {
            throw new NotImplementedException();
        }
    }
}
