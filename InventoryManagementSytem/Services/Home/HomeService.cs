using InventoryManagementSytem.Models;
using InventoryManagementSytem.Services.Home.Interface;
using System.Net.Http;
using System.Text.Json;

namespace InventoryManagementSytem.Services.Home
{
    public class HomeService : IHomeService
    {
        IHttpClientFactory _httpClientFactory;
        public HomeService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IndexViewModel> GetCount()
        {
            using (var httpclient = _httpClientFactory.CreateClient("ProductService"))
            {
                var result = await httpclient.GetAsync("Product/GetCount");

                Stream stream = result.Content.ReadAsStream();

                StreamReader reader = new StreamReader(stream);

                string response = reader.ReadToEnd();

                return JsonSerializer.Deserialize<IndexViewModel>(response);
            }
        }
    }
}
