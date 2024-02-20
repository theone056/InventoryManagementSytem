namespace InventoryManagementSytem.Models
{
    public class PaymentRequest
    {
        public Guid code { get; set; }
        public int qty { get; set; }
        public double subTotal { get; set; }
    }
}
