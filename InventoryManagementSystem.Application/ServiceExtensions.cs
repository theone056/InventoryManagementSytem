using AutoMapper;
using InventoryManagementSystem.Application.Mappings;
using InventoryManagementSystem.Application.Services.ProductServices;
using InventoryManagementSystem.Application.Services.ProductServices.Interface;
using InventoryManagementSystem.Application.Services.ReceivedProductServices;
using InventoryManagementSystem.Application.Services.ReceivedProductServices.Interface;
using InventoryManagementSystem.Application.Services.SalesServices;
using InventoryManagementSystem.Application.Services.SalesServices.Interface;
using InventoryManagementSystem.Application.Services.StocksServices;
using InventoryManagementSystem.Application.Services.StocksServices.Interface;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddTransient<ICreateSalesService, CreateSalesService>();
            services.AddTransient<IGetSalesService, GetSalesService>();
            services.AddTransient<IDeleteSalesService, DeleteSalesService>();
            services.AddTransient<IUpdateSalesService, UpdateSalesService>();
            services.AddTransient<IGetProductService, GetProductService>();
            services.AddTransient<ICreateProductService, CreateProductService>();
            services.AddTransient<IUpdateProductService, UpdateProductService>();
            services.AddTransient<IDeleteProductService, DeleteProductService>();
            services.AddTransient<IGetReceivedProductService, GetReceivedProductService>();
            services.AddTransient<IUpdateReceivedProductService, UpdateReceivedProductService>();
            services.AddTransient<IDeleteReceivedProductService, DeleteReceivedProductService>();
            services.AddTransient<ICreateReceivedProductService, CreateReceivedProductService>();
            services.AddTransient<ICreateStockService, CreateStockService>();
            services.AddTransient<IGetStockService, GetStockService>();
            services.AddTransient<IDeleteStockService, DeleteStockService>();
            services.AddTransient<IUpdateStockService, UpdateStockService>();

        }
    }
}