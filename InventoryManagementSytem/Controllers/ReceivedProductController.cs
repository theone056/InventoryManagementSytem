using AutoMapper;
using InventoryManagementSytem.Models;
using InventoryManagementSytem.Services.Model;
using InventoryManagementSytem.Services.Product;
using InventoryManagementSytem.Services.Product.Interface;
using InventoryManagementSytem.Services.ReceivedProduct.Interface;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSytem.Controllers
{
    public class ReceivedProductController : Controller
    {
        private readonly IReceivedProductService _receivedProduct;
        private readonly IProductService _productService;
        public ReceivedProductController(IReceivedProductService receivedProduct, IProductService productService)
        {
            _receivedProduct = receivedProduct;
            _productService = productService;
        }

        [Route("ReceivedProduct")]
        public IActionResult Index()
        {
            var result = _receivedProduct.GetAll().Result;
            return View(new ReceivedProductViewModel()
            {
                ReceivedProduct = result,
                Products = _productService.GetAllNames().Result
            });
        }

        [HttpPost]
        public IActionResult SaveReceivedProduct(ReceivedProductViewModel receivedProduct)
        {
            var result = _receivedProduct.Create(new ReceivedProductModel()
            {
                ProductCode = receivedProduct.ProductID,
                Qty = receivedProduct.Qty,
                DateReceived = receivedProduct.DateReceived,
                DateCreated = DateTime.UtcNow,
                EncodedBy = "Test Name"
            }).Result;

            if(!result)
            {
                
            }

            var receivedProducts = _receivedProduct.GetAll().Result;
            return PartialView("ReceivedProductTable",receivedProducts);
        }
    }
}
