using AutoMapper;
using Grocery.Core.Repositories;
using Grocery.Core.Service;
using Grocery.Data;
using Grocery.Data.Repositories;
using Grocery.Service;
using GroceryAPI.Mapping;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(@"Server=DESKTOP-SSNMLFD;DataBase=GroceryDb;TrustServerCertificate=True;Trusted_Connection=True"));

builder.Services.AddScoped<IGrocerService, GrocerService>();
builder.Services.AddScoped<IGrocerRepository, GrocerRepository>();
builder.Services.AddAutoMapper(typeof(PostMappingGrocer), typeof(PostMappingGrocerLogin));


builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddAutoMapper(typeof(PostMappingSupplier), typeof(PostMappingSupplierLogin));

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddAutoMapper(typeof(PostMappingProduct));

builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddAutoMapper(typeof(PostMappingOrder));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
