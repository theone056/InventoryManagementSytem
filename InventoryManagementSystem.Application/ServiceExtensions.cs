using AutoMapper;
using InventoryManagementSystem.Application.Interface.Repository;
using InventoryManagementSystem.Application.Mappings;
using InventoryManagementSystem.Application.Services;
using InventoryManagementSystem.Application.Services.Interface;
using InventoryManagementSystem.Application.Services.ProductServices;
using InventoryManagementSystem.Application.Services.ProductServices.Interface;
using InventoryManagementSystem.Application.Services.ReceivedProductServices;
using InventoryManagementSystem.Application.Services.ReceivedProductServices.Interface;
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
            services.AddTransient<ISalesService, SalesServices>();
            services.AddTransient<IStocksService, StocksService>();
            services.AddTransient<ICreateSalesService, CreateSalesService>();
            services.AddTransient<IGetProductService, GetProductService>();
            services.AddTransient<ICreateProductService, CreateProductService>();
            services.AddTransient<IUpdateProductService, UpdateProductService>();
            services.AddTransient<IDeleteProductService, DeleteProductService>();
            services.AddTransient<IGetReceivedProductService, GetReceivedProductService>();
            services.AddTransient<IUpdateReceivedProductService, UpdateReceivedProductService>();
            services.AddTransient<IDeleteReceivedProductService, DeleteReceivedProductService>();
            services.AddTransient<ICreateReceivedProductService, CreateReceivedProductService>();
        }
    }
}