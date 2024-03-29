﻿using AutoMapper;
using InventoryManagementSystem.Core.Domain.Entities;
using InventoryManagementSystem.Core.Models;

namespace InventoryManagementSystem.Core.Mappings
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
                .ForMember(dest => dest.Price, src => src.MapFrom(x => x.SellingPrice));
            CreateMap<StockInventory,StockInventoryModel>();
            CreateMap<ItemCount, ItemCountModel>().ReverseMap();
            CreateMap<KeyValue, KeyValueModel>().ReverseMap();
            CreateMap<ProductModel, Product>().ReverseMap();
            CreateMap<StockInventory, GetStockInventoryResponse>().ReverseMap();
            CreateMap<Sale, GetAllSalesResponse>()
                .ForMember(dest=>dest.ProductCode, src=>src.MapFrom(x=>x.ProductCode))
                .ForMember(dest=>dest.Id, src=>src.MapFrom(x=>x.Id))
                .ForMember(dest=>dest.Qty, src=>src.MapFrom(x=>x.Qty))
                .ForMember(dest=>dest.TransactionDate, src=>src.MapFrom(x=>x.TransactionDate))
                .ForMember(dest=>dest.TotalSales, src=>src.MapFrom(x=>x.TotalSales))
                .ForMember(dest=>dest.DateUpdated, src=>src.MapFrom(x=>x.DateUpdated))
                .ForMember(dest=>dest.DateCreated, src=>src.MapFrom(x=>x.DateCreated))
                .ForMember(dest=>dest.ProductName, src=>src.MapFrom(x=>x.Product.ProductName))
                .ForMember(dest=>dest.Unit, src=>src.MapFrom(x=>x.Product.Unit))
                .ForMember(dest=>dest.Price, src=>src.MapFrom(x=>x.Product.Price))
                .ReverseMap();
        }
    }
}
