using InventoryManagementSytem.Services.Model;
using InventoryManagementSytem.Services.Models;
using InventoryManagementSytem.Services.Product.Interface;
using System.Net.Http;
using System.Text.Json;

namespace InventoryManagementSytem.Services.Product
{
    public class GetProductServices : IGetProductServices
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public GetProductServices(IHttpClientFactory httpClientFactory)
        {

            _httpClientFactory = httpClientFactory;

        }
        public async Task<List<ProductModel>> GetAll()
        {
            using (var httpclient = _httpClientFactory.CreateClient("IMSService"))
            {
                var result = await httpclient.GetAsync("Product/GetAll");

                Stream stream = result.Content.ReadAsStream();

                StreamReader reader = new StreamReader(stream);

                string response = reader.ReadToEnd();

                return JsonSerializer.Deserialize<List<ProductModel>>(response);
            }
        }

        public async Task<List<ProductNamesModel>> GetAllNames()
        {
            using (var httpclient = _httpClientFactory.CreateClient("IMSService"))
            {
                var result = await httpclient.GetAsync("Product/GetProductNames");

                Stream stream = result.Content.ReadAsStream();

                StreamReader reader = new StreamReader(stream);

                string response = reader.ReadToEnd();

                return JsonSerializer.Deserialize<List<ProductNamesModel>>(response);
            }
        }

        public async Task<List<ProductNamesModel>> GetAvailableProducts()
        {
            using (var httpclient = _httpClientFactory.CreateClient("IMSService"))
            {
                var result = await httpclient.GetAsync("Product/GetAvailableProducts");

                Stream stream = result.Content.ReadAsStream();

                StreamReader reader = new StreamReader(stream);

                string response = reader.ReadToEnd();

                return JsonSerializer.Deserialize<List<ProductNamesModel>>(response);
            }
        }

        public async Task<ProductModel> GetProduct(Guid guid)
        {
            using (var httpclient = _httpClientFactory.CreateClient("IMSService"))
            {
                var result = await httpclient.GetAsync(string.Format("Product/Get?guid={0}", guid));

                Stream stream = result.Content.ReadAsStream();

                StreamReader reader = new StreamReader(stream);

                string response = reader.ReadToEnd();

                return JsonSerializer.Deserialize<ProductModel>(response);
            }
        }
    }
}
