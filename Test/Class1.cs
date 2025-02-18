using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using ShoppingCartAlejandroKata;
using Xunit;

namespace Test;

//Listar productos disponibles.

///Agregar un producto al carrito.

// Ver el contenido del carrito.

// Calcular el total final.

public class ShoppingCartTest
{
    [Fact]
    public async Task ShowAvailableProducts()
    {
        var webFactory = new WebApplicationFactory<WebDummy>();
        var client = webFactory.CreateClient();

        var result = await client.GetAsync("/availableProducts");

        result.IsSuccessStatusCode.Should().BeTrue();
        var content = await result.Content.ReadAsStringAsync();
        content.Should().Contain("Patata");
    }
    
}
