using AutoMapper;
using InventoryManagementSystem.Core.Domain.Interface.Repository;
using InventoryManagementSystem.Core.Models;
using InventoryManagementSystem.Core.Services.SalesServices.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Core.Services.SalesServices
{
    public class GetSalesService : IGetSalesService
    {
        private readonly ISalesRepository _salesRepository;
        private readonly IMapper _mapper;
        public GetSalesService(ISalesRepository salesRepository, IMapper mapper)
        {
            _salesRepository = salesRepository;
            _mapper = mapper;
        }
        public async Task<GetSalesResponse> Get(Guid code, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _salesRepository.Get(code, cancellationToken);
                var mappedResult = _mapper.Map<GetSalesResponse>(result);
                return mappedResult;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<List<GetAllSalesResponse>> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                var result = await _salesRepository.GetAll(cancellationToken);
                var mappedResult = _mapper.Map<List<GetAllSalesResponse>>(result);
                return mappedResult;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
