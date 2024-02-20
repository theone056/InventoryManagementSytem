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
            CreateMap<Product, ProductModel>().ReverseMap();
            CreateMap<Sale, SalesModel>().ReverseMap();
            CreateMap<ReceivedProduct, ReceivedProductModel>()
                .ForMember(dest=>dest.ProductName, src=>src.MapFrom(x=>x.Product.ProductName))
                .ForMember(dest=>dest.Unit, src=>src.MapFrom(x=>x.Product.Unit))
                .ForMember(dest=>dest.Price, src=> src.MapFrom(x=>x.Product.Price));
            CreateMap<StockInventory,StockInventoryModel>();
            CreateMap<KeyValue, KeyValueModel>();
            CreateMap<ItemCount, ItemCountModel>().ReverseMap();
            CreateMap<KeyValue, KeyValueModel>().ReverseMap();
        }
    }
}
