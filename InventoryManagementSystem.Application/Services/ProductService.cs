using AutoMapper;
using InventoryManagementSystem.Application.Interface.Repository;
using InventoryManagementSystem.Application.Models;
using InventoryManagementSystem.Application.Services.Interface;
using InventoryManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public void Create(ProductModel entity)
        {
            try
            {
                Product product = MappedProduct(entity);
                _productRepository.Create(product);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message,ex);
            }
        }

        private Product MappedProduct(ProductModel entity)
        {
            return _mapper.Map<Product>(entity);
        }

        public async Task<bool> Delete(string ProductName, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _productRepository.Delete(ProductName, cancellationToken);
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void Delete(ProductModel entity)
        {
            try
            {
                var product = MappedProduct(entity);
                _productRepository.Delete(product);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<ProductModel> Get(Guid code, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _productRepository.Get(code, cancellationToken);
                var mappedResult = MappedProductModel(result);
                return mappedResult;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private ProductModel MappedProductModel(Product result)
        {
            return _mapper.Map<ProductModel>(result);
        }

        public async Task<List<ProductModel>> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                var result = await _productRepository.GetAll(cancellationToken);
                var mappedResult = _mapper.Map<List<ProductModel>>(result);
                return mappedResult;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message,ex);
            }
        }

        public ItemCountModel GetCount()
        {
            try
            {
                var result = _productRepository.GetCount();
                var mappedResult = _mapper.Map<ItemCountModel>(result);
                return mappedResult;
            }
            catch(Exception ex) {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<KeyValueModel> GetProductNames()
        {
            try
            {
                var result = _productRepository.GetProductNames();
                var mappedResult = _mapper.Map<List<KeyValueModel>>(result);
                return mappedResult;
            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<bool> IsProductNameExist(string ProductName, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _productRepository.IsProductNameExist(ProductName, cancellationToken);
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void Update(ProductModel entity)
        {
            try
            {
                var product = MappedProduct(entity);
                _productRepository.Update(product);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public bool Upsert(ProductModel productModel, CancellationToken cancellationToken)
        {
            try
            {
                var product = MappedProduct(productModel);
                var result = _productRepository.Upsert(product, cancellationToken);
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
