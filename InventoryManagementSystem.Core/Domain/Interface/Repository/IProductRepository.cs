﻿using InventoryManagementSystem.Core.Domain.Entities;

namespace InventoryManagementSystem.Core.Domain.Interface.Repository
{
    public interface IProductRepository: IBaseRepository<Product>
    {
        Task<Product> Get(Guid code, CancellationToken cancellationToken);
        Task<List<Product>> GetAll(CancellationToken cancellationToken);
        Task<bool> IsProductNameExist(string ProductName,CancellationToken cancellationToken);
        Task<bool> Delete(string ProductName, CancellationToken cancellationToken);
        ItemCount GetCount();
        List<KeyValue> GetProductNames();
        bool Upsert(Product productModel, CancellationToken cancellationToken);
    }
}
