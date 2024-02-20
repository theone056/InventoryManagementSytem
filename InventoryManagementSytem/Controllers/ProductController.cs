using InventoryManagementSytem.Models;
using InventoryManagementSytem.Services.Models;
using InventoryManagementSytem.Services.Product.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace InventoryManagementSytem.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IGetProductServices _getProductServices;
        public ProductController(IProductService productService, IGetProductServices getProductServices)
        {
            _productService = productService;
            _getProductServices = getProductServices;

        }

        [Route("Products")]
        public IActionResult Index()
        {
            var result = _getProductServices.GetAll().Result;
            return View(new ProductIndexViewModel()
            {
                ProductModel = result,
                Errors = TempData["Errors"] != null ? TempData["Errors"] as List<string> : null
            });
        }

        [HttpPost]
        public IActionResult AddProductModal(ProductModel productModel)
        {
            var Error = string.Empty;
            if (ModelState.IsValid)
            {
                var result = _productService.Upsert(productModel).Result;

                if (!result)
                {
                    Error = "Unable to create Product";
                }
            }
            else
            {
                Error = "Invalid Product";
            }       

            TempData["Error"] = Error;
            var products = _getProductServices.GetAll().Result;
            return PartialView("ProductTable", products);
        }

        [HttpPost]
        public IActionResult Delete(string productName)
        {
            var listOfErrors = new List<string>();
            var result = _productService.Delete(productName).Result;

            if (result)
            {
                var products = _getProductServices.GetAll().Result;
                return PartialView("ProductTable", products);
            }
            else
            {
                listOfErrors.Add("Unable to Delete Product");
            }

            TempData["Erros"] = listOfErrors;
            return RedirectToAction("Index");
        }
    }
}
