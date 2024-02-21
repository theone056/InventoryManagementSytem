using AutoMapper;
using InventoryManagementSystem.Application.Models;
using InventoryManagementSystem.Domain.Entities;

namespace InventoryManagementSystem.Application.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User,UserRegistrationModel>();
            CreateMap<Product, GetProductResponse>()
                .ForMember(dest=>dest.MaxStock, src=>src.MapFrom(x=>x.Stocks.StockQty))
                .ReverseMap();
            CreateMap<Product, GetAllProductResponse>()
                .ForMember(dest=>dest.Code, src=>src.MapFrom(x=>x.Code))
                .ForMember(dest=>dest.ProductName, src=>src.MapFrom(x=> x.ProductName))
                .ForMember(dest=>dest.Price, src=>src.MapFrom(x=>x.Price))
                .ForMember(dest=>dest.Remarks, src=>src.MapFrom(x=>x.Remarks))
                .ForMember(dest=>dest.Unit, src=>src.MapFrom(x=>x.Unit))
               .ReverseMap();
            CreateMap<Sale, SalesModel>().ReverseMap();
            CreateMap<ReceivedProduct, ReceivedProductModel>().ReverseMap();
            CreateMap<ReceivedProduct, GetAllReceivedProductResponse>()
                .ForMember(dest => dest.ProductName, src => src.MapFrom(x => x.Product.ProductName))
                .ForMember(dest => dest.Unit, src => src.MapFrom(x => x.Product.Unit))
                .ForMember(dest => dest.Price, src => src.MapFrom(x => x.Product.Price));
            CreateMap<StockInventory,StockInventoryModel>();
            CreateMap<ItemCount, ItemCountModel>().ReverseMap();
            CreateMap<KeyValue, KeyValueModel>().ReverseMap();
            CreateMap<ProductModel, Product>().ReverseMap();
        }
    }
}
