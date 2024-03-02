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
        private readonly IGetProductServices _getProductServices;
        public ReceivedProductController(IReceivedProductService receivedProduct, IGetProductServices getProductServices)
        {
            _receivedProduct = receivedProduct;
            _getProductServices = getProductServices;

        }

        [Route("ReceivedProduct")]
        public IActionResult Index()
        {
            var result = ReceivedProducts();
            return View(new ReceivedProductViewModel()
            {
                ReceivedProduct = result,
                Products = _getProductServices.GetAllNames().Result
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
                EncodedBy = "Test Name",
            }).Result;
            
            return RedirectToAction("ReceivedProductTable");
        }

        public IActionResult ReceivedProductTable()
        {
            var receivedProducts = ReceivedProducts();
            return PartialView("ReceivedProductTable", receivedProducts);
        }

        private List<GetAllReceivedProductResponseViewModel> ReceivedProducts()
        {
            return _receivedProduct.GetAll().Result;
        }
    }
}
