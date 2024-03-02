using InventoryManagementSystem.Core.Models;
using InventoryManagementSystem.Core.Services.StocksServices.Interface;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockInventoryController : ControllerBase
    {
        private readonly IGetStockService _getStockService;
        private readonly ICreateStockService _createStockService;
        public StockInventoryController(IGetStockService getStockService,
                                        ICreateStockService createStockService)
        {
            _getStockService = getStockService;
            _createStockService = createStockService;

        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            return Ok(await _getStockService.GetAll(ct));
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetStock(Guid guid, CancellationToken ct)
        {
            var stockresult = await _getStockService.Get(guid, ct);
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
                _createStockService.Create(stockInventory);
                return Ok();
            }
            return BadRequest();
        }

        //[HttpPut("Update")]
        //public IActionResult Update(StockInventoryModel stockInventory, CancellationToken ct)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var stockInventoryModel = _mapper.Map<StockInventory>(stockInventory);
        //        var stockInventoryResult = _stockInventoryRepository.Get(stockInventoryModel.ProductCode, ct).Result;
        //        if (stockInventoryResult != null)
        //        {
        //            _stockInventoryRepository.Update(stockInventoryResult);
        //            return Ok();
        //        }
        //        else
        //        {
        //            return NotFound();
        //        }

        //    }
        //    return BadRequest();
        //}


        //[HttpDelete("Delete")]
        //public IActionResult Delete(StockInventoryModel stockInventory, CancellationToken ct)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var stockInventoryModel = _mapper.Map<StockInventory>(stockInventory);
        //        var stockInventoryResult = _getStockService.Get(stockInventoryModel.ProductCode, ct).Result;
        //        if (stockInventoryResult != null)
        //        {
        //            _stockInventoryRepository.Delete(stockInventoryResult);
        //            return Ok();
        //        }
        //        else
        //        {
        //            return NotFound();
        //        }
        //    }
        //    return BadRequest();
        //}
    }
}
