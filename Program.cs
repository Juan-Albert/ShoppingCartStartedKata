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

app.MapGet("/cartContent", (Cart cart) => cart);

app.MapPost("/addProduct", (Product toAdd, Cart cart) =>
{
    cart.AddProduct(toAdd);
    return Results.Created("Product", toAdd);
});

app.Run();

public class Cart
{
    private List<Product> products = new();

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public override string ToString()
    {
        return products.Count == 0 ? "{}" : string.Join(", ", products);
    }
}