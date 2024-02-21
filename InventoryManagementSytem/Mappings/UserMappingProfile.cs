using AutoMapper;
using InventoryManagementSytem.Models;
using InventoryManagementSytem.Services.Model;
using InventoryManagementSytem.Services.Models;

namespace InventoryManagementSytem.Mappings
{
    public class UserMappingProfile:Profile
    {
        public UserMappingProfile()
        {
            CreateMap<PaymentRequest, SalesModel>()
                .ForMember(dest=> dest.ProductCode, src=>src.MapFrom(x=>x.code))
                .ForMember(dest=>dest.Qty, src=>src.MapFrom(x=>x.qty))
                .ForMember(dest=>dest.TotalSales, src=>src.MapFrom(x=>x.subTotal))
                .ReverseMap();
        }
    }
}
