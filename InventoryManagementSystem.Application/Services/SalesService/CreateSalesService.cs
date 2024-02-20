using AutoMapper;
using InventoryManagementSystem.Application.Interface.Repository;
using InventoryManagementSystem.Application.Models;
using InventoryManagementSystem.Application.Services.SalesService.Interface;
using InventoryManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.Services.SalesService
{
    public class CreateSalesService : ICreateSalesService
    {
        private readonly ISalesRepository _salesRepository;
        private readonly IMapper _mapper;
        public CreateSalesService(ISalesRepository salesRepository, IMapper mapper)
        {
            _salesRepository = salesRepository;
            _mapper = mapper;
        }
        public async Task AddSales(List<SalesModel> sales)
        {
            var salesList = _mapper.Map<List<Sale>>(sales);
            await _salesRepository.AddSales(salesList);
        }
    }
}
