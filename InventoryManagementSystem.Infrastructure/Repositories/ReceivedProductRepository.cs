using InventoryManagementSystem.Core.Domain.Entities;
using InventoryManagementSystem.Core.Domain.Interface.Repository;
using InventoryManagementSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Infrastructure.Repositories
{
    public class ReceivedProductRepository : BaseRepository<ReceivedProduct>, IReceivedProductRepository
    {
        private readonly IMSDbContext _context;
        public ReceivedProductRepository(IMSDbContext context) : base(context)
        {
            _context = context;
        }

        public void CreateReceivedProductWithUpdateStock(ReceivedProduct product)
        {
            try
            {
                var price = _context.Products.FirstOrDefault(p => p.Code == product.ProductCode).Price;
                product.SellingPrice = price;
                _context.ReceivedProducts.Add(product);

                //update stock
                var stocks = _context.Stocks.FirstOrDefault(x => x.ProductCode == product.ProductCode);
                if (stocks != null)
                {
                    stocks.ReceivedQty += product.Qty;
                    stocks.StockQty = stocks.ReceivedQty - stocks.SalesQty;
                    stocks.DateUpdated = DateTime.UtcNow;
                }

                _context.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }

        public async Task<ReceivedProduct> Get(Guid code, CancellationToken cancellationToken)
        {
            return await _context.ReceivedProducts.FirstOrDefaultAsync(x=>x.Product.Code == code,cancellationToken);
        }

        public async Task<List<ReceivedProduct>> GetAll(CancellationToken cancellationToken)
        {
            return await _context.ReceivedProducts.Include("Product").ToListAsync(cancellationToken);
        }

        public void UpdateQuantity(ReceivedProduct product, CancellationToken cancellationToken)
        {
            var Receivedproduct = _context.ReceivedProducts.First(x => x.Product.Code == product.Product.Code);
            Receivedproduct.Qty += product.Qty;
            _context.SaveChanges();
        }

        public void Upsert(ReceivedProduct product, CancellationToken cancellationToken)
        {
            try
            {
                if (IsProductNameExist(product.Product.ProductName, cancellationToken).Result == false && Get(product.Product.Code, cancellationToken).Result == null)
                {
                    Create(product);
                }
                else
                {
                    UpdateQuantity(product, cancellationToken);
                }
            }
            catch (Exception ex)
            {
                //log
            }
        }

        private double GetProductQuantity(Guid Code)
        {
            var sqlraw = $"EXEC [dbo].[sproc_Get_Quantity] '{Code}'";
            var result = _context.Set<ReceivedProductQuantity>().FromSqlRaw(sqlraw).AsEnumerable().FirstOrDefault();
            return result.Qty;
        }

        private async Task<bool> IsProductNameExist(string ProductName, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _context.ReceivedProducts.CountAsync(x => x.Product.ProductName == ProductName, cancellationToken);

                if (result != 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {

            }

            return false;
        }
    }
}
