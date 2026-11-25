using InventoryManagement.Interfaces;
using InventoryManagement.Repositories;
using InventoryManagement.Data;
using Microsoft.EntityFrameworkCore;
using InventoryManagement.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args); // dotnet er built-in method ja application startup er jonno proyojonio configuration ready kore 
// Add services to the container.
builder.Services.AddControllers(); // addcontrollers dotnet ke janasse je controller support configuration hobe
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(); // service register kore 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// builder.Services.AddSingleton< ProductService>();

builder.Services.AddDbContext<InventoryDbContext>(options =>
    options.UseNpgsql(//ef core ke janasse je postgres use korte hobe
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);
// Register Data Protection services
builder.Services.AddDataProtection();

builder.Services
//Identity User Management register
    .AddIdentityCore<ApplicationUser>(options =>
    {
        options.Password.RequiredLength = 8;
        options.Password.RequireDigit = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireNonAlphanumeric = false;

        options.User.RequireUniqueEmail = true;
    })
    .AddRoles<IdentityRole>()//Role Management enable
    .AddEntityFrameworkStores<InventoryDbContext>()//PostgreSQL DbContext er shathe connected
    .AddDefaultTokenProviders();//default token providers register


// builder.Services.AddSingleton<IProductService, ProductService>();//shob redic cache a singleton use hobe ta na and share state thread safe kina etio dkehte hobe
builder.Services.AddScoped<IProductRepository, ProductRepository>();//for database connection use AddScoped()
// builder.Services.AddSingleton<IProductRepository, ProductRepository>();//object er life time nirdaron kore AddSingleton()application start hole ekbar object create kore redis memory cache logger
//AddScoped() protiti http request er jonno ekbar and AddTransient() protibar call korar shahteh shathe new object create korbe appdebcontext product service and khubi lightweight and sms email pathanor jonno eti dependency resolve hole new intance hoy  
var app = builder.Build(); // builder diye application configure kori and app diye request pipeline configure kori 

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) // check hocce app development mode a cholse kina jodi chole 
{
    app.MapOpenApi(); // open api er json document er endpoint map hobe and mapopenapi endpoint expose kore 
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection(); // http redirect korar middleware

app.UseAuthorization(); // add authorization middleware 

app.MapControllers(); // controller er attribute routing use kore api endpoint map kore 

app.Run(); // application on kore http request pawar jonno wait kore