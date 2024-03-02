using InventoryManagementSystem.API.Controllers;
using InventoryManagementSystem.Core.Models;
using InventoryManagementSystem.Core.Services.ProductServices.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Net;

namespace InventoryManagementSystem.API.Tests.Controller
{
    public class ProductControllerTests
    {
        private readonly Mock<ILogger<ProductController>> _logger;
        private readonly Mock<ICreateProductService> _createProductService;
        private readonly Mock<IUpdateProductService> _updateProductService;
        private readonly Mock<IGetProductService> _getProductService;
        private readonly Mock<IDeleteProductService> _deleteProductService;
        private readonly ProductController _prod;

        public ProductControllerTests()
        {
            _createProductService = new Mock<ICreateProductService>();
            _deleteProductService = new Mock<IDeleteProductService>();
            _getProductService = new Mock<IGetProductService>();
            _updateProductService = new Mock<IUpdateProductService>();
            _logger = new Mock<ILogger<ProductController>>();
            _prod = new ProductController(_createProductService.Object,_getProductService.Object,_updateProductService.Object,_deleteProductService.Object, _logger.Object);
        }

        [Fact]
        public async Task GetAll_Method_Returns_Ok()
        {
            _getProductService.Setup(x => x.GetAll(It.IsAny<CancellationToken>())).ReturnsAsync(new List<GetAllProductResponse>() { new GetAllProductResponse () { ProductName = "Test"} });

            var result = await _prod.GetAll(It.IsAny<CancellationToken>()) as OkObjectResult;

            Assert.NotNull(result.Value);
            Assert.IsType<List<GetAllProductResponse>>(result.Value);
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public void GetCount_Method_Returns_Ok()
        {
            _getProductService.Setup(x=>x.GetCount()).Returns(new ItemCountModel() { ProductCount = 1 });

            var result = _prod.GetCount(It.IsAny<CancellationToken>()) as OkObjectResult;

            Assert.NotNull(result.Value);
            Assert.IsType<ItemCountModel>(result.Value);
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        }
    }
}
