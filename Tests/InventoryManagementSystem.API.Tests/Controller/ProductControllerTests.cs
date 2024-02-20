using AutoMapper;
using Castle.Core.Logging;
using InventoryManagementSystem.API.Controllers;
using InventoryManagementSystem.Application.Interface.Repository;
using InventoryManagementSystem.Application.Models;
using InventoryManagementSystem.Application.Services.Interface;
using InventoryManagementSystem.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.API.Tests.Controller
{
    public class ProductControllerTests
    {
        private readonly Mock<IProductService> _mockProductService;
        private readonly Mock<ILogger<ProductController>> _logger;
        private readonly ProductController _prod;

        public ProductControllerTests()
        {
            _mockProductService = new Mock<IProductService>();
            _logger = new Mock<ILogger<ProductController>>();
            _prod = new ProductController(_mockProductService.Object, _logger.Object);
        }

        [Fact]
        public async Task GetAll_Method_Returns_Ok()
        {
            _mockProductService.Setup(x => x.GetAll(It.IsAny<CancellationToken>())).ReturnsAsync(new List<ProductModel>() { new ProductModel() { ProductName = "Test"} });

            var result = await _prod.GetAll(It.IsAny<CancellationToken>()) as OkObjectResult;

            Assert.NotNull(result.Value);
            Assert.IsType<List<ProductModel>>(result.Value);
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public void GetCount_Method_Returns_Ok()
        {
            _mockProductService.Setup(x=>x.GetCount()).Returns(new ItemCountModel() { ProductCount = 1 });

            var result = _prod.GetCount(It.IsAny<CancellationToken>()) as OkObjectResult;

            Assert.NotNull(result.Value);
            Assert.IsType<ItemCountModel>(result.Value);
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        }
    }
}
