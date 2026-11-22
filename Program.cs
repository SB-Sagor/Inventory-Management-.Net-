var builder = WebApplication.CreateBuilder(args); // dotnet er built-in method ja application startup er jonno proyojonio configuration ready kore 

// Add services to the container.
builder.Services.AddControllers(); // addcontrollers dotnet ke janasse je controller support configuration hobe
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(); // service register kore 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build(); // builder diye application configure kori and app diye request pipeline configure kori 

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) // check hocce app development mode a cholse kina jodi chole 
{
    app.MapOpenApi(); // open api er json document er endpoint map hobe and mapopenapi endpoint expose kore 
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // http redirect korar middleware

app.UseAuthorization(); // add authorization middleware 

app.MapControllers(); // controller er attribute routing use kore api endpoint map kore 

app.Run(); // application on kore http request pawar jonno wait kore