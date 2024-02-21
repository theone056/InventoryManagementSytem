using AutoMapper;
using InventoryManagementSystem.Application.Interface.Repository;
using InventoryManagementSystem.Application.Models;
using InventoryManagementSystem.Application.Services.ProductServices.Interface;
using InventoryManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.Services.ProductServices
{
    public class GetProductService : IGetProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public GetProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<GetProductResponse> Get(Guid code, CancellationToken cancellationToken)
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


        public async Task<List<GetAllProductResponse>> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                var result = await _productRepository.GetAll(cancellationToken);
                var mappedResult = _mapper.Map<List<GetAllProductResponse>>(result);
                return mappedResult;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<KeyValueModel> GetAvailableProducts()
        {
            try
            {
                var result = _productRepository.GetProductNames().Where(x=>x.StockQty > 0).ToList();
                var mappedResult = _mapper.Map<List<KeyValueModel>>(result);
                return mappedResult;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
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
            catch (Exception ex)
            {
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
            catch (Exception ex)
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private GetProductResponse MappedProductModel(Product result)
        {
            return _mapper.Map<GetProductResponse>(result);
        }
    }
}
