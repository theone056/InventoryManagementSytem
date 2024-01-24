using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSytem.Controllers
{
    public class StocksController : Controller
    {
        [Route("Stocks")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
