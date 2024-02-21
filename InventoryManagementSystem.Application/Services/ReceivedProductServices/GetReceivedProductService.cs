using AutoMapper;
using InventoryManagementSystem.Application.Interface.Repository;
using InventoryManagementSystem.Application.Models;
using InventoryManagementSystem.Application.Services.ReceivedProductServices.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.Services.ReceivedProductServices
{
    public class GetReceivedProductService : IGetReceivedProductService
    {
        private readonly IReceivedProductRepository _receivedProductRepository;
        private readonly IMapper _mapper;
        public GetReceivedProductService(IReceivedProductRepository receivedProductRepository, IMapper mapper)
        {
            _receivedProductRepository = receivedProductRepository;
            _mapper = mapper;
        }
        public async Task<GetReceivedProductResponse> Get(Guid code, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _receivedProductRepository.Get(code, cancellationToken);
                var mappedProduct = _mapper.Map<GetReceivedProductResponse>(result);
                return mappedProduct;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<List<GetAllReceivedProductResponse>> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                var result = await _receivedProductRepository.GetAll(cancellationToken);
                var mappedProduct = _mapper.Map<List<GetAllReceivedProductResponse>>(result);
                return mappedProduct;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
