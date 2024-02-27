using AutoMapper;
using InventoryManagementSystem.Application.Interface.Repository;
using InventoryManagementSystem.Application.Models;
using InventoryManagementSystem.Application.Services.SalesServices.Interface;
using InventoryManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.Services.SalesServices
{
    public class UpdateSalesService : IUpdateSalesService
    {
        private readonly ISalesRepository _salesRepository;
        private readonly IMapper _mapper;
        public UpdateSalesService(ISalesRepository salesRepository, IMapper mapper)
        {
            _salesRepository = salesRepository;
            _mapper = mapper;
        }
        public void Update(SalesModel entity, CancellationToken cancellationToken)
        {
            try
            {
                Sale sale = MappedSalesModel(entity);
                var salesResult = _salesRepository.Get(sale.ProductCode, cancellationToken).Result;
                if (salesResult != null)
                {
                    _salesRepository.Update(sale);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private Sale MappedSalesModel(SalesModel entity)
        {
            return _mapper.Map<Sale>(entity);
        }



    }
}
