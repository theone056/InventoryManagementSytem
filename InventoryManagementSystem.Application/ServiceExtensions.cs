using AutoMapper;
using InventoryManagementSystem.Application.Interface.Repository;
using InventoryManagementSystem.Application.Mappings;
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
        }
    }
}