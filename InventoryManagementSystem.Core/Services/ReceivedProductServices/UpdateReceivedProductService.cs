﻿using AutoMapper;
using InventoryManagementSystem.Core.Domain.Interface.Repository;
using InventoryManagementSystem.Core.Models;
using InventoryManagementSystem.Core.Services.ReceivedProductServices.Interface;
using InventoryManagementSystem.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Core.Services.ReceivedProductServices
{
    public class UpdateReceivedProductService : IUpdateReceivedProductService
    {
        private readonly IReceivedProductRepository _receivedProductRepository;
        private readonly IMapper _mapper;
        public UpdateReceivedProductService(IReceivedProductRepository receivedProductRepository, IMapper mapper)
        {
            _receivedProductRepository = receivedProductRepository;
            _mapper = mapper;
        }
        public void Update(ReceivedProductModel entity, CancellationToken cancellationToken)
        {
            try
            {
                var receivedProductResult = _receivedProductRepository.Get(entity.ProductCode, cancellationToken).Result;
                if (receivedProductResult != null)
                {
                    var product = MappedReceivedProductModel(entity);
                    _receivedProductRepository.Update(product);
                }
            }
            catch (Exception ex)
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
            catch (Exception ex)
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
