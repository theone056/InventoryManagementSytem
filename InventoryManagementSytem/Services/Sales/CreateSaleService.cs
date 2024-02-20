using InventoryManagementSytem.Services.Model;
using InventoryManagementSytem.Services.Sales.Interface;
using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace InventoryManagementSytem.Services.Sales
{
    public class CreateSaleService : ICreateSaleService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CreateSaleService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<bool> Create(List<SalesModel> product)
        {
            using(var httpClient = _httpClientFactory.CreateClient("SaleService"))
            {
                var productJSON = new StringContent(
                  JsonSerializer.Serialize(product),
                  Encoding.UTF8,
                  Application.Json
                    );

                var result = await httpClient.PostAsync("Sales/AddSales",productJSON);
                if (result.IsSuccessStatusCode)
                {
                    return true;
                }
               
                return false;

            }
        }
    }
}
