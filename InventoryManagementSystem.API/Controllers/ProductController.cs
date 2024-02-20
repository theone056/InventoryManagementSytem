using AutoMapper;
using InventoryManagementSystem.API.Filters;
using InventoryManagementSystem.API.Filters.ExceptionFilters;
using InventoryManagementSystem.Application.Interface.Repository;
using InventoryManagementSystem.Application.Models;
using InventoryManagementSystem.Application.Services.Interface;
using InventoryManagementSystem.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace InventoryManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;
        public ProductController(IProductService productService,
                                 ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;

            _logger.LogInformation("Product Controller Called");
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(List<Product>),StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            _logger.LogInformation("GetAll");
            return Ok(await _productService.GetAll(ct));
        }

        [HttpGet("GetCount")]
        [ProducesResponseType(typeof(ItemCount),StatusCodes.Status200OK)]
        public IActionResult GetCount(CancellationToken ct)
        {
            _logger.LogInformation("GetCount");
            return Ok(_productService.GetCount());
        }

        [HttpGet("GetProductNames")]
        [ProducesResponseType(typeof(List<KeyValue>),StatusCodes.Status200OK)]
        public IActionResult GetProductNames(CancellationToken ct)
        {
            _logger.LogInformation("GetProductNames");
            return Ok(_productService.GetProductNames());
        }

        [HttpGet("Get")]
        [ProducesResponseType(typeof(Product),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [TypeFilter(typeof(ParameterValidation))]
        public async Task<IActionResult> GetProduct(Guid guid,CancellationToken ct)
        {
            _logger.LogInformation("GetProduct");
            var productresult = await _productService.Get(guid,ct);
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

        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Create(ProductModel product, CancellationToken ct)
        {
            if(ModelState.IsValid)
            {
                if(_productService.IsProductNameExist(product.ProductName, ct).Result == false)
                {
                    _productService.Create(product);
                    return Ok();
                }
            }
            _logger.LogError("Invalid Data!");
            return BadRequest();
        }

        [HttpPost("Upsert")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Upsert(ProductModel product, CancellationToken ct)
        {
            if (ModelState.IsValid)
            {
                var result = _productService.Upsert(product, ct);
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

        [HttpPut("Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update(ProductModel product, CancellationToken ct)
        {
            if (ModelState.IsValid)
            {
                var productResult = _productService.Get(product.Code, ct).Result;
                if (productResult != null)
                {
                    _productService.Update(product);
                    return Ok();
                }
                else
                {
                    _logger.LogError("Failed to update!");
                    return NotFound();
                }
               
            }
            _logger.LogError("Failed to create Product!");
            return BadRequest();
        }


        [HttpDelete("Delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(string productName, CancellationToken ct)
        {
            await _productService.Delete(productName, ct);
            return Ok();
        }
    }
}
