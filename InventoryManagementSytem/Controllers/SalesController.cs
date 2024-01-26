using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSytem.Controllers
{
    public class SalesController : Controller
    {
        [Route("Sales")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
