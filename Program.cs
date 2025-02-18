using Microsoft.AspNetCore.Mvc;
using ShoppingCartStartedKata.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSingleton<Cart>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapPost("/addProduct", (Product toAdd, Cart cart) =>
{
    cart.AddProduct(toAdd);
    return Results.Created("Product", toAdd);
});

app.Run();