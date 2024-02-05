﻿using AutoMapper;
using InventoryManagementSystem.API.Filters;
using InventoryManagementSystem.Application.Interface.Repository;
using InventoryManagementSystem.Application.Models;
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
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductController> _logger;
        public ProductController(IProductRepository productRepository,
                                 IMapper mapper,
                                 ILogger<ProductController> logger)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _logger = logger;

            _logger.LogInformation("Product Controller Called");
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(List<Product>),StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            _logger.LogInformation("GetAll");
            return Ok(await _productRepository.GetAll(ct));
        }

        [HttpGet("GetCount")]
        [ProducesResponseType(typeof(ItemCount),StatusCodes.Status200OK)]
        public IActionResult GetCount(CancellationToken ct)
        {
            _logger.LogInformation("GetCount");
            return Ok(_productRepository.GetCount());
        }

        [HttpGet("GetProductNames")]
        [ProducesResponseType(typeof(List<KeyValue>),StatusCodes.Status200OK)]
        public IActionResult GetProductNames(CancellationToken ct)
        {
            _logger.LogInformation("GetProductNames");
            return Ok(_productRepository.GetProductNames());
        }

        [HttpGet("Get")]
        [ProducesResponseType(typeof(Product),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [TypeFilter(typeof(ParameterValidation))]
        public async Task<IActionResult> GetProduct(Guid guid,CancellationToken ct)
        {
            _logger.LogInformation("GetProduct");
            var productresult = await _productRepository.Get(guid,ct);
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
                var productModel = _mapper.Map<Product>(product);
                if(_productRepository.IsProductNameExist(product.ProductName, ct).Result == false)
                {
                    _productRepository.Create(productModel);
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
                var productModel = _mapper.Map<Product>(product);
                var result = _productRepository.Upsert(productModel,ct);
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
                var productModel = _mapper.Map<Product>(product);
                var productResult = _productRepository.Get(productModel.Code, ct).Result;
                if (productResult != null)
                {
                    _productRepository.Update(productModel);
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
            await _productRepository.Delete(productName, ct);
            return Ok();
        }
    }
}
