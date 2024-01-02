using InventoryManagementSytem.Models;
using InventoryManagementSytem.Services.Home.Interface;
using InventoryManagementSytem.Services.Product.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InventoryManagementSytem.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IHomeService homeService)
        {
            _logger = logger;
            _homeService = homeService;
        }

        public IActionResult Index()
        {   
            var result = _homeService.GetCount().Result;
            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}