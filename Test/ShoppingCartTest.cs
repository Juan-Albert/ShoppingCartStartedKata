﻿using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using ShoppingCartStartedKata;
using ShoppingCartStartedKata.Domain;
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
        content.Should().Contain(Product.Potato.Name);
    }

    [Fact]
    public async Task ShowCartContent()
    {
        var webFactory = new WebApplicationFactory<WebDummy>();
        var client = webFactory.CreateClient();

        var result = await client.GetAsync("/showCartContent");

        result.IsSuccessStatusCode.Should().BeTrue();
        var content = await result.Content.ReadAsStringAsync();
        content.Should().Be("{\"products\":[]}");
    }

    [Fact]
    public async Task ShowProducts()
    {
        var webFactory = new WebApplicationFactory<WebDummy>();
        var client = webFactory.CreateClient();
        var potato = Product.Potato;
        
        var postResult = await client.PostAsJsonAsync("/addProduct", potato);
        
        postResult.IsSuccessStatusCode.Should().BeTrue();
        
        var getResult = await client.GetAsync("/showCartContent");
        
        getResult.IsSuccessStatusCode.Should().BeTrue();
        var content = await getResult.Content.ReadAsStringAsync();
        content.Should().Contain(Product.Potato.Name);
    }

}
