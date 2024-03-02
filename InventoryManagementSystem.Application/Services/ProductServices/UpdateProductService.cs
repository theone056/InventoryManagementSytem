using AutoMapper;
using InventoryManagementSystem.Application.Models;
using InventoryManagementSystem.Application.Services.ProductServices.Interface;
using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Domain.Interface.Repository;

namespace InventoryManagementSystem.Application.Services.ProductServices
{
    public class UpdateProductService : IUpdateProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public UpdateProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public void Update(ProductModel productModel, CancellationToken cancellationToken)
        {
            try
            {
                var productResult = _productRepository.Get(productModel.Code, cancellationToken).Result;
                if (productResult != null)
                {
                    var product = _mapper.Map<Product>(productResult);
                    _productRepository.Update(product);
                }
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private Product MappedProduct(ProductModel entity)
        {
            return _mapper.Map<Product>(entity);
        }

    }
}
