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
