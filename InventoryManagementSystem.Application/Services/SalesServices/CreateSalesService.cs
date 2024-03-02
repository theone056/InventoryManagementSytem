using AutoMapper;
using InventoryManagementSystem.Domain.Interface.Repository;
using InventoryManagementSystem.Application.Models;
using InventoryManagementSystem.Application.Services.SalesServices.Interface;
using InventoryManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.Services.SalesServices
{
    public class CreateSalesService : ICreateSalesService
    {
        private readonly ISalesRepository _salesRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public CreateSalesService(ISalesRepository salesRepository, 
                                  IProductRepository productRepository,   
                                  IMapper mapper)
        {
            _salesRepository = salesRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task AddSales(List<SalesModel> sales)
        {
            var salesList = _mapper.Map<List<Sale>>(sales);
            await _salesRepository.AddSales(salesList);
        }

        public void Create(SalesModel sales)
        {
            try
            {
                var salesModel = _mapper.Map<Sale>(sales);
                _salesRepository.Create(salesModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
