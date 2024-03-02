using AutoMapper;
using InventoryManagementSystem.Domain.Interface.Repository;
using InventoryManagementSystem.Application.Models;
using InventoryManagementSystem.Application.Services.SalesServices.Interface;
using InventoryManagementSystem.Application.Services.StocksServices.Interface;
using InventoryManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.Services.StocksServices
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
