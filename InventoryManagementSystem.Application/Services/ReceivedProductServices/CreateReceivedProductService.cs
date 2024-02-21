using AutoMapper;
using InventoryManagementSystem.Application.Interface.Repository;
using InventoryManagementSystem.Application.Models;
using InventoryManagementSystem.Application.Services.ReceivedProductServices.Interface;
using InventoryManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.Services.ReceivedProductServices
{
    public class CreateReceivedProductService : ICreateReceivedProductService
    {
        private readonly IReceivedProductRepository _receivedProductRepository;
        private readonly IStockInventoryRepository _stockInventoryRepository;
        private readonly IMapper _mapper;
        public CreateReceivedProductService(IReceivedProductRepository receivedProductRepository, IStockInventoryRepository stockInventoryRepository, IMapper mapper)
        {
            _receivedProductRepository = receivedProductRepository;
            _stockInventoryRepository = stockInventoryRepository;
            _mapper = mapper;
        }
        public void Create(ReceivedProductModel entity)
        {
            try
            {
                ReceivedProduct product = MappedReceivedProductModel(entity);
                _receivedProductRepository.Create(product);
                var result = _stockInventoryRepository.UpdateStocksByReceivedQty(new UpdateReceivedQtyModel()
                {
                    ProductCode = entity.ProductCode,
                    ReceivedQty = entity.Qty
                }).Result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private ReceivedProduct MappedReceivedProductModel(ReceivedProductModel entity)
        {
            return _mapper.Map<ReceivedProduct>(entity);
        }
    }
}
