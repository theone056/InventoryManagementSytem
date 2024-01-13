using InventoryManagementSystem.Application.Interface.Repository;
using InventoryManagementSystem.Application.Models;
using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly IMSDbContext _context;
        public ProductRepository(IMSDbContext context) : base(context)
        {
            _context = context;
        }

        public List<KeyValue> GetProductNames()
        {
            return _context.Set<KeyValue>().FromSqlRaw("EXEC dbo.sproc_Get_Products").AsEnumerable().ToList();
        }

        public ItemCount GetCount()
        {
            var result = _context.Set<ItemCount>().FromSqlRaw(@"EXEC [dbo].[sproc_Total_Items]").AsEnumerable().FirstOrDefault();
            return result;
        }

        public async Task<bool> Delete(string ProductName, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _context.Products.FirstOrDefaultAsync(x => x.ProductName == ProductName, cancellationToken);
                if (result != null)
                {
                    _context.Products.Remove(result);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                
            }

            return false;
        }

        public async Task<Product> Get(Guid code, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Products.Where(x => x.Code == code).FirstOrDefaultAsync(cancellationToken);
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public async Task<List<Product>> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Products.ToListAsync(cancellationToken);
            }
            catch(Exception ex)
            {
                
            }
            return null;
        }

        public async Task<bool> IsProductNameExist(string ProductName, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _context.Products.CountAsync(x => x.ProductName == ProductName, cancellationToken);

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

        private void CheckValidData(Product product)
        {
            if(IsProductNameExist(product.ProductName, new CancellationToken()).Result && product.Code == Guid.Empty)
            {
                throw new Exception("Product name already exists");
            }
        }

        public bool Upsert(Product product, CancellationToken cancellationToken)
        {
            try
            {
                CheckValidData(product);

                if (IsProductNameExist(product.ProductName, cancellationToken).Result == false && Get(product.Code, cancellationToken).Result == null)
                {
                    Create(product);
                    return true;
                } 
                else
                {
                    Update(product);
                    return true;
                }
            }
            catch(Exception ex)
            {
                throw;
                //log
            }
        }
    }
}
