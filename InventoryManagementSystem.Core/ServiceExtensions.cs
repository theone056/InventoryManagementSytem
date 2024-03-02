using AutoMapper;
using InventoryManagementSystem.Core.Mappings;
using InventoryManagementSystem.Core.Services.ProductServices;
using InventoryManagementSystem.Core.Services.ProductServices.Interface;
using InventoryManagementSystem.Core.Services.ReceivedProductServices;
using InventoryManagementSystem.Core.Services.ReceivedProductServices.Interface;
using InventoryManagementSystem.Core.Services.SalesServices;
using InventoryManagementSystem.Core.Services.SalesServices.Interface;
using InventoryManagementSystem.Core.Services.StocksServices;
using InventoryManagementSystem.Core.Services.StocksServices.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryManagementSystem.Core
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