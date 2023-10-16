using InventoryManagementSystem.Application;
using InventoryManagementSystem.Infrastructure;
using InventoryManagementSystem.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.RegisterDependencies(builder.Configuration);
builder.Services.ConfigApplication();
builder.Services.AddAuthentication();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
