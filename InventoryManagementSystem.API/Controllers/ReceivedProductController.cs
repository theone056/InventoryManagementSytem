using AutoMapper;
using InventoryManagementSystem.Application.Interface.Repository;
using InventoryManagementSystem.Application.Models;
using InventoryManagementSystem.Application.Services.Interface;
using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceivedProductController : ControllerBase
    {
        private readonly IReceivedProductService _recivedProductService;
        private readonly IStockInventoryRepository _stockRepository;
        public ReceivedProductController(IReceivedProductService receivedProductService, IStockInventoryRepository stockInventory)
        {
            _recivedProductService = receivedProductService;
            _stockRepository = stockInventory;

        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            var result = await _recivedProductService.GetAll(ct);
            return Ok(result);
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetReceivedProduct(Guid guid, CancellationToken ct)
        {
            var receivedProductresult = await _recivedProductService.Get(guid, ct);
            if (receivedProductresult != null)
            {
                return Ok(receivedProductresult);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(ReceivedProductModel receivedProduct)
        {
            if (ModelState.IsValid)
            {
                _recivedProductService.Create(receivedProduct);
                var result = await _stockRepository.UpdateStocksByReceivedQty(new UpdateReceivedQtyModel()
                {
                    ProductCode = receivedProduct.ProductCode,
                    ReceivedQty = receivedProduct.Qty
                });

                if (result)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }

        [HttpPost("Upsert")]
        public IActionResult Upsert(ReceivedProductModel receivedProduct, CancellationToken ct)
        {
            if (ModelState.IsValid)
            {
                _recivedProductService.Upsert(receivedProduct, ct);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("Update")]
        public IActionResult Update(ReceivedProductModel receivedProduct, CancellationToken ct)
        {
            if (ModelState.IsValid)
            {
                var receivedProductResult = _recivedProductService.Get(receivedProduct.ProductCode, ct).Result;
                if (receivedProductResult != null)
                {
                    _recivedProductService.Update(receivedProductResult);
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
        public IActionResult Delete(ReceivedProductModel receivedProduct, CancellationToken ct)
        {
            if (ModelState.IsValid)
            {
                var receivedProductResult = _recivedProductService.Get(receivedProduct.ProductCode, ct).Result;
                if (receivedProductResult != null)
                {
                    _recivedProductService.Delete(receivedProductResult);
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
