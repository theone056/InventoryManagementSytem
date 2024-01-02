using InventoryManagementSytem.Services.Models;

namespace InventoryManagementSytem.Models
{
    public class ProductIndexViewModel
    {
        public List<ProductModel>? ProductModel { get; set; }

        public List<string>? Errors { get; set; }
    }
}
