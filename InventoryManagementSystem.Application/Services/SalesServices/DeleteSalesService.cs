using AutoMapper;
using InventoryManagementSystem.Domain.Interface.Repository;
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
    public class DeleteSalesService : IDeleteSalesService
    {
        private readonly ISalesRepository _salesRepository;
        private readonly IMapper _mapper;
        public DeleteSalesService(ISalesRepository salesRepository, IMapper mapper)
        {
            _salesRepository = salesRepository;
            _mapper = mapper;
        }
        public void Delete(SalesModel sales, CancellationToken cancellationToken)
        {
            try
            {
                var salesModel = _mapper.Map<Sale>(sales);
                var salesResult = _salesRepository.Get(salesModel.ProductCode, cancellationToken).Result;
                if (salesResult != null)
                {
                    _salesRepository.Delete(salesModel);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message,ex);
            }
        }
    }
}
