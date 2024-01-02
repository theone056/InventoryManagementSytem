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
    public class ReceivedProductController : ControllerBase
    {
        private readonly IReceivedProductRepository _receivedProductRepository;
        private readonly IMapper _mapper;
        public ReceivedProductController(IReceivedProductRepository receivedProductRepository, IMapper mapper)
        {
            _receivedProductRepository = receivedProductRepository;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            return Ok(await _receivedProductRepository.GetAll(ct));
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetReceivedProduct(Guid guid, CancellationToken ct)
        {
            var receivedProductresult = await _receivedProductRepository.Get(guid, ct);
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
        public IActionResult Create(ReceivedProductModel receivedProduct)
        {
            if (ModelState.IsValid)
            {
                var receivedProductModel = _mapper.Map<ReceivedProduct>(receivedProduct);
                _receivedProductRepository.Create(receivedProductModel);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("Update")]
        public IActionResult Update(ReceivedProductModel receivedProduct, CancellationToken ct)
        {
            if (ModelState.IsValid)
            {
                var receivedProductModel = _mapper.Map<ReceivedProduct>(receivedProduct);
                var receivedProductResult = _receivedProductRepository.Get(receivedProductModel.ProductCode, ct).Result;
                if (receivedProductResult != null)
                {
                    _receivedProductRepository.Update(receivedProductResult);
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
                var receivedProductModel = _mapper.Map<ReceivedProduct>(receivedProduct);
                var receivedProductResult = _receivedProductRepository.Get(receivedProductModel.ProductCode, ct).Result;
                if (receivedProductResult != null)
                {
                    _receivedProductRepository.Delete(receivedProductResult);
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
