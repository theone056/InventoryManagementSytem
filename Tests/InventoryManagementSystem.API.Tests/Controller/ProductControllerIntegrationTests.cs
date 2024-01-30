using FluentAssertions;
using Moq;
using System.Net;

namespace InventoryManagementSystem.API.Tests.Controller
{
    public class ProductControllerIntegrationTests : IClassFixture<CustomWebApplicationFactory>
    {
        private HttpClient _client;

        public ProductControllerIntegrationTests(CustomWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetAll_Method_Returns_Ok()
        {
            //Act
            HttpResponseMessage response = await _client.GetAsync("api/Product/GetAll",It.IsAny<CancellationToken>());

            //Assert
            response.Should().BeSuccessful();
            Assert.True(response.IsSuccessStatusCode);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
