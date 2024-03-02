using InventoryManagementSytem.Services.Model;
using InventoryManagementSytem.Services.Sales.Interface;
using System.Text.Json;

namespace InventoryManagementSytem.Services.Sales
{
    public class GetSalesService : IGetSalesService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public GetSalesService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<List<GetAllSalesResponse>> GetAll()
        {
            using (var httpclient = _httpClientFactory.CreateClient("IMSService"))
            {
                var result = await httpclient.GetAsync("Sales/GetAll");

                Stream stream = result.Content.ReadAsStream();

                StreamReader reader = new StreamReader(stream);

                string response = reader.ReadToEnd();

                return JsonSerializer.Deserialize<List<GetAllSalesResponse>>(response);
            }
        }
    }
}
