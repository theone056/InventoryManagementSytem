using InventoryManagementSytem.Services.Model;
using InventoryManagementSytem.Services.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace InventoryManagementSytem.Models
{
    public class ReceivedProductViewModel
    {
        public List<ReceivedProductModel> ReceivedProduct { get; set; }
        public List<ProductNamesModel> Products { get; set; }

        public Guid ProductID { get; set; }
        public int Qty { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: MM/dd/yyyy hh:mm AM}")]
        public DateTime DateReceived { get; set; }
    }
}
