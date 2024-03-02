using AutoMapper;
using InventoryManagementSystem.Application.Models;
using InventoryManagementSystem.Application.Services.StocksServices.Interface;
using InventoryManagementSystem.Domain.Interface.Repository;
using InventoryManagementSystem.Domain.Models;

namespace InventoryManagementSystem.Application.Services.StocksServices
{
    public class GetStockService : IGetStockService
    {
        private readonly IStockInventoryRepository _stockInventoryRepository;
        private readonly IMapper _mapper;
        public GetStockService(IStockInventoryRepository stockInventoryRepository, IMapper mapper)
        {
            _stockInventoryRepository = stockInventoryRepository;
            _mapper = mapper;
        }
        public async Task<GetStockInventoryResponse> Get(Guid code, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _stockInventoryRepository.Get(code, cancellationToken);
                var stockResult = _mapper.Map<GetStockInventoryResponse>(result);
                return stockResult;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<List<GetAllStockInventoryResponse>> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                var result = await _stockInventoryRepository.GetAll(cancellationToken);
                var stockResult = _mapper.Map<List<GetAllStockInventoryResponse>>(result);
                return stockResult;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
