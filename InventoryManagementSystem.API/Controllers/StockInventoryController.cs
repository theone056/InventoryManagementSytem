using AutoMapper;
using InventoryManagementSystem.Application.Interface.Repository;
using InventoryManagementSystem.Application.Models;
using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockInventoryController : ControllerBase
    {
        private readonly IStockInventoryRepository _stockInventoryRepository;
        private readonly IMapper _mapper;
        public StockInventoryController(IStockInventoryRepository stockInventoryRepository, IMapper mapper)
        {
            _stockInventoryRepository = stockInventoryRepository;
            _mapper = mapper;
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            return Ok(await _stockInventoryRepository.GetAll(ct));
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetStock(Guid guid, CancellationToken ct)
        {
            var stockresult = await _stockInventoryRepository.Get(guid, ct);
            if (stockresult != null)
            {
                return Ok(stockresult);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("Create")]
        public IActionResult Create(StockInventoryModel stockInventory)
        {
            if (ModelState.IsValid)
            {
                var stockInventoryModel = _mapper.Map<StockInventory>(stockInventory);
                _stockInventoryRepository.Create(stockInventoryModel);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("Update")]
        public IActionResult Update(StockInventoryModel stockInventory, CancellationToken ct)
        {
            if (ModelState.IsValid)
            {
                var stockInventoryModel = _mapper.Map<StockInventory>(stockInventory);
                var stockInventoryResult = _stockInventoryRepository.Get(stockInventoryModel.ProductCode, ct).Result;
                if (stockInventoryResult != null)
                {
                    _stockInventoryRepository.Update(stockInventoryResult);
                    return Ok();
                }
                else
                {
                    return NotFound();
                }

            }
            return BadRequest();
        }


        [HttpDelete("Delete")]
        public IActionResult Delete(StockInventoryModel stockInventory, CancellationToken ct)
        {
            if (ModelState.IsValid)
            {
                var stockInventoryModel = _mapper.Map<StockInventory>(stockInventory);
                var stockInventoryResult = _stockInventoryRepository.Get(stockInventoryModel.ProductCode, ct).Result;
                if (stockInventoryResult != null)
                {
                    _stockInventoryRepository.Delete(stockInventoryResult);
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            return BadRequest();
        }
    }
}
