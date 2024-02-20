namespace InventoryManagementSytem.Services.Model
{
    public class SalesModel
    {
        public int Id { get; set; }
        public Guid ProductCode { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.Now;
        public double Qty { get; set; }
        public double TotalSales { get; set; }
        public DateTimeOffset DateCreated { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset? DateUpdated { get; set; } = DateTimeOffset.Now;
    }
}
