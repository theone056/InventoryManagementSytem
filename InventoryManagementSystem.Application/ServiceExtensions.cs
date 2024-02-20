using AutoMapper;
using InventoryManagementSystem.Application.Interface.Repository;
using InventoryManagementSystem.Application.Mappings;
using InventoryManagementSystem.Application.Services;
using InventoryManagementSystem.Application.Services.Interface;
using InventoryManagementSystem.Application.Services.SalesService;
using InventoryManagementSystem.Application.Services.SalesService.Interface;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace InventoryManagementSystem.Application
{
    public static class ServiceExtensions
    {
        public static void ConfigApplication(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(map =>
            {
                map.AddProfile<UserMappingProfile>();
            });

            services.AddSingleton(mappingConfig.CreateMapper());
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IReceivedProductService, ReceivedProductService>();
            services.AddTransient<ISalesService, SalesServices>();
            services.AddTransient<IStocksService, StocksService>();
            services.AddTransient<ICreateSalesService, CreateSalesService>();
        }
    }
}