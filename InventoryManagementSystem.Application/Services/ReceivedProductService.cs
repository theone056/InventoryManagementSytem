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
    public class ReceivedProductService : IReceivedProductService
    {
        private readonly IReceivedProductRepository _receivedProductRepository;
        private readonly IMapper _mapper;
        public ReceivedProductService(IReceivedProductRepository receivedProductRepository, IMapper mapper)
        {
            _receivedProductRepository = receivedProductRepository;
            _mapper = mapper;
        }

        public void Create(ReceivedProductModel entity)
        {
            try
            {
                ReceivedProduct product = MappedReceivedProductModel(entity);
                _receivedProductRepository.Create(product);
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

        public void Delete(ReceivedProductModel entity)
        {
            try
            {
                var product = MappedReceivedProductModel(entity);
                _receivedProductRepository.Delete(product);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<ReceivedProductModel> Get(Guid code, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _receivedProductRepository.Get(code, cancellationToken);
                var mappedProduct = _mapper.Map<ReceivedProductModel>(result);
                return mappedProduct;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<List<ReceivedProductModel>> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                var result = await _receivedProductRepository.GetAll(cancellationToken);
                var mappedProduct = _mapper.Map<List<ReceivedProductModel>>(result);
                return mappedProduct;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void Update(ReceivedProductModel entity)
        {
            try
            {
                var product = MappedReceivedProductModel(entity);
                _receivedProductRepository.Update(product);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void UpdateQuantity(ReceivedProductModel product, CancellationToken cancellationToken)
        {
            try
            {
                var mappedProduct = MappedReceivedProductModel(product);
                _receivedProductRepository.UpdateQuantity(mappedProduct, cancellationToken);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void Upsert(ReceivedProductModel product, CancellationToken cancellationToken)
        {
            try
            {
                var mappedProduct = MappedReceivedProductModel(product);
                _receivedProductRepository.Upsert(mappedProduct, cancellationToken);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
