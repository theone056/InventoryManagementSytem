using InventoryManagementSytem.Services.Model;
using InventoryManagementSytem.Services.ReceivedProduct.Interface;
using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace InventoryManagementSytem.Services.ReceivedProduct
{
    public class ReceivedProductService : IReceivedProductService
    {
        private IHttpClientFactory _httpClientFactory;
        public ReceivedProductService(IHttpClientFactory httpClientFactory)
        {

            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> Create(ReceivedProductModel product)
        {
            using (var httpclient = _httpClientFactory.CreateClient("ReceivedProductService"))
            {
                var productJson = new StringContent(
                JsonSerializer.Serialize(product),
                Encoding.UTF8,
                Application.Json);
                var result = await httpclient.PostAsync("ReceivedProduct/Create", productJson);

                if (result.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Task<bool> Delete(string productName)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ReceivedProductModel>> GetAll()
        {
            using (var httpclient = _httpClientFactory.CreateClient("ReceivedProductService"))
            {
                var result = await httpclient.GetAsync("ReceivedProduct/GetAll");

                Stream stream = result.Content.ReadAsStream();

                StreamReader reader = new StreamReader(stream);

                string response = reader.ReadToEnd();

                return JsonSerializer.Deserialize<List<ReceivedProductModel>>(response);
            }
        }

        public Task<ReceivedProductModel> GetProduct(Guid guid)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Upsert(ReceivedProductModel product)
        {
            using (var httpclient = _httpClientFactory.CreateClient("ReceivedProductService"))
            {
                var productJson = new StringContent(
                JsonSerializer.Serialize(product),
                Encoding.UTF8,
                Application.Json);
                var result = await httpclient.PostAsync("ReceivedProduct/Create", productJson);

                if (result.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
