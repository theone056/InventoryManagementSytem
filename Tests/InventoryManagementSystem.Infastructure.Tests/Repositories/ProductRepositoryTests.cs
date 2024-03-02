using AutoFixture;
using InventoryManagementSystem.Core.Domain.Entities;
using InventoryManagementSystem.Core.Domain.Interface.Repository;

namespace InventoryManagementSystem.Infastructure.Tests.Repositories
{
    public class ProductRepositoryTests
    {
        public Mock<IProductRepository> _mockproductRepository;
        public IProductRepository _productRepo;
        public ProductRepositoryTests()
        {
            _mockproductRepository = new Mock<IProductRepository>();
            _productRepo = _mockproductRepository.Object;
        }

        [Fact]
        public async Task GetProduct_Returns_Product()
        {
            _mockproductRepository.Setup(x => x.Get(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync(new Product());
            var result = await _productRepo.Get(new Guid("D1695562-EC1C-47A1-F9D4-08DC0E84CD34"), It.IsAny<CancellationToken>());

            Assert.NotNull(result);
            Assert.IsType<Product>(result);
        }

        [Fact]
        public async Task GetAll_Returns_Product()
        {
            _mockproductRepository.Setup(x => x.GetAll(It.IsAny<CancellationToken>())).ReturnsAsync(new List<Product>());
            var result = await _productRepo.GetAll(It.IsAny<CancellationToken>());

            Assert.NotNull(result);
            Assert.IsType<List<Product>>(result);
        }

        [Fact]
        public async Task IsProductNameExist_Returns_True()
        {
            _mockproductRepository.Setup(x => x.IsProductNameExist(It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);
            var result = await _productRepo.IsProductNameExist("Test",It.IsAny<CancellationToken>());

            Assert.True(result);
        }

        [Fact]
        public async Task IsProductNameExist_Returns_False()
        {
            _mockproductRepository.Setup(x=>x.IsProductNameExist(It.IsAny<string>(),It.IsAny<CancellationToken>())).ReturnsAsync(false);
            var result = await _productRepo.IsProductNameExist("Test1", It.IsAny<CancellationToken>());

            Assert.False(result);
        }

        [Fact]
        public void Upsert_Insert_Returns_True()
        {
            _mockproductRepository.Setup(x=>x.Upsert(It.IsAny<Product>(),It.IsAny<CancellationToken>())).Returns(true);

            var result = _productRepo.Upsert(It.IsAny<Product>(), It.IsAny<CancellationToken>());

            Assert.True(result);
        }

        [Fact]
        public async Task Delete_Returns_True()
        {
            _mockproductRepository.Setup(x => x.Delete(It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);
            var result = await _productRepo.Delete("Test", It.IsAny<CancellationToken>());

            Assert.True(result);
        }
    }
}
