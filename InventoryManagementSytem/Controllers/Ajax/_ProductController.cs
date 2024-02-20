using InventoryManagementSytem.Models;
using InventoryManagementSytem.Services.Product.Interface;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSytem.Controllers.Ajax
{
    public class _ProductController : Controller
    {
        private readonly IGetProductServices _productService;

        public _ProductController(IGetProductServices productService)
        {
            _productService = productService;
        }

        [Route("ajax/product/ProductModal")]
        [HttpGet]
        public IActionResult ProductModal(Guid code)
        {
            if(code == Guid.Empty)
            {
                return PartialView("~/Views/Product/AddProductModal.cshtml");
            }
            else
            {
                var product = _productService.GetProduct(code).Result;
                return PartialView("~/Views/Product/AddProductModal.cshtml", product);
            }
        }
    }
}
