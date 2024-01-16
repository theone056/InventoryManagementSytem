using AutoFixture;
using InventoryManagementSystem.Domain.Entities;

namespace InventoryManagementSystem.Infastructure.Tests.Repositories
{
    public class ProductRepositoryTests
    {
        public IProductRepository _productRepository;
        DbContextMock<IMSDbContext> _mockDbContext;
        private readonly IFixture _fixture;
        public ProductRepositoryTests()
        {
            _fixture = new Fixture();
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var productInitialData = new List<Product>() { new Product() { Code = new Guid("D1695562-EC1C-47A1-F9D4-08DC0E84CD34"), ProductName = "Test" }, new Product() { Code = new Guid("D1695562-EC1C-47A1-F9D4-08DC0E84CD53"), ProductName = "Test" } };
            _mockDbContext = new DbContextMock<IMSDbContext>(
                new DbContextOptionsBuilder<IMSDbContext>().Options
                );
            _mockDbContext.CreateDbSetMock(temp => temp.Products, productInitialData);
            _productRepository = new ProductRepository(_mockDbContext.Object);
        }

        [Fact]
        public async Task GetProduct_Returns_Product()
        {
            var result = await _productRepository.Get(new Guid("D1695562-EC1C-47A1-F9D4-08DC0E84CD34"), It.IsAny<CancellationToken>());

            Assert.NotNull(result);
            Assert.IsType<Product>(result);
        }

        [Fact]
        public async Task GetAll_Returns_Product()
        {
            var result = await _productRepository.GetAll(It.IsAny<CancellationToken>());

            Assert.NotNull(result);
            Assert.IsType<List<Product>>(result);
        }

        [Fact]
        public async Task IsProductNameExist_Returns_True()
        {
            var result = await _productRepository.IsProductNameExist("Test",It.IsAny<CancellationToken>());

            Assert.True(result);
        }

        [Fact]
        public async Task IsProductNameExist_Returns_False()
        {
            var result = await _productRepository.IsProductNameExist("Test1", It.IsAny<CancellationToken>());

            Assert.False(result);
        }

        [Fact]
        public void Upsert_Insert_Returns_True()
        {
            var product = _fixture.Build<Product>()
                                  .With(x=>x.ProductName, "Test Product Name")
                                  .Create();

            var result = _productRepository.Upsert(product, It.IsAny<CancellationToken>());

            Assert.True(result);
        }

        [Fact]
        public void Upsert_Update_Returns_True()
        {
            var product = _fixture.Build<Product>()
                         .With(x => x.ProductName, "Test Product Name")
                         .Create();
            var result = _productRepository.Upsert(product, It.IsAny<CancellationToken>());

            Assert.True(result);
        }

        [Fact]
        public async Task Delete_Returns_True()
        {
            var result = await _productRepository.Delete("Test", It.IsAny<CancellationToken>());

            Assert.True(result);
        }
    }
}
