﻿using InventoryManagementSytem.Services.Home.Interface;
using InventoryManagementSytem.Services.Home;
using InventoryManagementSytem.Services.Product.Interface;
using InventoryManagementSytem.Services.Product;
using InventoryManagementSytem.Services.ReceivedProduct.Interface;
using InventoryManagementSytem.Services.ReceivedProduct;

namespace InventoryManagementSytem.Services
{
    public static class ServiceExtensions
    {
        public static void ConfigureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureAPIBaseAddress();
            services.ConfigureDependencyInjection();
        }

        private static void ConfigureAPIBaseAddress(this IServiceCollection services)
        {
            services.AddHttpClient("ProductService", client =>
            {
                client.BaseAddress = new Uri("https://localhost:7275/api/");
            });
            services.AddHttpClient("HomeService", client =>
            {
                client.BaseAddress = new Uri("https://localhost:7275/api/");
            });
            services.AddHttpClient("ReceivedProductService", client =>
            {
                client.BaseAddress = new Uri("https://localhost:7275/api/");
            });
        }

        private static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IHomeService, HomeService>();
            services.AddTransient<IReceivedProductService, ReceivedProductService>();
        }
    }
}