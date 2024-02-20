using InventoryManagementSytem.Services.Product.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace InventoryManagementSytem.Controllers.Ajax
{
    [Route("ajax/Sales/")]
    public class _SalesController : Controller
    {
        private readonly IGetProductServices _productService;
        public _SalesController(IGetProductServices productService)
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
