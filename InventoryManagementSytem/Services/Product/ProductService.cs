using InventoryManagementSytem.Services.Model;
using InventoryManagementSytem.Services.Models;
using InventoryManagementSytem.Services.Product.Interface;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace InventoryManagementSytem.Services.Product
{
    public class ProductService : IProductService
    {
        IHttpClientFactory _httpClientFactory;
        public ProductService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> Create(ProductModel product)
        {
            using (var httpclient = _httpClientFactory.CreateClient("ProductService"))
            {
                var productJson = new StringContent(
                JsonSerializer.Serialize(product),
                Encoding.UTF8,
                Application.Json);
                var result = await httpclient.PostAsync("Product/Create", productJson);

                if (result.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;
            }
        }

        public async Task<bool> Delete(string productName)
        {
            using (var httpclient = _httpClientFactory.CreateClient("ProductService"))
            {
                var result = await httpclient.DeleteAsync(string.Format("Product/Delete?productName={0}",productName));

                if (result.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;
            }
        }

        public async Task<List<ProductModel>> GetAll()
        {
            using(var httpclient = _httpClientFactory.CreateClient("ProductService"))
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
            using (var httpclient = _httpClientFactory.CreateClient("ProductService"))
            {
                var result = await httpclient.GetAsync("Product/GetProductNames");

                Stream stream = result.Content.ReadAsStream();

                StreamReader reader = new StreamReader(stream);

                string response = reader.ReadToEnd();

                return JsonSerializer.Deserialize<List<ProductNamesModel>>(response);
            }
        }

        public async Task<ProductModel> GetProduct(Guid guid)
        {
             using(var httpclient = _httpClientFactory.CreateClient("ProductService"))
            {
                var result = await httpclient.GetAsync(string.Format("Product/Get?guid={0}",guid));

                Stream stream = result.Content.ReadAsStream();

                StreamReader reader = new StreamReader(stream);

                string response = reader.ReadToEnd();

                return JsonSerializer.Deserialize<ProductModel>(response);
            }
        }

        public async Task<bool> Update(ProductModel product)
        {
            using (var httpclient = _httpClientFactory.CreateClient("ProductService"))
            {
                var productJson = new StringContent(
                JsonSerializer.Serialize(product),
                Encoding.UTF8,
                Application.Json);
                var result = await httpclient.PostAsync("Product/Update", productJson);

                if (result.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;
            }
        }

        public async Task<bool> Upsert(ProductModel product)
        {
            using (var httpclient = _httpClientFactory.CreateClient("ProductService"))
            {
                var productJson = new StringContent(
                JsonSerializer.Serialize(product),
                Encoding.UTF8,
                Application.Json);
                var result = await httpclient.PostAsync("Product/Upsert", productJson);

                if (result.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;
            }
        }
    }
}
