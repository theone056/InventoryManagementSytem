using AutoMapper;
using InventoryManagementSystem.Core.Models;
using InventoryManagementSystem.Core.Services.ProductServices.Interface;
using InventoryManagementSystem.Core.Domain.Entities;
using InventoryManagementSystem.Core.Domain.Interface.Repository;

namespace InventoryManagementSystem.Core.Services.ProductServices
{
    public class CreateProductService : ICreateProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public CreateProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public void Create(ProductModel entity, CancellationToken cancellationToken)
        {
            try
            {
                Product product = MappedProduct(entity);
                _productRepository.Upsert(product,cancellationToken);
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
