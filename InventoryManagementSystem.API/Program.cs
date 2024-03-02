using InventoryManagementSystem.API.Filters.ExceptionFilters;
using InventoryManagementSystem.Core;
using InventoryManagementSystem.Infrastructure;
using InventoryManagementSystem.Infrastructure.Context;
using Serilog;
public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        //Serilog

        builder.Host.UseSerilog((HostBuilderContext context, IServiceProvider services, LoggerConfiguration loggerConfiguration) =>
        {
            loggerConfiguration
                                .ReadFrom.Configuration(context.Configuration)
                                .ReadFrom.Services(services);
        });

        // Add services to the container.
        builder.Services.RegisterDependencies(builder.Configuration);
        builder.Services.ConfigApplication();
        builder.Services.AddAuthentication();
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddMvc(option =>
        {
            option.Filters.Add(new HandleExceptionFilter());
        }).AddNewtonsoftJson(
            options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );


        var app = builder.Build();

        var serviceScope = app.Services.CreateScope();
        var dataContext = serviceScope.ServiceProvider.GetService<IMSDbContext>();
        dataContext?.Database.EnsureCreated();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}