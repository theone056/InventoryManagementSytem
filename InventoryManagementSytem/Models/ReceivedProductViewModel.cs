using InventoryManagementSytem.Services.Model;
using InventoryManagementSytem.Services.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace InventoryManagementSytem.Models
{
    public class ReceivedProductViewModel
    {
        public List<GetAllReceivedProductResponseViewModel> ReceivedProduct { get; set; }
        public List<ProductNamesModel> Products { get; set; }

        [Required]
        [DisplayName("Product ID")]
        public Guid ProductID { get; set; }

        [Required]
        [DisplayName("Quantity")]
        public int Qty { get; set; }

        [Required]
        [DisplayName("Date Received")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: MM/dd/yyyy hh:mm AM}")]
        public DateTime DateReceived { get; set; }
    }
}
