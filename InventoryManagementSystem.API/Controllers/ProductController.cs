using AutoMapper;
using InventoryManagementSystem.API.Filters;
using InventoryManagementSystem.API.Filters.ExceptionFilters;
using InventoryManagementSystem.Application.Interface.Repository;
using InventoryManagementSystem.Application.Models;
using InventoryManagementSystem.Application.Services.Interface;
using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Application.Services.ProductServices.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace InventoryManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IGetProductService _GetProductService;
        private readonly ICreateProductService _createProductService;
        private readonly IUpdateProductService _updateProductService;
        private readonly IDeleteProductService _deleteProductService;
        private readonly ILogger<ProductController> _logger;
        public ProductController(ICreateProductService createProductService,
                                 IGetProductService getProductService,
                                 IUpdateProductService updateProductService,
                                 IDeleteProductService deleteProductService,
                                 ILogger<ProductController> logger)
        {
            _createProductService = createProductService;
            _GetProductService = getProductService;
            _updateProductService = updateProductService;
            _deleteProductService = deleteProductService;
            _logger = logger;

            _logger.LogInformation("Product Controller Called");
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(List<GetAllProductResponse>),StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            _logger.LogInformation("GetAll");
            return Ok(await _GetProductService.GetAll(ct));
        }

        [HttpGet("GetCount")]
        [ProducesResponseType(typeof(ItemCount),StatusCodes.Status200OK)]
        public IActionResult GetCount(CancellationToken ct)
        {
            _logger.LogInformation("GetCount");
            return Ok(_GetProductService.GetCount());
        }

        [HttpGet("GetProductNames")]
        [ProducesResponseType(typeof(List<KeyValue>),StatusCodes.Status200OK)]
        public IActionResult GetProductNames(CancellationToken ct)
        {
            _logger.LogInformation("GetProductNames");
            return Ok(_GetProductService.GetProductNames());
        }

        [HttpGet("GetAvailableProducts")]
        [ProducesResponseType(typeof(List<KeyValue>), StatusCodes.Status200OK)]
        public IActionResult GetAvailableProducts(CancellationToken ct)
        {
            _logger.LogInformation("GetAvailableProducts");
            return Ok(_GetProductService.GetAvailableProducts());
        }

        [HttpGet("Get")]
        [ProducesResponseType(typeof(GetProductResponse),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [TypeFilter(typeof(ParameterValidation))]
        public async Task<IActionResult> GetProduct(Guid guid,CancellationToken ct)
        {
            _logger.LogInformation("GetProduct");
            var productresult = await _GetProductService.Get(guid,ct);
            if(productresult != null)
            {
                return Ok(productresult);
            }
            else
            {
                _logger.LogError("Product Not Found");
                return NotFound();
            }
        }

        [HttpPost("Upsert")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Upsert(ProductModel product, CancellationToken ct)
        {
            if (ModelState.IsValid)
            {
                var result = _updateProductService.Upsert(product, ct);
                if(result)
                {
                    return Ok();
                }
                else
                {
                    _logger.LogError("Failed to update");
                    return StatusCode(500);
                }
            }
            _logger.LogError("Invalid Data!");
            return BadRequest();
        }


        [HttpDelete("Delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(string productName, CancellationToken ct)
        {
            await _deleteProductService.Delete(productName, ct);
            return Ok();
        }
    }
}
