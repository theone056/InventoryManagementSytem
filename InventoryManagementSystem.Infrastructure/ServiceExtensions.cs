using InventoryManagementSystem.API.CustomTokenProvider;
using InventoryManagementSystem.Application.Interface.Repository;
using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Infrastructure.Context;
using InventoryManagementSystem.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace InventoryManagementSystem.Infrastructure
{
    public static class ServiceExtensions
    {
        public static void ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IMSDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("connectionString"));
            });

            services.AddIdentity<User,IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = false;

               // options.Tokens.EmailConfirmationTokenProvider = "emailconfirmation";
            })
            .AddEntityFrameworkStores<IMSDbContext>()
            .AddDefaultTokenProviders()
            .AddTokenProvider<EmailConfirmationTokenProvider<User>>("emailconfirmation");

            //For Email Confirmation
            //services.Configure<DataProtectionTokenProviderOptions>(opt =>
            //opt.TokenLifespan = TimeSpan.FromHours(2));

            //services.Configure<EmailConfirmationTokenProviderOptions>(opt =>
            //    opt.TokenLifespan = TimeSpan.FromDays(3));
        }

        public static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IJWTManagerRepository, JWTManagerRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
        }

        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtConfig = configuration.GetSection("JwtConfig");
            var secretKey = jwtConfig["secret"];
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtConfig["validIssuer"],
                    ValidAudience = jwtConfig["validAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };
            });
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Inventory Management API",
                    Version = "v1",
                    Description = "Inventory Management API service",
                    Contact = new OpenApiContact
                    {
                        Name = "Derick Colon"
                    }
                });
                c.ResolveConflictingActions(apiDescription => apiDescription.First());
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference()
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });
        }

        public static void ConfigureControllers(this IServiceCollection services)
        {
            services.AddControllers(config =>
            {
                config.CacheProfiles.Add("30SecondsCaching", new CacheProfile
                {
                    Duration = 30
                });
            });
        }
        public static void ConfigureResponseCaching(this IServiceCollection services) => services.AddResponseCaching();


        public static void RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
        {

            services.ConfigurePersistence(configuration);
            services.ConfigureJWT(configuration);
            services.ConfigureSwagger();
            services.ConfigureDependencyInjection();
            services.ConfigureControllers();
            services.ConfigureResponseCaching();
        }
    }
}