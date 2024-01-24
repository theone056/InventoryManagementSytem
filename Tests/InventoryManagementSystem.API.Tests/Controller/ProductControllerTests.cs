using AutoMapper;
using InventoryManagementSystem.API.Controllers;
using InventoryManagementSystem.Application.Interface.Repository;
using InventoryManagementSystem.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
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
        private readonly Mock<IProductRepository> _mockProductRepo;
        private readonly Mock<IMapper> _mockMapper;
        private readonly ProductController _prod;

        public ProductControllerTests()
        {
            _mockProductRepo = new Mock<IProductRepository>();
            _mockMapper = new Mock<IMapper>(); 
            _prod = new ProductController(_mockProductRepo.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetAll_Method_Returns_Ok()
        {
            _mockProductRepo.Setup(x => x.GetAll(It.IsAny<CancellationToken>())).ReturnsAsync(new List<Product>() { new Product() { ProductName = "Test"} });

            var result = await _prod.GetAll(It.IsAny<CancellationToken>()) as OkObjectResult;

            Assert.NotNull(result.Value);
            Assert.IsType<List<Product>>(result.Value);
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public void GetCount_Method_Returns_Ok()
        {
            _mockProductRepo.Setup(x=>x.GetCount()).Returns(new ItemCount() { ProductCount = 1 });

            var result = _prod.GetCount(It.IsAny<CancellationToken>()) as OkObjectResult;

            Assert.NotNull(result.Value);
            Assert.IsType<ItemCount>(result.Value);
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        }
    }
}
