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
    public class DeleteReceivedProductService : IDeleteReceivedProductService
    {
        private readonly IReceivedProductRepository _receivedProductRepository;
        private readonly IMapper _mapper;
        public DeleteReceivedProductService(IReceivedProductRepository receivedProductRepository, IMapper mapper)
        {
            _receivedProductRepository = receivedProductRepository;
            _mapper = mapper;
        }
        private ReceivedProduct MappedReceivedProductModel(ReceivedProductModel entity)
        {
            return _mapper.Map<ReceivedProduct>(entity);
        }

        public void Delete(ReceivedProductModel entity, CancellationToken cancellationToken)
        {
            try
            {
                var receivedProductResult = _receivedProductRepository.Get(entity.ProductCode, cancellationToken).Result;
                if (receivedProductResult != null)
                {
                    var product = MappedReceivedProductModel(entity);
                    _receivedProductRepository.Delete(product);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
