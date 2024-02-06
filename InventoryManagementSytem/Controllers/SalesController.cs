using AutoMapper;
using InventoryManagementSytem.Models;
using InventoryManagementSytem.Services.Product.Interface;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSytem.Controllers
{
    public class SalesController : Controller
    {
        private readonly IProductService _productService;
        public SalesController(IProductService productService)
        {
            _productService = productService;
        }
        [Route("Sales")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Sales/Purchase")]
        public async Task<IActionResult> Purchase()
        {
            var products = await _productService.GetAllNames();
            return View(new PurchaseViewModel()
            {
                Products = products
            });
        }
    }
}
