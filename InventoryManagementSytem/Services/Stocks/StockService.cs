using InventoryManagementSytem.Services.Model;
using InventoryManagementSytem.Services.Stocks.Interface;
using System.Net.Http;
using System.Text.Json;

namespace InventoryManagementSytem.Services.Stocks
{
    public class StockService : IStockService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public StockService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<List<StockModel>> GetAllStock()
        {
            using (var httpclient = _httpClientFactory.CreateClient("IMSService"))
            {
                var result = await httpclient.GetAsync("StockInventory/GetAll");

                Stream stream = result.Content.ReadAsStream();

                StreamReader reader = new StreamReader(stream);

                string response = reader.ReadToEnd();

                return JsonSerializer.Deserialize<List<StockModel>>(response);
            }
        }
    }
}
