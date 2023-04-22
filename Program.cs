using CRUD_Products;
using CRUD_Products.Models.DataAccess;
using CRUD_Products.Models.Login.Repository;
using CRUD_Products.Models.Login.Service;
using CRUD_Products.Models.Product.Service;
using CRUD_Products.Models.Products.Repository;
using CRUD_Products.Services.Email.Service;
using CRUD_Products.Services.Token.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddSingleton<IProductService, ProductService>();

builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddSingleton<IProductRepository, ProductRepository>();

builder.Services.AddTransient<ILoginService, LoginService>();
builder.Services.AddSingleton<ILoginService, LoginService>();

builder.Services.AddTransient<ILoginRepository, LoginRepository>();
builder.Services.AddSingleton<ILoginRepository, LoginRepository>();

builder.Services.AddTransient<IConnection, Connection>();
builder.Services.AddSingleton<IConnection, Connection>();

builder.Services.AddTransient<ITokenService, TokenService>();
builder.Services.AddSingleton<ITokenService, TokenService>();

builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddSingleton<IEmailService, EmailService>();

// Add services to the container.

builder.Services.AddResponseCompression(options => 
{
    options.Providers.Add<GzipCompressionProvider>();
    options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] {"application/json"});
});  

builder.Services.AddControllers();

var key = Encoding.ASCII.GetBytes(Settings.Secret);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters 
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();

