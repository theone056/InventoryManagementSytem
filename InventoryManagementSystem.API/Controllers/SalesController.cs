using AutoMapper;
using InventoryManagementSystem.Application.Interface.Repository;
using InventoryManagementSystem.Application.Models;
using InventoryManagementSystem.Application.Services.SalesService.Interface;
using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISalesRepository _salesRepository;
        private readonly ICreateSalesService _createSalesService;
        private readonly IMapper _mapper;
        public SalesController(ISalesRepository salesRepository, ICreateSalesService createSalesService, IMapper mapper)
        {
            _salesRepository = salesRepository;
            _createSalesService = createSalesService;
            _mapper = mapper;
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            return Ok(await _salesRepository.GetAll(ct));
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetSale(Guid guid, CancellationToken ct)
        {
            var salesresult = await _salesRepository.Get(guid, ct);
            if (salesresult != null)
            {
                return Ok(salesresult);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("Create")]
        public IActionResult Create(SalesModel sale)
        {
            if (ModelState.IsValid)
            {
                var salesModel = _mapper.Map<Sale>(sale);
                _salesRepository.Create(salesModel);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost("AddSales")]
        public async Task<IActionResult> AddSales(List<SalesModel> sales)
        {
            if (ModelState.IsValid)
            {
                await _createSalesService.AddSales(sales);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("Update")]
        public IActionResult Update(SalesModel sale, CancellationToken ct)
        {
            if (ModelState.IsValid)
            {
                var salesModel = _mapper.Map<Sale>(sale);
                var salesResult = _salesRepository.Get(salesModel.ProductCode, ct).Result;
                if (salesResult != null)
                {
                    _salesRepository.Update(salesModel);
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
        public IActionResult Delete(SalesModel sale, CancellationToken ct)
        {
            if (ModelState.IsValid)
            {
                var salesModel = _mapper.Map<Sale>(sale);
                var salesResult = _salesRepository.Get(salesModel.ProductCode, ct).Result;
                if (salesResult != null)
                {
                    _salesRepository.Delete(salesResult);
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
