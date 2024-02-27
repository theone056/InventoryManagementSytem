using AutoMapper;
using InventoryManagementSystem.Application.Interface.Repository;
using InventoryManagementSystem.Application.Models;
using InventoryManagementSystem.Application.Services.SalesServices.Interface;
using InventoryManagementSystem.Application.Services.StocksServices.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.Services.StocksServices
{
    public class DeleteStockService : IDeleteStockService
    {
        private readonly IStockInventoryRepository _stockInventoryRepository;
        public DeleteStockService(IStockInventoryRepository stockInventoryRepository)
        {
            _stockInventoryRepository = stockInventoryRepository;
        }

        public async Task<bool> DeleteById(Guid id)
        {
            try
            {
                var result = await _stockInventoryRepository.DeleteById(id);
                return result;
            }
            catch (Exception ex) { 
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
