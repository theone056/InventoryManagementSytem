using AutoMapper;
using InventoryManagementSystem.Application.Models;
using InventoryManagementSystem.Application.Services.ProductServices.Interface;
using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Domain.Interface.Repository;

namespace InventoryManagementSystem.Application.Services.ProductServices
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
