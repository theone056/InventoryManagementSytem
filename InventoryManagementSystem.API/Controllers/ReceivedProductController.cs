using InventoryManagementSystem.Application.Models;
using InventoryManagementSystem.Application.Services.ReceivedProductServices.Interface;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceivedProductController : ControllerBase
    {
        private readonly IGetReceivedProductService _getReceivedProductService;
        private readonly ICreateReceivedProductService _createReceivedProductService;
        private readonly IUpdateReceivedProductService _updateReceivedProductService;
        private readonly IDeleteReceivedProductService _deleteReceivedProductService;
        public ReceivedProductController(IGetReceivedProductService getReceivedProductService, 
                                         ICreateReceivedProductService createReceivedProductService,
                                         IUpdateReceivedProductService updateReceivedProductService,
                                         IDeleteReceivedProductService deleteReceivedProductService)
        {
            _getReceivedProductService = getReceivedProductService;
            _createReceivedProductService = createReceivedProductService;
            _updateReceivedProductService = updateReceivedProductService;
            _deleteReceivedProductService = deleteReceivedProductService;

        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            var result = await _getReceivedProductService.GetAll(ct);
            return Ok(result);
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetReceivedProduct(Guid guid, CancellationToken ct)
        {
            var receivedProductresult = await _getReceivedProductService.Get(guid, ct);
            if (receivedProductresult != null)
            {
                return Ok(receivedProductresult);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("Create")]
        public ActionResult Create([FromBody]ReceivedProductModel receivedProduct)
        {
            if (ModelState.IsValid)
            {
                _createReceivedProductService.Create(receivedProduct);
                 return Ok();
            }
            return BadRequest();
        }

        [HttpPost("Upsert")]
        public IActionResult Upsert(ReceivedProductModel receivedProduct, CancellationToken ct)
        {
            if (ModelState.IsValid)
            {
                _updateReceivedProductService.Upsert(receivedProduct, ct);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("Update")]
        public IActionResult Update(ReceivedProductModel receivedProduct, CancellationToken ct)
        {
            if (ModelState.IsValid)
            {
                _updateReceivedProductService.Update(receivedProduct,ct);
                return Ok();
            }
            return BadRequest();
        }


        [HttpDelete("Delete")]
        public IActionResult Delete(ReceivedProductModel receivedProduct, CancellationToken ct)
        {
            if (ModelState.IsValid)
            {
                _deleteReceivedProductService.Delete(receivedProduct,ct);
                return Ok();
            }
            return BadRequest();
        }
    }
}
