using InventoryManagementSystem.Core.Models;
using InventoryManagementSystem.Core.Services.SalesServices.Interface;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ICreateSalesService _createSalesService;
        private readonly IGetSalesService _getSalesService;
        private readonly IUpdateSalesService _updateSalesService;
        private readonly IDeleteSalesService _deleteSalesService;
        public SalesController(ICreateSalesService createSalesService,
                               IGetSalesService getSalesService,
                               IUpdateSalesService updateSalesService,
                               IDeleteSalesService deleteSalesService)
        {
            _createSalesService = createSalesService;
            _getSalesService = getSalesService;
            _updateSalesService = updateSalesService;
            _deleteSalesService = deleteSalesService;
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            return Ok(await _getSalesService.GetAll(ct));
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetSale(Guid guid, CancellationToken ct)
        {
            var salesresult = await _getSalesService.Get(guid, ct);
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
                _createSalesService.Create(sale);
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
                _updateSalesService.Update(sale,ct);
                return Ok();
            }
            return BadRequest();
        }


        [HttpDelete("Delete")]
        public IActionResult Delete(SalesModel sale, CancellationToken ct)
        {
            if (ModelState.IsValid)
            {
                _deleteSalesService.Delete(sale, ct);
                return Ok();
            }
            return BadRequest();
        }
    }
}
