using AutoMapper;
using InventoryManagementSystem.Core.Models;
using InventoryManagementSystem.Core.Services.ReceivedProductServices.Interface;
using InventoryManagementSystem.Core.Domain.Entities;
using InventoryManagementSystem.Core.Domain.Interface.Repository;

namespace InventoryManagementSystem.Core.Services.ReceivedProductServices
{
    public class CreateReceivedProductService : ICreateReceivedProductService
    {
        private readonly IReceivedProductRepository _receivedProductRepository;
        private readonly IMapper _mapper;
        public CreateReceivedProductService(IReceivedProductRepository receivedProductRepository,
                                            IMapper mapper)
        {
            _receivedProductRepository = receivedProductRepository;
            _mapper = mapper;
        }
        public void Create(ReceivedProductModel entity)
        {
            try
            {
                ReceivedProduct receivedproduct = MappedReceivedProductModel(entity);
                _receivedProductRepository.Create(receivedproduct);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void CreateReceivedProductWithUpdateStock(ReceivedProductModel entity)
        {
            try
            {
                ReceivedProduct receivedproduct = MappedReceivedProductModel(entity);
                _receivedProductRepository.CreateReceivedProductWithUpdateStock(receivedproduct);
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
