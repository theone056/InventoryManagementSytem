using InventoryManagementSytem.Services.Product.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace InventoryManagementSytem.Controllers.Api
{
    [Route("api/product")]
    public class _ProductController : Controller
    {
        private readonly IProductService _productService;

        public _ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [Route("GetProduct")]
        [HttpGet]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            var result = await _productService.GetProduct(id);
            return Json(result, JsonSerializerOptions.Default);
        }
    }
}
