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
    public class SalesServices : ISalesService
    {
        private readonly ISalesRepository _salesRepository;
        private readonly IMapper _mapper;
        public SalesServices(ISalesRepository salesRepository, IMapper mapper)
        {
            _salesRepository = salesRepository;
            _mapper = mapper;
        }
        public void Create(SalesModel entity)
        {
            try
            {
                Sale sales = MappedSalesModel(entity);
                _salesRepository.Create(sales);
            }
            catch (Exception ex) { 
                throw new Exception(ex.Message,ex);
            }
        }

        private Sale MappedSalesModel(SalesModel entity)
        {
            return _mapper.Map<Sale>(entity);
        }

        public void Delete(SalesModel entity)
        {
            try
            {
                Sale sale = MappedSalesModel(entity);
                _salesRepository.Delete(sale);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message,ex);
            }
        }

        public async Task<SalesModel> Get(Guid code, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _salesRepository.Get(code, cancellationToken);
                var mappedResult = _mapper.Map<SalesModel>(result);
                return mappedResult;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message,ex);
            }
        }

        public async Task<List<SalesModel>> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                var result = await _salesRepository.GetAll(cancellationToken);
                var mappedResult = _mapper.Map<List<SalesModel>>(result);  
                return mappedResult;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message,ex);
            }
        }

        public void Update(SalesModel entity)
        {
            try
            {
                Sale sale = MappedSalesModel(entity);
                _salesRepository.Update(sale);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message,ex);
            }
        }
    }
}
