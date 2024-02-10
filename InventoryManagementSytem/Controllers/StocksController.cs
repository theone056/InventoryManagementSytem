using InventoryManagementSytem.Services.Stocks;
using InventoryManagementSytem.Services.Stocks.Interface;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSytem.Controllers
{
    public class StocksController : Controller
    {
        private readonly IStockService _stockService;
        public StocksController(IStockService stockService)
        {
            _stockService = stockService;
        }
        [Route("Stocks")]
        public IActionResult Index()
        {
            var result = _stockService.GetAllStock().Result;
            return View(result);
        }
    }
}
