using InventoryManagementSytem.Services.Product.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace InventoryManagementSytem.Controllers.Ajax
{
    [Route("ajax/Sales/")]
    public class _SalesController : Controller
    {
        private readonly IProductService _productService;
        public _SalesController(IProductService productService)
        {
            _productService = productService;
        }

        [Route("GetProduct")]
        [HttpGet]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            var result = await _productService.GetProduct(id);
            return PartialView("~/Views/Sales/_TableRow.cshtml", result);
        }
    }
}
