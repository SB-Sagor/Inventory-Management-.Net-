var builder = WebApplication.CreateBuilder(args);//dotnet er build in method ja eti application startup er jonno proyojonio configaration ready kore 

// Add services to the container.

builder.Services.AddControllers();//addcontrollers dotnet ke janasse je controller support configaration hobe
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();//service register kore 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();//builder diye application configure kori and app diye request pipeline configure kori 

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())//check hocce app development mode a cholse kina jodi chole 
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();//open api er json document er endpoint map hobe and mapopenapi endpoint expose kore 
}

app.UseHttpsRedirection();//http redirect korar middleware

app.UseAuthorization();//add authorization middelware 

app.MapControllers();//controller er attribute routing use kore api end point map kore 

app.Run();//application on kore http request pawar jonno wait kore 

