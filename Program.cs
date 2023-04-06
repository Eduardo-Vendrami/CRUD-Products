using CRUD_Products.Models.DataAccess;
using CRUD_Products.Models.Login.Repository;
using CRUD_Products.Models.Login.Service;
using CRUD_Products.Models.Product.Service;
using CRUD_Products.Models.Products.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddSingleton<IProductService, ProductService>();

builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddSingleton<IProductRepository, ProductRepository>();

builder.Services.AddTransient<ILoginService, LoginService>();
builder.Services.AddSingleton<ILoginRepository, LoginRepository>();

builder.Services.AddTransient<IConnection, Connection>();
builder.Services.AddSingleton<IConnection, Connection>();
// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<DataContext>(opt => opt.UseSqlServer("connectionString"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

