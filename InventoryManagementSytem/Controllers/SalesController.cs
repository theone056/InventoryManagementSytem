using AutoMapper;
using InventoryManagementSytem.Models;
using InventoryManagementSytem.Services.Model;
using InventoryManagementSytem.Services.Product.Interface;
using InventoryManagementSytem.Services.Sales.Interface;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSytem.Controllers
{
    public class SalesController : Controller
    {
        private readonly IGetProductServices _productService;
        private readonly ICreateSaleService _createSaleService;
        private readonly IMapper _mapper;
        public SalesController(IGetProductServices productService, ICreateSaleService createSaleService, IMapper mapper)
        {
            _productService = productService;
            _createSaleService = createSaleService;
            _mapper = mapper;

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

        [HttpPost]
        [Route("Sales/Payment")]
        public IActionResult Payment(List<PaymentRequest> itemsPurchased)
        {
            if (ModelState.IsValid)
            {
                var sales = _mapper.Map<List<SalesModel>>(itemsPurchased);
                var result = _createSaleService.Create(sales).Result;
                if (result)
                {
                    return Ok();
                }
            }

            return BadRequest();
        }
    }
}
